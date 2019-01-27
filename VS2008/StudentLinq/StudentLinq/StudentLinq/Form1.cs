using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentLinq
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //linq 사용을 위한 컨텍스트 연결
        StudentDataContext stdb = new StudentDataContext();

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            IEnumerable<Student> sts= (from c in stdb.Student
                                 select c).ToList();

            this.dataGridView1.DataSource = sts;
        }

        private void btnShowAll2_Click(object sender, EventArgs e)
        {

            List<Student> sts = (from c in stdb.Student

                                 select c).ToList();
            this.dataGridView1.DataSource = sts;
        }

        private void btnShowAll3_Click(object sender, EventArgs e)
        {
            
            var sts = (from c in stdb.Student
                                 select c).ToList();

            this.dataGridView1.DataSource = sts;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> sts = (from c in stdb.Student
                                     select c.Student_ID).ToList();

                this.comboBox1.DataSource = sts;
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = this.comboBox1.SelectedItem as string;
                Student st = (from c in stdb.Student
                              where c.Student_ID == id.Trim()
                              select c).Single<Student>();
                this.textBox1.Text = st.Student_Name;
                this.textBox2.Text = st.Student_Phone;
                this.textBox3.Text = st.Student_Address;
                this.textBox4.Text = st.Student_InDate.ToString();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        private void btnId_Click(object sender, EventArgs e)
        {
            var sts = (from c in stdb.Student
                       where c.Student_ID == this.textBox5.Text.Trim()
                       select c).ToList();

            this.dataGridView1.DataSource = sts;
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox6.Text = (from c in stdb.Student
                                      where c.Student_ID == this.textBox5.Text
                                      select c.Student_Name).Single().ToString();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
    }
}