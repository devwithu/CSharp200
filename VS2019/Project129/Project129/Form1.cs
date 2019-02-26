using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project129
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Fill(this.sTUDENTDATABASEDataSet.Student);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sTUDENTDATABASEDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.sTUDENTDATABASEDataSet.Student);

        }
    }
}
