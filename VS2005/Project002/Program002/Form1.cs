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
        //������- ���� ���� �ڵ� ȣ��ȴ�.
        public Form1() 
        {
            //�� ���� �ʱ�ȭ, �̰��� �ǵ��� ����.
            InitializeComponent();
            //-----------�̰��� �ʱ�ȭ----------------//
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
       //btnAdd�� Ŭ���Ǹ� �ڵ�ȣ��ȴ�.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(this.txtNum1.Text);
            double num2 = double.Parse(this.txtNum2.Text);
            double num = num1 + num2;
            this.txtResult.Text = num.ToString();
            this.lbResult.Text = "+";
        }
        //btnClear�� Ŭ���Ǹ� �ڵ�ȣ��ȴ�.
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
    }
}