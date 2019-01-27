using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class AddMemberForm : Form
    {
        VLendDao vdao;

        public AddMemberForm()
        {
            InitializeComponent();
        }
        
        //폼 로드시 비디오대여 객체 생성
        private void AddMemberForm_Load(object sender, EventArgs e)
        {
            vdao = new VLendDao();            
        }

        //대여버튼 클릭
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isL = false;
            string jumin = this.txtJumin.Text;
            string cusname = this.txtCusName.Text;
            string addr = this.txtAddr.Text;
            string phone = this.txtPhone.Text;

            if (string.IsNullOrEmpty(jumin) ||
                string.IsNullOrEmpty(cusname) ||
                string.IsNullOrEmpty(addr) ||
                string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("모든 정보를 입력하여 주세요", "입력오류");
                return;
            }

            //
            try
            {
                isL = vdao.InsertCustomer(jumin, cusname, addr, phone);
            }
            catch (FoundException)
            {
                MessageBox.Show("고객의 아이디가 이미 등록 되어 있습니다");
            }

            if (isL)
            {
                MessageBox.Show(cusname + "고객님의 정보가 입력 완료 되었습니다");

                this.txtJumin.Text = "";
                this.txtCusName.Text = "";
                this.txtAddr.Text = "";
                this.txtPhone.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show(cusname + "고객님 정보 입력 오류발생. 관리자에게 문의요망", "입력오류");
                return;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
    }
}