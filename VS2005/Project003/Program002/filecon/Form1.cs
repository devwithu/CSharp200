using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Program002{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            //-----------�̰��� �ʱ�ȭ----------------//
            this.Clear();  //�޼���ȣ��
        }
        //�ݺ��Ǵ� ������ �޼���� �����.
        //�ؽ�Ʈ�� �� �ʱ�ȭ, �޼��弱��
        private void Clear(){
            this.txtNum1.Text = "";//�ؽ�Ʈ�ڽ� û��
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";//�� �ʱ�ȭ
        }
        //������ ���ڿ��� ���ڷ� ����ȯ, �޼��弱��
        private double Calculator(string sx, string sy){
            double x  = double.Parse(sx.Trim());
            double y = double.Parse(sy.Trim());
            return (x + y);
        }
        private void btnAdd_Click(object sender, EventArgs e){
            //�ؽ�Ʈ�ڽ����� ������ ���ڿ��� ��������Ƽ�� ��´�.
            //Calculator()�̿� �����Ѵ�.
            //�޼��� ȣ��
            double num = Calculator(this.txtNum1.Text, this.txtNum2.Text);

            //���ڸ� ���ڿ��� ����ȯ��Ų��.
            this.txtResult.Text = num.ToString();
            this.lbResult.Text = "+";
        }
        private void btnClear_Click(object sender, EventArgs e){
            this.Clear();//�ؽ�Ʈ�ڽ�, �� û�ҿ� �ʱ�ȭ
        }
    }
}