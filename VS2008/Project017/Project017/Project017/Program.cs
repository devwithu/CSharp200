using System;
using Com.JungBo.Logic;//using 필수
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("정수 한개의 입력하세요. 약수를 보여드립니다. ");
            int iNum = int.Parse(Console.ReadLine());
            int iSum = UclidMath.SumDivision(iNum);
            Console.WriteLine("{0}의 자신을 제외한 모든 약수의합: {1}",
                iNum, iSum);
            Console.WriteLine("모든 약수");
            UclidMath.PrintDivision(iNum);
        }
    }
}
