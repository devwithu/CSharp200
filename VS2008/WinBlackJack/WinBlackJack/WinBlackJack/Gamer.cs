using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace WinBlackJack
{
    public abstract class Gamer
    {
        private string name;
        private STATE state;
        public ArrayList curCardList = new ArrayList();

        public string Name { get { return name; } }
        public int Score {
            get {
                int sum = 0;
                bool bContainAce = false;
                foreach (Card card in curCardList) {
                    if (card.Number == 11)
                        bContainAce = true;
                    sum += card.Number;
                }
                if (sum > 21 && bContainAce)
                    sum -= 10;
                return sum;
            }
        } // 카드점수
        public STATE State {
            get { return state; }
            set { state = value; }
        }
        
        public Card this[int idx] {
            get {
                if (idx > -1 && idx < curCardList.Count) {
                    return curCardList[idx] as Card;
                } else { return null; }
            }
        }

        public Gamer() { }
        public Gamer(string name) {
            this.name = name;
            Init();
        }

        private void Init() {
            curCardList.Clear();
            this.state = STATE.NOTBJ;
        }

        public virtual void ReSet() { Init(); }

        public void BringOneCard(Card card) { curCardList.Add(card); }

        //public virtual void PrintInfo() {
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("\t\tScore : {0}", this.Score);
        //    Console.WriteLine(sb);
        //}
    } // Gamer

    public class Dealer : Gamer
    {
        private CardList deck = new CardList();

        public Dealer() : base("Dealer") { Init(); }

        private void Init() {
            deck.ReSet();
        }
        public override void ReSet() {
            base.ReSet();
            this.Init();
        }

        public Card HideCard { get { return this.curCardList[0] as Card; } }
        public Card ShowCard { get { return this.curCardList[1] as Card; } }

        public Card PutCard() { return deck.GetCard(); }
    } // Dealer

    public class Player : Gamer
    {
        private int cash = 1000;        // 처음 소지액
        private int betCash;            // 배팅액
        private int insuranceCash;      // Insurance시 배팅액
        private bool bInsurance;        // Insurance 여부

        public int Cash { get { return cash; } set { cash = value; } }
        public int BetCash { get { return betCash; } set { betCash = value; } }
        public int InsuranceCash { get { return insuranceCash; } set { insuranceCash = value; } }
        public bool BInsurance { get { return bInsurance; } }

        public Player() : this("Unknown Player") { }
        public Player(string name) : base(name) { Init(); }

        private void Init()
        {
            this.betCash = 0;
            this.insuranceCash = 0;
            this.bInsurance = false;
        }

        public override void ReSet()
        {
            base.ReSet();
            this.Init();
        }

        public bool Betting(int bet, bool bInsurance)
        {
            if (this.cash >= bet)
            {
                if (bInsurance)
                {
                    if ((int)bet / 2 > this.betCash)
                        return false;
                    this.insuranceCash = bet;
                    this.bInsurance = true;
                }

                this.cash -= bet;
                this.betCash += bet;
                return true;
            }
            else
                return false;
        }

        //public override void PrintInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("\t" + this.Name);
        //    sb.Append("\r\n\t\tCards : ");
        //    foreach (Card card in curCardList)
        //        sb.Append(card);
        //    Console.WriteLine(sb);

        //    base.PrintInfo();

        //    Console.WriteLine("\t\tCash : {0}", this.cash);
        //}
    } // Player

    public class GamerComparer : IComparer<Gamer>
    {
        public int Compare(Gamer x, Gamer y)
        {
            if (x.Score == y.Score)
                return 0;
            if (x.Score > y.Score)
                return -1;
            else
                return 1;
        }
    }
}