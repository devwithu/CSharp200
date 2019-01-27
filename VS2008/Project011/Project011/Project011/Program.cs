using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Jungbo.Basic
{
    //if~else
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("짝수/홀수를 판별합니다.");

            Console.Write("한개의 정수를 입력하세요: ");
            int iNum = int.Parse(Console.ReadLine());//첫 번째 수 입력후 변환

            bool isE = Numbers.IsEven(iNum);//짝수/홀수 판별
            if (isE)
            {  //isE==true와 동일
                Console.WriteLine("{0}은/는 짝수입니다.", iNum);
            }
            else
            {
                Console.WriteLine("{0}은/는 홀수입니다.", iNum);
            }
        }
    }

    public class Numbers
    {
        //짝수인가
        public static bool IsEven(int num)
        {
            bool isP = false;
            if (num % 2 == 0)
            {
                isP = true;
            }
            else
            { //생략해도 된다.
                isP = false;
            }
            return isP;
        }
        //홀수인가
        public static bool IsOdd(int num)
        {
            bool isP = false;
            //num%2==1 과 동일
            if (num % 2 != 0)
            {
                isP = true;
            }
            return isP;
        }//
    }
}
