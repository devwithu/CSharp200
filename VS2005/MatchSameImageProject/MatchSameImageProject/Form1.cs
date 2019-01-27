using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatchSameImageProject
{
    public partial class Form1 : Form
    {
        //멤버필드 선언---------------------
        MButton[] mm;
        MButton tempB;  //첫번째 버튼을 받아둔다.
        int current = 0;  //첫번째 버튼인가 두번째 버튼인가
        int times = 0;    //정해진 시간을 체크하기위해
        int iters = 0;    //정해진 개수를 맞추면
        int nums = 12; //버튼개수 12,16,20,24
        int row = 3;     //게임줄 수 3,4,5,6
        int col = 4;     //칼럼수 여기서는 4로 고정
        int clicktimes = 0;//누른 회수 2번이 1번 클릭
        int speeding = 3000;//그림 뒤집는 속도
        //------------------------------------------------   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.startLb.Visible = true;
            this.게임시작SToolStripMenuItem.Enabled = true;
            this.게임GToolStripMenuItem.Enabled = false;
            this.Size = new System.Drawing.Size(620, 140);
            this.button2.Enabled = false;
        }

        private void 새게임NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.게임GToolStripMenuItem.Enabled = true;
            //this.게임시작SToolStripMenuItem.Enabled = false;
            this.새게임NToolStripMenuItem.Enabled = false;
            this.startLb.Visible = false;
            this.Size= new System.Drawing.Size(620, 500);
            this.Update();
        }
       
        private void MenuDo(int num)
        {
            TimerStart();
            nums = num;
            this.panel1.Controls.Clear();
            MButtonShow(nums);
            this.button2.Enabled = true;
            this.clicktimes = 0;
            this.label2.Text = "0 times.";
            this.speeding = speeding / (nums/col);
        }//
        private void MButtonShow(int num)
        {
            this.iters = 0;  //  정해진개수 초기화
            this.mm = new MButton[num];   //정해진 버튼 개수 선언
            this.times = 0;  //정해진 시간 초기화
            this.row = mm.Length / col;    //4 : 버튼 4개씩 몇줄
            //int col = 4;  // 버튼4개
            ImageArray im = new ImageArray(num);
            int[] aa = im.Getindex();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int x = 30 + 55 * j;
                    int y = 5 + 55 * i;
                    mm[i * col + j] = new MButton(x, y, aa[i * col + j]);
                    mm[i * col + j].MouseUp 
                        += new MouseEventHandler(this.button1_MouseUp);
                    mm[i * col + j].MouseDown 
                        += new MouseEventHandler(this.button1_MouseDown);
                    this.panel1.Controls.Add(mm[i * col + j]);
                }
            }
        }//
        private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            clicktimes++;
            this.label2.Text = (clicktimes/2).ToString() + " times.";
            //MessageBox.Show(sender.ToString());
            //int col = 4;  // 버튼4개
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mm[i * col + j] == (MButton)sender)
                    { //버튼눌렸냐
                        if (!mm[i * col + j].AmIEnd)
                        {//뒷면(원위치)
                            if (this.current == 0)  //첫버튼
                            {
                                mm[i * col + j].Flops();   //뒤집어 앞으로
                                mm[i * col + j].AmIEnd = true;//앞으로 
                                this.tempB = mm[i * col + j];  //임시버튼에 첫 버튼을 할당 나중에 비교위해
                                this.current++;      //첫버튼일때 시행됬다.
                                return;
                            }
                            else
                            {  //두번째 버튼
                                mm[i * col + j].Flops();   //뒤집어 앞으로
                                mm[i * col + j].AmIEnd = true;//앞으로 
                                //this.tempB=mm[i*4+j];  //임시버튼에 첫 버튼을 할당 나중에 비교위해
                                this.current++;      //두번째버튼일때 시행됬다.
                                return;
                            }//else
                        }
                        else if (mm[i * col + j].AmIEnd)  //뒤집혀 앞면상태라면 그대로 나두자
                        {
                            return;
                        }
                    }//if
                }
            }
           
        }

        private void button1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            //int col = 4;  //4개 기준
            //row 멤버
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((MButton)sender == mm[i * 4 + j])
                    { //버튼 놓았냐?
                        if (mm[i * col + j].AmIEnd && this.current == 1)  //첫버튼
                        {
                            return;
                        }
                        else if (mm[i * col + j].AmIEnd && this.current >= 2)  //두버튼
                        {
                            if (mm[i * col + j].MyNum == this.tempB.MyNum)
                            {  //첫버튼과 두번째 버튼값이 같은가?
                                mm[i * col + j].AmIEnd = true;
                                tempB.AmIEnd = true;
                                this.current = 0;
                                this.iters += 2;
                            }//if
                            else if (mm[i * col + j].MyNum != this.tempB.MyNum)
                            {  //첫버튼과 두번째 버튼값이 같은가?
                                lock (this)
                                {
                                    System.Threading.Thread.Sleep(speeding);
                                    mm[i * col + j].Flips();       //윈위치
                                    mm[i * col + j].AmIEnd = false;  //나 선택안됨
                                    tempB.Flips();           //워위치
                                    tempB.AmIEnd = false;      //나 선택안됨
                                    this.current = 0;
                                }
                            }
                        }//else if
                    }//if 1
                }//for 2
            }//for 1
        }

      
        private void TimerStart()
        {
            this.timer1.Enabled = true;

        }//
        private void TimerStop()
        {
            this.timer1.Enabled = false;
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mm[i * col + j].Flops();
                }
            }
            this.timer2.Enabled = true;
            this.times+=15;//한번의 찬스는 15초를 사용합니다.
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (this.row * 10 < this.times)
            {
                this.TimerStop();
                times = 0;
                this.button2.Enabled = false;
                MessageBox.Show("You Lose");
                return;
            }
            else
            {
                if (this.iters >= this.nums)
                {
                    this.TimerStop();
                    times = 0;
                    this.button2.Enabled = false;
                    MessageBox.Show("You Win");
                    return;
                }
            }
            this.statusStrip1.Items[0].Text = this.times.ToString() + "초 경과";
            this.times++;
        }//
        private void timer2_Tick(object sender, System.EventArgs e)
        {
            //int col = 4;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!mm[i * col + j].AmIEnd)
                    {
                        mm[i * col + j].Flips();
                    }
                }
            }
            this.timer2.Enabled = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            row = 3;
            MenuDo(col * row);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            row = 4;
            MenuDo(col * row);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            row = 5;
            MenuDo(col * row);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            row = 6;
            MenuDo(col * row);
        }

        private void 게임끝XToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("끝내시겠습니까?", "End", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (results == DialogResult.Yes)
            {
                MessageBox.Show("안녕히 계십시오.");
                this.Dispose();
                this.Close();

            }
        }
    }
}