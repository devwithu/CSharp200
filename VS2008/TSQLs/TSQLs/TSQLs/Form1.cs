using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSQLs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.studentDataSet.Student);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            string name = this.txtName.Text;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(address))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            int count = 0;
            try
            {
                count = studentTableAdapter.InsertQuery(
                    id, name, phone, address);
                this.studentTableAdapter.Fill(this.studentDataSet.Student);
                MessageBox.Show("성공적으로 학생을 추가 했습니다.");
            }
            catch
            {
                MessageBox.Show("학생추가에 실패했습니다.");
            }
        }
    }
}
