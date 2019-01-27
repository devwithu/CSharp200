using System;
namespace Com.JungBo.Logic{
    // ���� ����
    public class CardValue{
        private int cardVal;  // Card Value
        private Card card;
        private int aCount;// A �̸�, ī��Ʈ�� �ø���.        
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
            // ���ڸ� ���� �ٲ۴�.
            cardVal = ToInt(cardChar);
        }//Make

        // BlackJack ������ T ���Ŀ� ���� 10 �̴�. 
        // A �� ���, ���� 2 �� �����ؾ� �ϹǷ� �Լ��� ȣ���� ���� �ִ´�.
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
