using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Matrix2to1;
using Win16Tiles;
namespace SixTeenWindows
{
    public partial class Form1 : Form
    {
        //---------------------------------
        const int maxtimes = 60 * 10;
        SButton[] sb;
        SButton temp;
        int times = 0;
        int iters = 16;
        bool isSame = false;
        int clicks = 0;
        //---------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        private void stBtn_Click(object sender, EventArgs e)
        {
            this.times = 0;
            clicks = 0;
            isSame = false;
            this.timer1.Enabled = true;
            this.stBtn.Enabled = false;
            this.btnNew.Enabled = true;
            MButtonShow(16);
            

        }
        private void MButtonShow(int num)
        {
            this.label1.Text = "";
            this.panel1.Controls.Clear();
            sb = new SButton[num];
            int col = 4;
            int row = 4;
            
            Lotto l = new Lotto(num);
            int[] aa = l.Ball();

            int[,] m = MatrixTrans.Mat1to2(aa, row, row);
     
            SixTeenInvert siv = new SixTeenInvert(m);
            siv.InvertNumbers();
            //Console.WriteLine(siv.InverNum);
            //Console.WriteLine(siv.ZeroRow());

            if ((row + siv.InverNum + siv.ZeroRow()) % 2 == 0)
            {
                MessageBox.Show(string.Format("Click Again - Impossible 15 puzzle invert nums.  \n {0} rows {1} invert nums {2} zero row",
                    row, siv.InverNum, siv.ZeroRow()));
                this.stBtn.Enabled = true;
                this.btnNew.Enabled = false;
                return;
            }
            else {
                this.lbInvert.Text = string.Format("Possible 15 puzzle invert nums.  \n {0} rows {1} invert nums {2} zero row",
                    row, siv.InverNum, siv.ZeroRow());
                this.stBtn.Enabled = false;
                this.btnNew.Enabled = true;
            }


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int x = 50 + 50 * j;
                    int y = 20 + 50 * i;
                    sb[i * 4 + j] = new SButton(x, y, aa[i * 4 + j]);//SButton 생성
                    sb[i * 4 + j].MouseDown += new MouseEventHandler(this.button1_MouseDown); //이벤트생성
                    sb[i * 4 + j].MouseUp += new MouseEventHandler(this.button1_MouseUp);//이벤트생성
                    if (sb[i * 4 + j].MyNum == 0)
                    {  //15는 숫자를 
                        temp = sb[i * 4 + j];
                        temp.MyNum = 0;
                    }
                    this.panel1.Controls.Add(sb[i * 4 + j]);

                }
            }

        }//
        private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            int col = 4;
            int row = 4;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((SButton)sender == sb[i * 4 + j])
                    {
                        if (sb[i * 4 + j].Length(temp) < 52)
                        {
                            int tempa = sb[i * 4 + j].MyNum;
                            int tempb = temp.MyNum;
                            SButton sstemp = sb[i * 4 + j];
                            sb[i * 4 + j] = temp;
                            temp = sstemp;
                            sb[i * 4 + j].MyNum = tempa;
                            temp.MyNum = 0;
                            sb[i * 4 + j].Flips();
                            temp.Flips();
                        }//if
                        //}//if
                    }//if

                }//for
            }//for
            
            this.lbTimes.Text = clicks.ToString();
            clicks++;
        }//
        private void button1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int col = 4;
            int row = 4;
            //	this.panel1.Controls.Clear();
            int[] rta = new int[16];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (this.panel1.Controls[4 * i + j] is SButton)
                    {
                        rta[4 * i + j] = ((SButton)this.panel1.Controls[4 * i + j]).MyNum;
                    }

                }//for
            }//for
            //MessageBox.Show(sst);
            bool tije = false;
            string sst = "";
            //			if(rta[0]==0 && rta[1]==1){
            //				MessageBox.Show("sdfsfsadassda");
            //			}
            for (int i = 0; i < iters-1; i++)
            //		    for(int i=0;i<rta.Length;i++)
            {
                sst += rta[i] + "  ";
                if ((i + 1) == rta[i])
                {
                    tije = true;

                }
                else
                {
                    tije = false;
                    break;
                }
            }
            isSame = tije;
            this.label1.Text = sst;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (times <= maxtimes)
            {
                if (isSame == true)
                {
                    this.timer1.Enabled = false;
                    MessageBox.Show("You Win");
                    TruInit();
                    return;
                }

            }
            else if (times > maxtimes)
            {
                this.timer1.Enabled = false;
                MessageBox.Show("You Lose");
                times = 0;
                TruInit();
                return;
            }
            
            this.lbSeconds.Text = times.ToString();
            times++;
        }//

        private void TruInit()
        {
            this.stBtn.Enabled = true;
            this.lbInvert.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.times = 0;
            clicks = 0;
            isSame = false;
            this.timer1.Enabled = true;
            this.stBtn.Enabled = true;
            this.btnNew.Enabled = false;
            MButtonShow(16);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnNew.Enabled = false;
            
        }

        
    }
}