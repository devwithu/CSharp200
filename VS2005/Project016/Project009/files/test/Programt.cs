using System;
using System.Collections.Generic;
using System.Text;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Abs(-23.5));//절대값
            Console.WriteLine(Math.Abs(23.5));//절대값
            Console.WriteLine(Math.Ceiling(-23.3));//올림 -23
            Console.WriteLine(Math.Ceiling(23.3));//올림 24
            Console.WriteLine(Math.Floor(23.3));//버림 23
            Console.WriteLine(Math.Floor(-23.2));//버림 -24
            Console.WriteLine(Math.Round(34.5376,2));//소수세째자리 반올림 2째자리 만들기
            Console.WriteLine(Math.Exp(2));//e(2.718)의 2승 
            Console.WriteLine(Math.Pow(3,2));//3의 2승
            Console.WriteLine(Math.Sqrt(10));//10의 제곱근
            Console.WriteLine(Math.Sin(90*Math.PI/180.0));//90도 ->라디안으로 변형
            Console.WriteLine(Math.PI*10*10);//반지름이 10인 원의넓이

        }
    }
}
