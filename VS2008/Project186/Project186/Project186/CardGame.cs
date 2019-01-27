using System;
namespace Com.JungBo.Logic{
    public class CardGame{
        CardDictionary cc;
        public CardGame(){
            cc = new CardDictionary();
            cc.MakeCards();
        }
        public void Continue() {
            cc.Suffle();
        }
        public void Play() {
           int v1=CardValue.CVal(cc[0],cc[2]);
           int v2= CardValue.CVal(cc[1], cc[3]);
           string str = "You [{0},{2}], Com [{1},{3}]";
           if (v1 > v2){
               Console.WriteLine("You Win!! "+str, 
                   cc[0], cc[1], cc[2], cc[3]);
           }
           else if (v1 < v2){
               Console.WriteLine("You Lose!! "+str, 
                   cc[0], cc[1], cc[2], cc[3]);
           }
           else {
               Console.WriteLine("Same!! "+str, 
                   cc[0], cc[1], cc[2], cc[3]);
           }
        }//
    }
}
