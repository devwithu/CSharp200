using System;
using System.Drawing;//Bitmap
using System.Windows.Forms;
using System.IO;
using Com.JungBo.WIO;
namespace ReadingBitMap {
    public partial class Form1 : Form {
       
        public Form1(){
            InitializeComponent();
        }

        WebFiles wf = new WebFiles();
        //�̹��� �ҷ����� 
        private void btnRead_Click(object sender, EventArgs e){
             string url = this.txtRead.Text;
             try{
                 this.pictureBox1.Image = wf.DownloadBitmap(url);
             }
             catch (Exception){
                 MessageBox.Show("�̹����� �о���µ� �����߽��ϴ�.");
             }
        }//
        //�̹��� �����ϱ�
        private void btnWrite_Click(object sender, EventArgs e){
            string url = this.txtRead.Text;
            string fname = this.txtSave.Text;
            try{
                using (Stream stream = wf.ReadNWriteStock(url)){
                    if (stream == null) { stream.Close(); return; }
                    Bitmap bit = wf.StreamToBitmap(stream);
                    MessageBox.Show(bit.Size.ToString());
                    wf.SaveMemoryStream(bit, fname);
                    stream.Close();
                }
                MessageBox.Show("�̹��� ���忡 �����߽��ϴ�.");
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
        }

        private void btnMyImage_Click(object sender, EventArgs e){
            string fname = this.txtRead.Text;
            try{
                //�ڽ��� ��ǻ�Ϳ� �ִ� �� ��������
                Bitmap bitts = new Bitmap(fname, true);//������
                this.pictureBox1.Image = bitts;
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
        }
    }
}
