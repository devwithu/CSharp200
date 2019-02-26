using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Com.JungBo.WIO;


namespace Project122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebFiles wf = new WebFiles();

        private void BtnRead_Click(object sender, EventArgs e)
        {
            string url = this.txtRead.Text;
            try
            {
                this.pictureBox1.Image = wf.DownloadBitmap(url);
            }
            catch (Exception)
            {
                MessageBox.Show("이미지를 읽어오는데 실패했습니다.");
            }
        }
    }
}
