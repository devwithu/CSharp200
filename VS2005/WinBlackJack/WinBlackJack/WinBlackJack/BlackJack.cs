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

        public int nPlayer;                // 플레이어 수 (입력용)
        public int bettingCash;            // 배팅금
        public int insuranceCash;          // Insurance시 누적된 배팅금
        public static int bestScore;       // 한 게임내 가장 큰 점수
        public bool bPushGame;             // 게임이 PUSH었는지 여부
        public CMDSTATE cmdState;          // 게임상태에 따른 명령처리를 위한 열거자

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
               MessageBox.Show("잔액보다 큰 수를 배팅 하셨습니다.","배팅 금 Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
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
                MessageBox.Show("잔액부족 또는 한계치 초과");
            }
            // Insurance 배팅금을 누적한다.
            this.insuranceCash += bet;
        }

        public bool Insurance()
        {
            // Insurance를 위한 배팅 후,
            foreach (Player p in this.players)
                BetForInsurance(p);

            // Dealer가 BJ이면
            if (dealer.State == STATE.BJ) // Insurance에 배팅한 놈들만 
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

        // 게임종료시 딜러를 포함한 플레이어들의 상태를 조사하여 승자를 뱉어낸다. PUSH는 배팅금 처리할 때 결정
        public List<Gamer> WinnerIs()
        {
            List<Gamer> winners = new List<Gamer>();

            // 모든 게임참가자를 winner로 놓고,
            foreach (Gamer g in this.allGamer)
            {
                winners.Add(g);
            }

            // 우선 Bust된 놈들은 재낀다.
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

                // BJ를 갖고 있는 놈이 있을 경우...
                if (winners.Exists(HasBlackJack))
                {
                    // 이때, BJ이 아닌 놈들은 절대 승자가 될 수 없으므로 재낀다.
                    winners.RemoveAll(HasNotBlackJack);
                    // Dealer가 혼자 BJ이면 승, 플레이어 중 BJ놈들이 있으면 그들과 PUSH
                    // Dealer가 BJ가 아니면, 나머지 플레이어 모두가 승
                }
                // BJ를 가진 놈이 하나도 없을 경우...
                else
                {
                    // 최고점수자(들)만 남긴다.
                    foreach (Gamer g in winners)
                    {
                        if (g.Score > BlackJack.bestScore)
                            BlackJack.bestScore = g.Score;
                    }
                    winners.RemoveAll(IsNotBestScore);
                }
            }

            // 최종우승후보자가 추려졌다.
            // 이번 게임이 PUSH되었는지(명단에 Dealer와 Player가 동시에 있을 경우) 체크한다.
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
        // 게임이 끝났을 경우, 승자에 대한 배팅금을 처리한다. (한판겨룬후, 딜러의 첫 BJ, Insurance에서의 딜러의 BJ)
        public void ComputeBettingCash(List<Gamer> winners)
        {
            if (bPushGame)
            {
                // PUSH이면 대상자들만 돈을 돌려주고, 나머지놈들 것은 뺏는다.
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
                // Dealer 혼자 승이면
                if (winners.Count == 1 && winners.Contains(dealer))
                {
                    this.bettingCash = 0;
                    return;
                }
                // 승자가 있다면 배팅금을 그(들)에게 나누어준다.
                foreach (Gamer g in winners)
                {
                    Player p = g as Player;
                    // 자기 배팅금은 돌려주고,
                    p.Cash += p.BetCash;
                    // 자기배팅금을 제외한 나머지 배팅금을 나눠 받는다. 1인용일때는??ㅡㅡ;;
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