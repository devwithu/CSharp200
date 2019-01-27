using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkTest
{
    public partial class Form1 : Form
    {

        //Student st = new Student();
        StudentDataContext stdb = new StudentDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox2.Text = (from c in stdb.Student
                                      where c.Student_ID == this.textBox1.Text
                                      select c.Student_Name).Single().ToString();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//
          //  this.dataGridView1.DataSource=
           List<Student> sts=     (from c in stdb.Student
                                // 0 where c.Student_ID == "kingkong"
                                  select c).ToList();//.Student_Name
           
           this.dataGridView1.DataSource = sts;
            

        }
    }
}
