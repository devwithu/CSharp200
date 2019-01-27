using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Program002
{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            //-----------�̰��� �ʱ�ȭ----------------//
            this.Clear();  //�޼���ȣ��
        }
        private void Clear(){
            this.txtNum1.Text = "";//�ؽ�Ʈ�ڽ� û��
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";//�� �ʱ�ȭ
        }
        //������ ���ڿ��� ���ڷ� ����ȯ, �޼��弱��
        private double Calculator(string sx, string sy){
            if (string.IsNullOrEmpty(sx) || string.IsNullOrEmpty(sy)){
                MessageBox.Show("������ �ԷµǾ����ϴ�. �ٽ� �Է��ϼ���.");
                this.Clear();
                throw new Exception("������ �ԷµǾ����ϴ�. �ٽ� �Է��ϼ���.");
            }
            try{
                double x = double.Parse(sx.Trim());
                double y = double.Parse(sy.Trim());
                return ( x + y);
            }
            catch{
                MessageBox.Show("���ڸ� �Է��ϼ���. �ٽ� �Է��ϼ���.");
                this.Clear();
                throw new Exception("���ڸ� �Է��ϼ���. �ٽ� �Է��ϼ���.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e){
            try{  //Calculator�� ȣ���� �� ������ �߻��� ���� �ִ�.
                double num=Calculator(this.txtNum1.Text, this.txtNum2.Text);
                this.txtResult.Text = num.ToString();
                this.lbResult.Text = "+";
            }
            catch { }
        }
        private void btnClear_Click(object sender, EventArgs e){
            this.Clear();//�ؽ�Ʈ�ڽ�, �� û�ҿ� �ʱ�ȭ
        }
    }
}