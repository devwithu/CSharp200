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

            this.Clear();

        }

        private void Clear()
        {
            this.txtNum1.Text = "";//텍스트박스 청소
            this.txtNum2.Text = "";
            this.txtResult.Text = "";
            this.lbResult.Text = "Ready";//라벨 초기화
        }
        //숫자형 문자열을 숫자로 형변환, 메서드선언
        private double Calculator(string sx, string sy)
        {
            double x = double.Parse(sx.Trim());
            double y = double.Parse(sy.Trim());
            return (x + y);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //텍스트박스에서 숫자형 문자열을 겟프로퍼티로 얻는다.
            //Calculator()이용 덧셈한다.
            //메서드 호출
            double num = Calculator(this.txtNum1.Text, this.txtNum2.Text);

            //숫자를 문자열로 형변환시킨다.
            this.txtResult.Text = num.ToString();
            this.lbResult.Text = "+";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }


    }
}
