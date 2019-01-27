using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WinBlackJack
{
    public class Card
    {
        private char suits;
        private string number;
        public Bitmap image;
        
        public int Number {
            get {
                int number;
                switch (this.number)
                {
                    case "K":
                    case "Q":
                    case "J":
                    case "10":
                        number = 10;
                        break;
                    case "A":
                        number = 11;
                        break;
                    default:
                        number = int.Parse(this.number);
                        break;
                }
                return number;
            }
        }
        
        public Card() { }
        public Card(char suits, string number) { Init(suits, number); }
        public Card(Card c) { Init(c.suits, c.number); }

        private void Init(char suits, string number) {
            this.suits = suits;
            this.number = number;
            this.image = new Bitmap(this.ToString());
        }

        public override string ToString() {
            return string.Format("..\\..\\image\\{0}{1}.gif", suits, number);
        }
    }
}
