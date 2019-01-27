using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class PassChangeForm : Form
    {
        PChangeDao dao;
        public PassChangeForm()
        {
            InitializeComponent();
        }
        
        private void PassChangeForm_Load(object sender, EventArgs e)
        {
            dao = new PChangeDao();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string nowPass = this.txtNowPass.Text.Trim();
            string changePass = this.txtChangePass.Text.Trim();
            string reCheckPass = this.txtReCheckPass.Text.Trim();
                        
            if(string.IsNullOrEmpty(nowPass))
            {
                MessageBox.Show("현재 비밀번호를 입력하세요");
                return;
            }
            else if (string.IsNullOrEmpty(changePass) || 
                     string.IsNullOrEmpty(reCheckPass))
            {
                MessageBox.Show("변경할 비밀번호를 입력하세요");
                return;
            }
            else if (changePass != reCheckPass)
            {
                MessageBox.Show("변경할 비밀번호가 일치하지 않습니다");
                return;
            }

            bool NowPasswd = dao.CheckNowPassword(nowPass);

            if (NowPasswd)
            {
                bool changepwd = dao.UpdatePassWord(nowPass, changePass);
                if (changepwd)
                {
                    MessageBox.Show("비밀번호변경 성공");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("비밀번호변경 실패!!\n관리자에게 문의하세요");
                }
            }
            else
            {
                MessageBox.Show("현재 비밀번호가 일치하지 않습니다");
                return;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}