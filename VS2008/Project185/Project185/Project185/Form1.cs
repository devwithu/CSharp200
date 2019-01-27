using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.JungBo.Game;
namespace Project185
{
    public partial class Form1 : Form
    {
        string ballstr = " Play Ball!!";
        Pitcher pit = new Pitcher();
        Hitter hit = new Hitter();
        Empire emp = new Empire();
        int[] num = new int[3];
        int count = 0;//세 번호
        int gameiter = 1;//10번 이내에 3스트라이크
        public Form1()
        {
            InitializeComponent();
            BtnVisible(false);
            NewGame(true);
        }
        private void NewGame(bool b)
        {
            this.lbResult.Text = ballstr;
            this.btnHitting.Visible = !b;
            this.btnNewGame.Visible = b;
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.txtBallLists.Clear();//심판 판정 리스트 지우기
            pit.ReMake();//투수 공 던지기
            emp.Pit = pit.Ball;//심판에게 투수 공 저장
            this.lbResult.Text = ballstr;
            BaseBallUtil.Fill(num, -1); //-1로 초기화
            BtnVisible(true);//버는 모두 보이기 0~9
            NewGame(false); //
            gameiter = 1;
            count = 0;
        }
        private void btnHitting_Click(object sender, EventArgs e)
        {
            hit.MakeNum(num);//타자가 공을 친다.
            emp.Hit = hit.Ball;//심판에서 타자공 저장
            if (gameiter < 10)
            {
                if (emp.Strike() == 3)
                {
                    MessageBox.Show("You Win");
                    NewGame(true);
                }
                else
                {
                    string ballres = string.Format("[{0}Strike - {1}Ball]"
               , emp.Strike(), emp.Ball());
                    string youhit = string.Format("[{0}-{1}-{2}]"
               , hit.Ball[0], hit.Ball[1], hit.Ball[2]);
                    this.txtBallLists.AppendText(string.Format("{0}번{1} :",
                        gameiter, youhit) + ballres + "\n");
                    this.lbResult.Text = ballres;
                    gameiter++;
                }
            }
            else
            {
                MessageBox.Show("You Lose");
                NewGame(true);
                lbResult.Text = string.Format("Pitcher Ball: [{0}-{1}-{2}]"
                    , pit.Ball[0], pit.Ball[1], pit.Ball[2]);
            }
            count = 0;
            BtnVisible(true);
        }
        private int ToNum(string msg)
        {
            return int.Parse(msg.Substring(msg.Length - 1));
        }
        private void SetNums(int number, Button btn)
        {
            if (count == 0)
            {
                num[0] = number;
                btn.Visible = false;
            }
            else if (count == 1)
            {
                num[1] = number;
                btn.Visible = false;
            }
            else if (count == 2)
            {
                num[2] = number;
                btn.Visible = false;
            }
            count++;
        }
        private void BtnVisible(bool b)
        {
            btn0.Visible = b;
            btn1.Visible = b;
            btn2.Visible = b;
            btn3.Visible = b;
            btn4.Visible = b;
            btn5.Visible = b;
            btn6.Visible = b;
            btn7.Visible = b;
            btn8.Visible = b;
            btn9.Visible = b;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (sender as Button == btn1)
            {
                SetNums(ToNum(this.btn1.Text), this.btn1);
            }
            else if (sender as Button == btn2)
            {
                SetNums(ToNum(this.btn2.Text), this.btn2);
            }
            else if (sender as Button == btn3)
            {
                SetNums(ToNum(this.btn3.Text), this.btn3);
            }
            else if (sender as Button == btn4)
            {
                SetNums(ToNum(this.btn4.Text), this.btn4);
            }
            else if (sender as Button == btn5)
            {
                SetNums(ToNum(this.btn5.Text), this.btn5);
            }
            else if (sender as Button == btn6)
            {
                SetNums(ToNum(this.btn6.Text), this.btn6);
            }
            else if (sender as Button == btn7)
            {
                SetNums(ToNum(this.btn7.Text), this.btn7);
            }
            else if (sender as Button == btn8)
            {
                SetNums(ToNum(this.btn8.Text), this.btn8);
            }
            else if (sender as Button == btn9)
            {
                SetNums(ToNum(this.btn9.Text), this.btn9);
            }
            else if (sender as Button == btn0)
            {
                SetNums(ToNum(this.btn0.Text), this.btn0);
            }
        }
    }
}