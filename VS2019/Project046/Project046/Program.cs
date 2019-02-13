using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CardList cl = new CardList();

            //cl.SUIT[3] = "kk";  //4->kk로 변경됨

            cl.MakeCard();
            cl.PrintCard();//출력
            Console.WriteLine("----------------------");

            cl.Sort();      //알파벳 순 정렬
            cl.PrintCard();//출력
            Console.WriteLine("----------------------");

            cl.ReverseCard();//뒤집어
            cl.PrintCard();//출력
            Console.WriteLine("----------------------");

            //object[]->string [] 변환
            string[] cards = cl.ToArray();
            int i = 0;
            //cl.SUIT.Length-> SUIT가 public 이므로
            foreach (string card in cards)
            {
                Console.Write("{0}  ", card);
                if ((i++ + 1) % cl.SUIT.Length == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}