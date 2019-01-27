using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Program002
{
    public partial class Form1 : Form
    {
        //생성자- 가장 먼저 자동 호출된다.
        public Form1() 
        {
            //각 위젯 초기화, 이곳은 건들지 말것.
            InitializeComponent();
            //-----------이곳에 초기화----------------//
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
       //btnAdd가 클릭되면 자동호출된다.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(this.txtNum1.Text);
            double num2 = double.Parse(this.txtNum2.Text);
            double num = num1 + num2;
            this.txtResult.Text = num.ToString();
            this.lbResult.Text = "+";
        }
        //btnClear가 클릭되면 자동호출된다.
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
    }
}