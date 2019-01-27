using System;
namespace Com.JungBo.Logic{
    // 블랙잭 게임
    public class CardValue{
        private int cardVal;  // Card Value
        private Card card;
        private int aCount;// A 이면, 카운트를 올린다.        
        public CardValue(Card card){
            this.card = card;
        }
        public CardValue(){
            cardVal = 0;
            aCount = 0;
        }
        public int ACount{
            get { return aCount; }
            set { aCount = value; }
        }
        public Card Card{
            get { return card; }
            set { card = value; }
        }
        public int CardVal{
            get {
                Make();                
                return cardVal; 
            }
            //set { cVal = value; }
        }
        // Make Value
        private void Make(){
            string cardStr = card.CardValue;
            char cardChar = cardStr[1];  // "H8" -> '8'
            // 문자를 수로 바꾼다.
            cardVal = ToInt(cardChar);
        }//Make

        // BlackJack 용으로 T 이후엔 전부 10 이다. 
        // A 일 경우, 값이 2 개 선택해야 하므로 함수를 호출해 값을 넣는다.
        private int ToInt(char c){
            int temp = 0;
            switch (c){
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': temp = c - '0'; break;
                case 'A': temp = 0; aCount++; break;
                case 'T': 
                case 'J': 
                case 'Q':
                case 'K': temp = 10; break;
            }
            return temp;
        }//ToInt
    }
}
