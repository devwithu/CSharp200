using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class MemberFindForm : Form
    {
        public MemberFindForm()
        {
            InitializeComponent();
        }
                
        MFFDao dao;

        private void MemberFindForm_Load(object sender, EventArgs e)
        {
            ListViewUpdate();
        }

        private void LVcusFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds;
            string currNum = this.LVcusFind.FocusedItem.Text.Trim();

            ds = dao.GetCusIdCustomer(currNum);

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
                        
            this.txtCusId.Text = dr["mem_no"].ToString();            
            this.txtJumin.Text = dr["mem_jumin"].ToString();
            this.txtCusName.Text = dr["mem_name"].ToString();
            this.txtAddr.Text = dr["mem_address"].ToString();
            this.txtPhone.Text = dr["mem_phone"].ToString();
            this.txtPoint.Text = dr["mem_point"].ToString();            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.txtCusId.Text = "자동부여";            
            this.txtJumin.Text = "";
            this.txtCusName.Text = "";
            this.txtAddr.Text = "";
            this.txtPhone.Text = "";
            this.txtPoint.Text = "";
                        
            this.txtJumin.ReadOnly = false;
            this.txtCusName.ReadOnly = false;
            this.txtAddr.ReadOnly = false;
            this.txtPhone.ReadOnly = false;

            this.label9.Hide();
            this.txtPoint.Hide();

            this.txtJumin.Focus();
            this.btnInsert.Hide();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isL = false;

            string cusid = this.txtCusId.Text;            
            string jumin = this.txtJumin.Text;
            string cusname = this.txtCusName.Text;
            string addr = this.txtAddr.Text;
            string phone = this.txtPhone.Text;

            if (string.IsNullOrEmpty(cusid) ||                
                string.IsNullOrEmpty(jumin) ||
                string.IsNullOrEmpty(cusname) ||
                string.IsNullOrEmpty(addr) ||
                string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("모든 정보를 입력하여 주세요", "입력오류");
                return;
            }

            if (jumin.Length > 14)
            {
                MessageBox.Show("주민번호가 옳바르지 않습니다");
                return;
            }

            try
            {
                isL = dao.InsertCustomer(jumin, cusname, addr, phone);
            }
            catch (FoundException)
            {
                MessageBox.Show("고객의 아이디가 이미 등록 되어 있습니다");
            }

            if (isL)
            {
                MessageBox.Show(cusname + "고객님의 정보가 입력 완료 되었습니다");

                this.txtCusId.Text = "";                
                this.txtJumin.Text = "";
                this.txtCusName.Text = "";
                this.txtAddr.Text = "";
                this.txtPhone.Text = "";
                this.txtPoint.Text = "";

                this.txtCusId.ReadOnly = true;                
                this.txtJumin.ReadOnly = true;
                this.txtCusName.ReadOnly = true;
                this.txtAddr.ReadOnly = true;
                this.txtPhone.ReadOnly = true;

                this.label9.Show();
                this.txtPoint.Show();

                this.btnInsert.Show();

                this.LVcusFind.Items.Clear();

                ListViewUpdate();
            }
            else
            {
                MessageBox.Show(cusname + "고객님 정보 입력 오류발생. 관리자에게 문의요망", "입력오류");
                return;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string s = this.txtCusId.Text;
            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("수정할 고객을 선택하세요");
                return;
            }
            this.btnOK.Visible = false;
            this.btnOK2.Visible = true;                      
            
            this.txtJumin.ReadOnly = false;
            this.txtCusName.ReadOnly = false;
            this.txtAddr.ReadOnly = false;
            this.txtPhone.ReadOnly = false;
            this.txtPoint.ReadOnly = false;

            this.btnModify.Visible = false;
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            bool isL = false;

            string cusid = this.txtCusId.Text;            
            string jumin = this.txtJumin.Text;
            string cusname = this.txtCusName.Text;
            string addr = this.txtAddr.Text;
            string phone = this.txtPhone.Text;
            string point = this.txtPoint.Text;

            if (string.IsNullOrEmpty(cusid) ||                
                string.IsNullOrEmpty(jumin) ||
                string.IsNullOrEmpty(cusname) ||
                string.IsNullOrEmpty(addr) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(point))
            {
                MessageBox.Show("입력사항을 모두 기입하여 주세요", "입력오류");
                return;
            }

            try
            {
                isL = dao.UpdateCustomer(cusid, jumin, cusname, addr, phone, point);
            }
            catch (NotFoundException)
            {
                MessageBox.Show("수정할 고객이 등록되어 있지 않습니다");
            }

            if (isL)
            {
                MessageBox.Show(cusname + "님 정보 수정 완료");

                this.btnOK.Visible = true;
                this.btnOK2.Visible = false;
                this.btnModify.Visible = true;

                this.txtCusId.Text = "";                
                this.txtJumin.Text = "";
                this.txtCusName.Text = "";
                this.txtAddr.Text = "";
                this.txtPhone.Text = "";
                this.txtPoint.Text = "";

                this.txtCusId.ReadOnly = true;                
                this.txtJumin.ReadOnly = true;
                this.txtCusName.ReadOnly = true;
                this.txtAddr.ReadOnly = true;
                this.txtPhone.ReadOnly = true;
                this.txtPoint.ReadOnly = true;

                this.LVcusFind.Items.Clear();

                ListViewUpdate();
            }
            else
            {
                MessageBox.Show(cusname + "님의 고객정보가 수정되지 않았습니다", "고객정보수정 오류");
                return;
            }
        }    

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string s = this.txtCusId.Text;

            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show("수정할 고객을 선택하세요");
                return;
            }
            bool isL = false;

            string currNum = this.LVcusFind.FocusedItem.Text.Trim();

            try
            {
                isL = dao.DeleteCustomer(currNum);
            }
            catch (FoundException)
            {   
                MessageBox.Show(currNum + "고객이 대여한 비디오가 있습니다");
                return;
            }

            if (isL)
            {
                MessageBox.Show("고객정보가 삭제되었습니다", "삭제완료");

                this.txtCusId.Text = "";                
                this.txtJumin.Text = "";
                this.txtCusName.Text = "";
                this.txtAddr.Text = "";
                this.txtPhone.Text = "";
                this.txtPoint.Text = "";

                this.LVcusFind.Items.Clear();
                ListViewUpdate();
            }
            else
            {
                MessageBox.Show("고객의 정보가 삭제되지 않았습니다", "삭제실패");
                return;
            }
        }

        public void ListViewUpdate()
        {
            DataSet ds;
            dao = new MFFDao();
            ds = dao.GetAllCustomer();

            ListViewItem lvi;

            foreach (DataRow r in ds.Tables["GetAllCustomer"].Rows)
            {
                lvi = new ListViewItem(r["mem_no"].ToString());
                lvi.SubItems.Add(r["mem_name"].ToString());
                lvi.SubItems.Add(r["mem_phone"].ToString());
                this.LVcusFind.Items.Add(lvi);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            string memid = this.textFindID.Text;
            string memname = this.txtFindName.Text;

            if (string.IsNullOrEmpty(memid) && string.IsNullOrEmpty(memname))
            {
                MessageBox.Show("아이디나 이름을 입력하세요", "오류");
                return;
            }

            try
            {
                ds = dao.FindCustomer(memid, memname);
            }
            catch (NotFoundException)
            {
                MessageBox.Show("찾는 고객이 없습니다");
            }

            this.LVcusFind.Items.Clear();

            ListViewItem lvi;

            foreach (DataRow r in ds.Tables["GetAllCustomer"].Rows)
            {
                lvi = new ListViewItem(r["mem_no"].ToString());
                lvi.SubItems.Add(r["mem_name"].ToString());
                lvi.SubItems.Add(r["mem_phone"].ToString());
                this.LVcusFind.Items.Add(lvi);
            }

            this.textFindID.Text = "";
            this.txtFindName.Text = "";

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LVcusFind.Items.Clear();
            ListViewUpdate();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}