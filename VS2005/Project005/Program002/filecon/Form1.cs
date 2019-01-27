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
            //-----------이곳에 초기화----------------//
            this.Clear();
        }
        private void Clear() {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";
        }
        private void btnAdd_Click(object sender, EventArgs e){
            try{ //Calculator를 호출할 때 문제가 발생할 수도 있다.
                //Calculator 파라메터에 사칙연산 중 어떤 연산인지 알리는 문자열포함
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "+").ToString();
                this.lbResult.Text = "+";//덧셈
            } catch { }//특별히 할 일이 없다.
        }
        private void btnMinus_Click(object sender, EventArgs e){
            try{
                this.txtResult.Text =
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "-").ToString();
                this.lbResult.Text = "-";//뺄셈
            }catch { }
        }
        private void btnMulti_Click(object sender, EventArgs e) {
            try{
                this.txtResult.Text = 
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "x").ToString();
                this.lbResult.Text = "x";//곱셈
            }catch { }
        }
        private void btnDivide_Click(object sender, EventArgs e){
            try{
                this.txtResult.Text = 
                    Calculator(this.txtNum1.Text, this.txtNum2.Text, "/").ToString();
                this.lbResult.Text = "/";//나눗셈
            }catch { }
        }
        private void btnClear_Click(object sender, EventArgs e){
            this.Clear();//청소
        }
        //string opp 사칙연산 중 어떤 연산인지 알리는 문자열포함
        public double Calculator(string sx, string sy,string opp){
            if (string.IsNullOrEmpty(sx) || string.IsNullOrEmpty(sy)) {
                MessageBox.Show("공백이 입력되었습니다. 다시 입력하세요.");
                this.Clear();
                throw new Exception("공백이 입력되었습니다. 다시 입력하세요.");
            }      
            try{
                double x = double.Parse(sx.Trim());
                double y = double.Parse(sy.Trim());
                double z = 0.0;//사칙연산결과를 저장할 임수 변수

                //사칙연산이 어떤 것인가 판별
                switch(opp){  
                    case "+": z = x + y; break;
                    case "-": z = x - y; break;
                    case "x": z = x * y; break;
                    case "/": z = x / y; break;
                }
                return z;//사칙연산에 알맞은 값을 리턴한다.
            }
            catch (Exception){
                MessageBox.Show("숫자를 입력하세요. 다시 입력하세요.");
                this.Clear();
                throw new Exception("숫자를 입력하세요. 다시 입력하세요.");
            }
        }
    }
}