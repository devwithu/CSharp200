﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Jungbo.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //-----------이곳에 초기화----------------//
            this.Clear();  //메서드호출
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
            if (string.IsNullOrEmpty(sx) || string.IsNullOrEmpty(sy))
            {
                MessageBox.Show("공백이 입력되었습니다. 다시 입력하세요.");
                this.Clear();
                throw new Exception("공백이 입력되었습니다. 다시 입력하세요.");
            }
            try
            {
                double x = double.Parse(sx.Trim());
                double y = double.Parse(sy.Trim());
                return (x + y);
            }
            catch
            {
                MessageBox.Show("숫자를 입력하세요. 다시 입력하세요.");
                this.Clear();
                throw new Exception("숫자를 입력하세요. 다시 입력하세요.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {  //Calculator를 호출할 때 문제가 발생할 수도 있다.
                double num = Calculator(this.txtNum1.Text, this.txtNum2.Text);
                this.txtResult.Text = num.ToString();
                this.lbResult.Text = "+";
            }
            catch { }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();//텍스트박스, 라벨 청소와 초기화
        }
    }
}