using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        //ArrayList
        public static void Main(string[] args){

            CardList cl = new CardList();
            
            //cl.SUIT[3] = "kk";  //4->kk�� �����

            cl.MakeCard();
            cl.PrintCard();//���
            Console.WriteLine("----------------------");

            cl.Sort();      //���ĺ� �� ����
            cl.PrintCard();//���
            Console.WriteLine("----------------------");

            cl.ReverseCard();//������
            cl.PrintCard();//���
            Console.WriteLine("----------------------");

            //object[]->string [] ��ȯ
            string[] cards = cl.ToArray();
            int i = 0;
            //cl.SUIT.Length-> SUIT�� public �̹Ƿ�
            foreach (string card in cards){
                Console.Write("{0}  ", card);
                if ((i+++1) % cl.SUIT.Length == 0){
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
