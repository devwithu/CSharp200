using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace WinBlackJack
{
    public partial class Form1 : Form
    {
        static public int betting;
        public BlackJack bj;
        private bool bDealerScoreShow = false;

        public Form1()
        {
            InitializeComponent();
            bj = new BlackJack(1);
            Ready();
            IconInit();
            labelLose.Location = new Point(this.Size.Width / 2 - labelLose.Size.Width / 2, ((panelDeal.Location.Y + panelDeal.Size.Height + panelPlay.Location.Y) / 2) - (labelLose.Size.Height / 2));
            labelPush.Location = new Point(this.Size.Width / 2 - labelPush.Size.Width / 2, ((panelDeal.Location.Y + panelDeal.Size.Height + panelPlay.Location.Y) / 2) - (labelPush.Size.Height / 2));
            labelWin.Location = new Point(this.Size.Width / 2 - labelWin.Size.Width / 2, ((panelDeal.Location.Y + panelDeal.Size.Height + panelPlay.Location.Y) / 2) - (labelWin.Size.Height / 2));
        }

        private void 새게임ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ready();
            IconInit();
            labelWin.Visible = false;
            labelPush.Visible = false;
            labelLose.Visible = false;
            lblinit.Visible = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("게임을 종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Init())
            {
                Start();
            }
        }

        private void buttonBetting_Click(object sender, EventArgs e)
        {
            if (Init())
            {
                Start();
            }
        }

        private void buttonDouble_Click(object sender, EventArgs e)
        {
            buttonDouble.Enabled = false;
            if (bj.players[0].Cash < bj.players[0].BetCash)
            {
                MessageBox.Show("잔액보다 큰 수를 배팅 할 수 없습니다.", "배팅 금 Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                bj.bettingCash += bj.players[0].BetCash;
                bj.players[0].Cash -= bj.players[0].BetCash;
                bj.players[0].BetCash *= 2;
            }

            bj.players[0].BringOneCard(bj.dealer.PutCard());
            txtBetting.Text = bj.players[0].BetCash.ToString();
            bj.cmdState = CMDSTATE.NORMAL;
            DealerCardGet();
            ShowStatus();
            CheckCurrentState();
        }

        private void buttonHit_Click(object sender, EventArgs e)
        {
            buttonDouble.Enabled = false;
            bj.players[0].BringOneCard(bj.dealer.PutCard());
            bj.cmdState = CMDSTATE.NORMAL;
            DealerCardGet();
            ShowStatus();
            CheckCurrentState();
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            bj.cmdState = CMDSTATE.FIRSTDEAL;
            buttonDouble.Enabled = false;
            DealerCardGet();
            ShowStatus();
            if (CheckCurrentState())
            {
                return;
            }
            GameEndProc();
        }

        private void Ready()
        {
            bj.Ready();
        }

        private bool Init()
        {
            lblinit.Visible = false;
            labelWin.Visible = false;
            labelPush.Visible = false;
            labelLose.Visible = false;
            panelDeal.Controls.Clear();
            panelPlay.Controls.Clear();
            txtDealerScore.Text = string.Empty;
            txtPlayerScore.Text = string.Empty;
            buttonDouble.Enabled = true;
            buttonHit.Enabled = true;
            buttonStand.Enabled = true;
            buttonBetting.Enabled = false;
            시작ToolStripMenuItem.Enabled = false;

            if (!txtBetting.Text.ToString().Equals(string.Empty))
            {
                try
                {
                    betting = int.Parse(txtBetting.Text.ToString());
                    if (betting <= 0)
                    {
                        MessageBox.Show("음수는 입력 할 수 없습니다!", "입력 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        IconInit();
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("다음 부터 숫자를 입력하세요!", "입력 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IconInit();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("배팅금액을 입력하세요!", "입력 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IconInit();
                return false;
                //betting = 100;
                //txtBetting.Text = betting.ToString();
            }
            return true;
        }

        private void IconInit()
        {
            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonDouble.Enabled = false;
            buttonBetting.Enabled = true;
            시작ToolStripMenuItem.Enabled = true;
            panelDeal.Controls.Clear();
            panelPlay.Controls.Clear();
            txtCash.Text = bj.players[0].Cash.ToString();
            txtDealerScore.Text = string.Empty;
            txtPlayerScore.Text = string.Empty;
            txtBetting.Text = string.Empty;
            labelWin.Visible = false;
            labelPush.Visible = false;
            labelLose.Visible = false;
            txtBetting.Focus();
        }

        private void Start()
        {
            bj.ReSetGame();
            bj.ReSetGamer(bj.allGamer.ToArray());
            txtCash.Text = bj.players[0].Cash.ToString();

            foreach (Player p in bj.players)
            {
                if (!bj.Betting(p))
                {
                    IconInit();
                    return;
                }
            }

            for (int n = 0; n < 2; n++)
            {
                foreach (Player p in bj.players)
                    p.BringOneCard(bj.dealer.PutCard());
                bj.dealer.BringOneCard(bj.dealer.PutCard());
            }

            bDealerScoreShow = false;
            ShowStatus();

            foreach (Gamer g in bj.allGamer)
            {
                bj.CheckCurrentState(g);

                if (g.State == STATE.BJ)
                {
                    GameEndProc();
                    return;
                }
            }
        }

        public void ShowStatus()
        {
            foreach (Gamer g in bj.allGamer)
            {
                PrintInfo(g);
            }
        }

        public bool DealerCardGet()
        {
            if (!(bj.nPlayer == 1 && bj.players[0].State == STATE.BUST))
            {
                if (bj.dealer.Score < 17)
                {
                    bj.dealer.BringOneCard(bj.dealer.PutCard());
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckCurrentState()
        {
            foreach (Gamer g in bj.allGamer)
            {
                bj.CheckCurrentState(g);
            }
            foreach (Gamer g in bj.allGamer)
            {
                if (CheckCurrentState(g))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckCurrentState(Gamer p)
        {
            bool isch = false;
            if (p.State == STATE.BJ || p.State == STATE.BUST)
            {
                bj.cmdState = CMDSTATE.FIRSTDEAL;
                GameEndProc();
                isch = true;
            }
            return isch;
        }

        public void PrintInfo(Player p)
        {
            PrintInfo((Gamer)p);
        }

        public void PrintInfo(Gamer g)
        {
            int i = 0;
            int sizeW = 0;
            bool check = false;

            List<PictureBox> pictureBox = new List<PictureBox>();
            pictureBox.Clear();
            foreach (Card card in g.curCardList)
            {
                pictureBox.Add(new PictureBox());

                pictureBox[i].Name = "pictureBox0" + i.ToString();
                pictureBox[i].Size = card.image.Size;
                pictureBox[i].TabStop = false;
                sizeW += card.image.Size.Width / 2;

                if (g == bj.dealer)
                {
                    pictureBox[i].Location = new Point(sizeW, 0);
                    if (bDealerScoreShow || check)
                    {
                        pictureBox[i].Image = card.image;
                    }
                    else if (!(bDealerScoreShow || check))
                    {
                        pictureBox[i].Image = new Bitmap("..\\..\\image\\back.gif");
                        check = true;
                    }

                    if (bDealerScoreShow)
                    {
                        txtDealerScore.Text = g.Score.ToString();
                    }

                    panelDeal.Size = new Size((sizeW + card.image.Size.Width), card.image.Height);
                    panelDeal.Location = new Point((this.Size.Width / 2) - (panelDeal.Size.Width / 2), panelDeal.Location.Y);
                    panelDeal.Controls.Add(pictureBox[i]);
                }
                else if (g != bj.dealer)
                {
                    pictureBox[i].Location = new Point(sizeW, 0);
                    txtPlayerScore.Text = g.Score.ToString();
                    pictureBox[i].Image = card.image;
                    panelPlay.Size = new Size((sizeW + card.image.Size.Width), card.image.Height);
                    panelPlay.Location = new Point((this.Size.Width / 2) - (panelPlay.Size.Width / 2), panelPlay.Location.Y);
                    panelPlay.Controls.Add(pictureBox[i]);
                }

                i++;
            }
        }

        public void GameEndProc()
        {
            string st = string.Empty;

            while (bj.dealer.Score < 17)
            {
                if (DealerCardGet())
                {
                    break;
                }
            }
            bj.CheckCurrentState(bj.dealer);

            List<Gamer> lastGamer = bj.WinnerIs();

            panelDeal.Controls.Clear();
            panelPlay.Controls.Clear();

            bDealerScoreShow = true;

            // 배팅계산 후 PUSH여부를 리턴
            bj.ComputeBettingCash(lastGamer);

            // 최종 결과를 출력해준다.
            txtCash.Text = bj.players[0].Cash.ToString();

            ShowStatus();

            if (bj.bPushGame)
            {
                labelPush.Visible = true;
            }
            else
            {
                foreach (Gamer g in lastGamer)
                {
                    if (g == bj.dealer)
                    {
                        labelLose.Visible = true;
                    }
                    else
                    {
                        labelWin.Visible = true;
                    }
                }
            }

            CashCheck();

            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonDouble.Enabled = false;
            buttonBetting.Enabled = true;
            시작ToolStripMenuItem.Enabled = true;
            txtBetting.Text = string.Empty;
            txtBetting.Focus();
        }

        private void CashCheck()
        {
            foreach (Player p in bj.players)
            {
                if (p.Cash <= 0)
                {
                    DialogResult dr = MessageBox.Show("잔액이 부족 합니다.\n새 게임을 시작 하겠습니까?", "잔액 Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        새게임ToolStripMenuItem_Click(this, null);
                        return;
                    }
                    else
                    {
                        dr = MessageBox.Show("게임을 종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("새 게임을 실행 합니다.", "새 게임", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            새게임ToolStripMenuItem_Click(this, null);
                            return;
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("게임을 종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtBetting.Focus();
        }
    }
}