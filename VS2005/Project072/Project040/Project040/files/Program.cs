using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            CardList cl = new CardList();

            //배열에 readonly 써도 값은 변경됨
            //CardList.SUIT[3] = "kk";  //4->kk로 변경됨
            //Console.WriteLine(CardList.SUIT[3]);


            //배열이 아니면 외부에서 새로운 대입 불가
            //CardList.CARDMAX = 10000000; 
            //cl.MAXVALUE = 100000;
            //CardList.MINVALUE = -30000;


            cl.MakeCard();   //서로 다른 카드 만들기
            cl.PrintCard1();//출력
            Console.WriteLine("----------------------");

            //덱의크기*슈트의 크기=4*13
            int count = CardList.CARDMAX;

            for (int i = 0; i < count; i++){
                //cl[i] indexer 이용
                Console.Write("{0}  ",cl[i]);  
                //if ((i + 1) % (cl.MAXVALUE / 4) == 0){
                if((i+1)% (CardList.CARDMAX/4)==0){
                    Console.WriteLine();
                }
            }//
        }
    }
}
