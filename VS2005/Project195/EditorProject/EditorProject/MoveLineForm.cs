using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EditorProject {
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
                    MessageBox.Show("���� ������ �Է��ϼ���");
                    return;
                }
            }
            else {
                MessageBox.Show("������ �Է��߽��ϴ�. �ٽ��Է��ϼ���.");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}