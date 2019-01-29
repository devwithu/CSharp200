using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(this.txtNum1.Text);
            double num2 = double.Parse(this.txtNum2.Text);
            double num = num1 + num2;
            this.txtResult.Text = num.ToString();
            this.lbResult.Text = "+";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
    }
}
