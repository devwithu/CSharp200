using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("5칙 연산입니다.");
            Console.WriteLine("숫자 연산자 숫자순");

            Console.Write("첫번째 수를 입력하세요(정수): ");
            int iNum1 = int.Parse(Console.ReadLine());

            Console.Write("+,-,x,/,% 중 원하는 연산자 입력: ");
            string opp = Console.ReadLine();

            Console.Write("두번째 수를 입력하세요(정수): ");
            int iNum2 = int.Parse(Console.ReadLine());
            //개체생성
            OperationCalculator oppCal
                               = new OperationCalculator();
            //메서드호출
            int iNum3 = oppCal.Calculator(iNum1, iNum2, opp);
            Console.WriteLine("{0} {1} {2}={3}",
                                        iNum1, opp, iNum2, iNum3);
        }
    }

    public class OperationCalculator
    {
        //메서드 선언
        public int Calculator(int x, int y, string opp)
        {
            int z = 0;//사칙연산결과를 저장할 임시 변수
            //사칙연산이 어떤 것인가 선택
            switch (opp)
            {
                case "+": z = x + y; break;
                case "-": z = x - y; break;
                case "x": z = x * y; break;
                case "/": z = x / y; break;
                case "%": z = x % y; break;
            }
            return z;//사칙연산에 알맞은 값을 리턴한다.
        }
    }
}
