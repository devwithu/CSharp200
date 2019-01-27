using System;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("원하는 문자열을 입력하세요.");
            string message = Console.ReadLine();//문자열 대입
            Console.WriteLine("문자열 출력: {0}", message);

            Console.WriteLine("정수의 덧셈을 하려고 합니다.");
            Console.Write("첫번째 수를 입력하세요: ");
            //첫 번째 수 입력후 변환
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("두번째 수를 입력하세요: ");
            //두 번째 수 입력후 변환
            int num2 = int.Parse(Console.ReadLine());

            //{0}위치에 num1이, {1}위치에 num2가 들어간다.
            Console.WriteLine("두수의 합: {0}+{1}={2}",
                num1, num2, num1 + num2);

            Console.WriteLine("실수의 덧셈을 하려고 합니다.");
            Console.Write("첫번째 수를 입력하세요: ");
            double num3 = double.Parse(Console.ReadLine());

            Console.Write("두번째 수를 입력하세요: ");
            double num4 = double.Parse(Console.ReadLine());

            //{0}위치에 num3이, {1}위치에 num4가 들어간다.
            Console.WriteLine("두수의 합: {0}+{1}={2}", 
                num3, num4, num3+ num4);
        }
    }
}
