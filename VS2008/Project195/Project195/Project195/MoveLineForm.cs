using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project195
{
    public partial class MoveLineForm : Form {
        public MoveLineForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sLine = this.txtLine.Text;
            if (!string.IsNullOrEmpty(sLine))
            {
                Form1 mainForm = (Form1)(this.Owner);
                try
                {
                    int lines = int.Parse(sLine.Trim());
                    mainForm.MoveToWantedLine(lines);
                  
                    mainForm.Update();
                }
                catch 
                {
                    MessageBox.Show("양의 정수를 입력하세요");
                    return;
                }
            }
            else {
                MessageBox.Show("공백을 입력했습니다. 다시입력하세요.");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}