using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.Write("n이 짝수면 n/2 ");
            Console.WriteLine("n이 홀수면 n*3+1로 1만들기.");
            Console.Write("정수를 입력하세요: ");
            int num = int.Parse(Console.ReadLine());
            Numbers.MakeOne(num);
        }
    }
}
