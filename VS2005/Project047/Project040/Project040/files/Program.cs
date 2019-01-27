using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList IEnumerator
        public static void Main(string[] args){

            CardList cl = new CardList();
            cl.MakeCard();
            cl.PrintCard();
            Console.WriteLine("----------------------");
            //object[]->string [] 변환
            string[] cards = cl.ToArray();
            int i = 0;
            //CardList.SUIT.Length-> SUIT가 public static 이므로
            foreach (string card in cards)
            {
                Console.Write("{0}  ", card);
                if ((i+++1) % CardList.SUIT.Length == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
