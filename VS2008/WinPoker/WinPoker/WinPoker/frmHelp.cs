using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
            label1.Text = "2인용 포커 게임 Ver " + Application.ProductVersion.ToString() + "\n\n";
            label1.Text += "만든이: 최우인 (카드로직),";
            label1.Text += "          윤창기 (소켓, UI)\n\n";
            label1.Text += "제작기간: 070703~070710";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}