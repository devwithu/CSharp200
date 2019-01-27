using System;
using System.Collections.Generic;
using System.Text;
//중첩 for문
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("계단을 출력합니다.");
            Console.Write("정수 한개를 입력하세요: ");
            int iNum = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            Console.WriteLine("계단 내려가기");
            Asterisk.ShowStageDown(iNum);
            Console.WriteLine("계단 올라가기");
            Asterisk.ShowStageUp(iNum);
        }
    }

    public class Asterisk
    {
        public static void ShowStageDown(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("X");
                }//in for
                Console.WriteLine();
            }//out for
        }//

        public static void ShowStageUp(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n - i - 1; k++)
                {
                    Console.Write(" ");
                }//in for 1
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("X");
                }//in for 2
                Console.WriteLine();
            }//out for
        }//
    }
}
