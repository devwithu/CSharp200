using System;
using Com.JungBo.Middle.Oper;

namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            BitOperator bito = new BitOperator();
            Console.WriteLine("15�� 16������? {0}",bito.Tosixteen(15));
            Console.WriteLine("0~16�� 16������ �ٲٱ�");
            bito.PrintSixteen();

        }
    }
}
