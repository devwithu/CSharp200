using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDao dao = new LoginDao();

            string id = this.txtID.Text.Trim();
            string passwd = this.txtPasswd.Text.Trim();
            bool isL=false;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(passwd))
            {
                MessageBox.Show("아이디나 비밀번호는 반드시 입력 해야함");
                this.txtID.Text = "";
                this.txtPasswd.Text = "";
                this.txtID.Focus();
                return;
            }
            
            isL = dao.Login(id, passwd);

            if (isL)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디가 없거나 비밀번호가 틀렸습니다");
                this.txtID.Text = "";
                this.txtPasswd.Text = "";
                this.txtID.Focus();
            }

        }
    }
}