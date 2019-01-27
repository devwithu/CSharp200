using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Poker
{
    public partial class frmIP : Form
    {
        public string IP = "";

        public frmIP()
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IP = txtIP.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}