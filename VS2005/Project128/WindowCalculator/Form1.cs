using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowCalculator{
    public partial class Form1 : Form{

        WSMiniCalc.Service cal;

        public Form1(){
            InitializeComponent();
            //-----------�̰��� �ʱ�ȭ----------------//
            try{
                cal = new WSMiniCalc.Service();
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
            this.Clear();
        }
        private void Clear(){
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            try{
                //Calculator�� ȣ���� �� ������ �߻��� ���� �ִ�.
                //Calculator �Ķ���Ϳ� ��Ģ���� �� � �������� �˸��� ���ڿ�����
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "+").ToString();
                this.lbResult.Text = "+";//����
            }
            catch { }//Ư���� �� ���� ����.
        }
        private void btnMinus_Click(object sender, EventArgs e){
            try{
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "-").ToString();
                this.lbResult.Text = "-";//����
            }
            catch { }
        }
        private void btnMulti_Click(object sender, EventArgs e){
            try{
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "x").ToString();
                this.lbResult.Text = "x";//����
            }
            catch { }
        }
        private void btnDivide_Click(object sender, EventArgs e) {
            try{
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "/").ToString();
                this.lbResult.Text = "/";//������
            }
            catch { }
        }
        private void btnClear_Click(object sender, EventArgs e) {
            this.Clear();//û��
        }
        //string opp ��Ģ���� �� � �������� �˸��� ���ڿ�����
        public double Calculator(string sx, string sy, string opp){
            if (string.IsNullOrEmpty(sx) || string.IsNullOrEmpty(sy)) {
                MessageBox.Show("������ �ԷµǾ����ϴ�. �ٽ� �Է��ϼ���.");
                this.Clear();
                throw new Exception("������ �ԷµǾ����ϴ�. �ٽ� �Է��ϼ���.");
            }      
            try{
                double x = double.Parse(sx.Trim());
                double y = double.Parse(sy.Trim());
                return cal.Calculator(x,y,opp);
            }
            catch (Exception){
                MessageBox.Show("���ڸ� �Է��ϼ���. �ٽ� �Է��ϼ���.");
                this.Clear();
                throw new Exception("���ڸ� �Է��ϼ���. �ٽ� �Է��ϼ���.");
            }
        }
    }
}