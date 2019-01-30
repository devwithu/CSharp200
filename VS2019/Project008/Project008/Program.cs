using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jungbo.Basic
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            int iNum1 = 29;
            int iNum2 = 9;

            int iNum3 = iNum1 + iNum2;
            int iNum4 = iNum1 - iNum2;
            int iNum5 = iNum1 * iNum2;
            int iNum6 = iNum1 / iNum2;//3*9+2
            int iNum7 = iNum1 % iNum2;//3*9+2

            Console.WriteLine("덧셈:{0}+{1}={2}", iNum1, iNum2, iNum3);
            Console.WriteLine("뺄셈:{0}-{1}={2}", iNum1, iNum2, iNum4);
            Console.WriteLine("곱셈:{0}*{1}={2}", iNum1, iNum2, iNum5);
            Console.WriteLine("나눗셈:{0}/{1}={2}", iNum1, iNum2, iNum6);
            Console.WriteLine("나머지:{0}%{1}={2}", iNum1, iNum2, iNum7);
        }
    }
}
