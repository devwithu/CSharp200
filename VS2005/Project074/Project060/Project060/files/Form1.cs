using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.JungBo.Logic; //InstallmentSavings
namespace Project060{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e){
            //decimal->double
            double a = (double)this.nudAmount.Value; 
            double r = (double)this.nudRate.Value;
            //decimal->int
            int n = (int)this.nudYear.Value;

            double values = InstallmentSavings.Savings(a, r, n);

            this.lbResult.Text = "" + ((int)values + 5) / 10 * 10;
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.nudAmount.Value = (decimal)200000;
            this.nudRate.Value = 4.5M;//decimal¿∫ M
            this.nudYear.Value = 2M;
            this.lbResult.Text = "";
            byte a = 10;
            byte b = 20;
            byte c = 10 + 20;
            byte d = a+b;
        }

    }
}