using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PUBSQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sql = this.textBox1.Text;
            try
            {
                bindingSource1.DataSource = SelectQuery(sql).Tables[0]; ;
                this.dataGridView1.DataSource = bindingSource1.DataSource;
                //this.dataGridView1.Update();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
               
            }
           
        }
        //select * from titles
        public DataSet SelectQuery(string sql) {
            //DataSet ds = new DataSet();
            ds.Clear();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ConnString);
            ad.Fill(ds);
            return ds;
        }//
        public string ConnString {
            get{
                return @"Data Source=.\SQLEXPRESS;Initial Catalog=PUBS;Integrated Security=True;Pooling=False";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //this.bindingNavigator1.BindingSource = this.bindingSource1;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.dataGridView1.CurrentRow.Index.ToString());
            try
            {
                
            }
            catch (Exception)
            {
                
              
            }
        }

        //private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        //{
            
        //    //MessageBox.Show("james");
        //    if (this.bindingSource1.Position + 1 < this.bindingSource1.Count)
        //    {
        //        //this.bindingSource1.MoveNext();
        //    }
        //    else
        //    {
        //        //this.bindingSource1.MoveFirst();
        //    }
        //}

        //private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        //{
        //    if (this.bindingSource1.Position - 1 < 0)
        //    {
        //        //this.bindingSource1.MovePrevious();
        //    }
        //    else
        //    {
        //        //this.bindingSource1.MoveLast();
        //    }
        //}

        //private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        //{
        //    //this.bindingSource1.MoveFirst();
        //}

        //private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        //{
        //    //this.bindingSource1.MoveLast();
        //}

    
    }
}
