using System;
using System.Drawing;//Bitmap
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
        //이미지 불러오기 
        private void btnRead_Click(object sender, EventArgs e)
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
        }//
        //이미지 저장하기
        private void btnWrite_Click(object sender, EventArgs e)
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

        private void btnMyImage_Click(object sender, EventArgs e)
        {
            string fname = this.txtRead.Text;
            try
            {
                //자신의 컴퓨터에 있는 것 가져오기
                Bitmap bitts = new Bitmap(fname, true);//색보정
                this.pictureBox1.Image = bitts;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
