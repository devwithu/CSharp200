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


namespace Project123
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

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            string url = this.txtRead.Text;
            string fname = this.txtSave.Text;
            try
            {
                using (Stream stream = wf.ReadNWriteStock(url))
                {
                    if (stream == null) { stream.Close(); return; }
                    Bitmap bit = wf.StreamToBitmap(stream);
                    MessageBox.Show(bit.Size.ToString());
                    wf.SaveMemoryStream(bit, fname);
                    stream.Close();
                }
                MessageBox.Show("이미지 저장에 성공했습니다.");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
