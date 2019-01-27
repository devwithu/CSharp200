using System;
namespace Com.JungBo.Logic{
    //같으면 땡, 다르면 끝(아주 간단한 족보)
    public class CardValue{
        public static int CVal(Card c1, Card c2) {
            int sum = 0;
            int cv1 = ToVal(c1);
            int cv2 = ToVal(c2);
            if (cv1 == cv2){
                //1+1->1땡->100점
                sum = cv1 * 100;
            }
            else {
                //1+10 -> 1끝-> 점수 10
                sum = ((cv1 + cv2) % 10) * 10;
            }
            return sum;
        }//
        public static int ToVal(Card c1) {
            int val = 0;
            //"H5"  h[1]='5'   '0'
            switch(c1.CardValue[1]){
                case 'A': val = 1; break;
                case 'T': 
                case 'J': 
                case 'Q':
                case 'K': val = 10; break;
                default: val = c1.CardValue[1] - '0'; break;
            }
            return val;
        }//
    }
}
