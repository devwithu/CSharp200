using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace WinBlackJack
{
    public class BlackJack
    {
        public Dealer dealer;              // Dealer
        public List<Player> players;       // Players
        public List<Gamer> allGamer;       // Dealer & Players

        public int nPlayer;                // �÷��̾� �� (�Է¿�)
        public int bettingCash;            // ���ñ�
        public int insuranceCash;          // Insurance�� ������ ���ñ�
        public static int bestScore;       // �� ���ӳ� ���� ū ����
        public bool bPushGame;             // ������ PUSH������ ����
        public CMDSTATE cmdState;          // ���ӻ��¿� ���� ���ó���� ���� ������

        public readonly int BJ = 21;

        public BlackJack() : this(1) { }
        public BlackJack(int nPlayer) { Init(nPlayer); }

        private void Init(int nPlayer)
        {
            this.nPlayer = nPlayer;
            this.players = new List<Player>();
            this.allGamer = new List<Gamer>();
        }
        public void ReSetGame()
        {
            this.bettingCash = 0;
            this.insuranceCash = 0;
            BlackJack.bestScore = 0;
            this.bPushGame = false;
            this.cmdState = CMDSTATE.FIRSTDEAL;
        }
        public void ReSetGamer(params Gamer[] gamer)
        {
            foreach (Gamer g in gamer)
            {
                if (g is Gamer)
                {
                    g.ReSet();
                }
            }
        }

        public void Ready()
        {
            this.dealer = null;
            this.players.Clear();
            this.allGamer.Clear();

            this.dealer = new Dealer();
            for (int n = 0; n < this.nPlayer; n++)
                this.players.Add(new Player(string.Format("{0}P", n + 1)));

            this.allGamer.Add(dealer);
            foreach (Player p in this.players)
            {
                this.allGamer.Add(p);
            }
        }

        public bool Betting(Player p)
        {
            int bet = Form1.betting;

            if (p.Betting(bet, false) == false)
            {
               MessageBox.Show("�ܾ׺��� ū ���� ���� �ϼ̽��ϴ�.","���� �� Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
               return false;
            }
            this.bettingCash += bet;
            return true;
        }

        public void BetForInsurance(Player p)
        {
            DialogResult dr = MessageBox.Show("Insurance?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            MessageBox.Show(string.Format("\tPlease bet your Insurance (0~{0}) : ", (int)p.BetCash / 2));
            int bet = int.Parse(Console.ReadLine());

            if (p.Betting(bet, true) == false)
            {
                MessageBox.Show("�ܾ׺��� �Ǵ� �Ѱ�ġ �ʰ�");
            }
            // Insurance ���ñ��� �����Ѵ�.
            this.insuranceCash += bet;
        }

        public bool Insurance()
        {
            // Insurance�� ���� ���� ��,
            foreach (Player p in this.players)
                BetForInsurance(p);

            // Dealer�� BJ�̸�
            if (dealer.State == STATE.BJ) // Insurance�� ������ ��鸸 
            {
                this.bettingCash = 0;
                foreach (Player p in this.players)
                {
                    if (p.BInsurance)
                    {
                        p.Cash += p.InsuranceCash * 2;
                    }
                }
                return true;
            }
            else
            {
                this.insuranceCash = 0;
                foreach (Player p in this.players)
                {
                    if (p.BInsurance)
                        p.InsuranceCash = 0;
                }
                return false;
            }
        }

        // ��������� ������ ������ �÷��̾���� ���¸� �����Ͽ� ���ڸ� ����. PUSH�� ���ñ� ó���� �� ����
        public List<Gamer> WinnerIs()
        {
            List<Gamer> winners = new List<Gamer>();

            // ��� ���������ڸ� winner�� ����,
            foreach (Gamer g in this.allGamer)
            {
                winners.Add(g);
            }

            // �켱 Bust�� ����� �糤��.
            winners.RemoveAll(IsBustState);

            if (winners.Count == 0)
            {
                foreach (Gamer g in this.allGamer)
                {
                    winners.Add(g);
                }
                BlackJack.bestScore = 100;
                foreach (Gamer g in winners)
                {
                    if (g.Score < BlackJack.bestScore)
                        BlackJack.bestScore = g.Score;
                }
                winners.RemoveAll(IsNotLowScore);
            }
            else
            {

                // BJ�� ���� �ִ� ���� ���� ���...
                if (winners.Exists(HasBlackJack))
                {
                    // �̶�, BJ�� �ƴ� ����� ���� ���ڰ� �� �� �����Ƿ� �糤��.
                    winners.RemoveAll(HasNotBlackJack);
                    // Dealer�� ȥ�� BJ�̸� ��, �÷��̾� �� BJ����� ������ �׵�� PUSH
                    // Dealer�� BJ�� �ƴϸ�, ������ �÷��̾� ��ΰ� ��
                }
                // BJ�� ���� ���� �ϳ��� ���� ���...
                else
                {
                    // �ְ�������(��)�� �����.
                    foreach (Gamer g in winners)
                    {
                        if (g.Score > BlackJack.bestScore)
                            BlackJack.bestScore = g.Score;
                    }
                    winners.RemoveAll(IsNotBestScore);
                }
            }

            // ��������ĺ��ڰ� �߷�����.
            // �̹� ������ PUSH�Ǿ�����(��ܿ� Dealer�� Player�� ���ÿ� ���� ���) üũ�Ѵ�.
            foreach (Player p in this.players)
            {
                if (winners.Contains(p) && winners.Contains(dealer))
                {
                    this.bPushGame = true;
                    break;
                }
            }

            return winners;
        }
        // ������ ������ ���, ���ڿ� ���� ���ñ��� ó���Ѵ�. (���ǰܷ���, ������ ù BJ, Insurance������ ������ BJ)
        public void ComputeBettingCash(List<Gamer> winners)
        {
            if (bPushGame)
            {
                // PUSH�̸� ����ڵ鸸 ���� �����ְ�, ��������� ���� ���´�.
                foreach (Player p in this.players)
                {
                    if (winners.Contains(p))
                    {
                        p.Cash += p.BetCash;
                    }
                }
            }
            else
            {
                // Dealer ȥ�� ���̸�
                if (winners.Count == 1 && winners.Contains(dealer))
                {
                    this.bettingCash = 0;
                    return;
                }
                // ���ڰ� �ִٸ� ���ñ��� ��(��)���� �������ش�.
                foreach (Gamer g in winners)
                {
                    Player p = g as Player;
                    // �ڱ� ���ñ��� �����ְ�,
                    p.Cash += p.BetCash;
                    // �ڱ���ñ��� ������ ������ ���ñ��� ���� �޴´�. 1�ο��϶���??�Ѥ�;;
                    if (winners.Count == 1)
                    {
                        p.Cash += p.BetCash;
                    }
                    else
                    {
                        p.Cash += (int)((this.bettingCash - p.BetCash) / winners.Count);
                    }

                }
            }
        }

        public bool IsBJ(Gamer p) { return p.Score == BJ ? true : false; }
        public bool IsBust(Gamer p) { return p.Score > BJ ? true : false; }
        public void CheckCurrentState(Gamer gamer)
        {
            if (IsBust(gamer)) gamer.State = STATE.BUST;
            if (IsBJ(gamer)) gamer.State = STATE.BJ;
        }

        public void MessageShow(string msg)
        {
            Console.WriteLine(msg);
        }

        public static bool HasBlackJack(Gamer g)
        {
            return (g.State == STATE.BJ) ? true : false;
        }
        public static bool IsBustState(Gamer g)
        {
            return (g.State == STATE.BUST) ? true : false;
        }
        public static bool HasNotBlackJack(Gamer g)
        {
            return (g.State == STATE.NOTBJ) ? true : false;
        }
        public static bool IsNotBestScore(Gamer g)
        {
            return (g.Score < BlackJack.bestScore) ? true : false;
        }
        public static bool IsNotLowScore(Gamer g)
        {
            return (g.Score > BlackJack.bestScore) ? true : false;
        }
    } // class
}