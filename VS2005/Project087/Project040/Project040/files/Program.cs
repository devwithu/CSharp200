using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            Card cc = "H8";        //암시적 형변환
            string cs = (string)cc;//명시적 형변환
            Console.WriteLine(cc);
            Console.WriteLine(cs);

            CardList cl = new CardList();
            cl.MakeCards();   //서로 다른 카드 만들기
            cl.PrintCards();//출력
        }
    }
}
