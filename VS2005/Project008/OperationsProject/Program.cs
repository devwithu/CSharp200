using System;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int iNum1 = 29;
            int iNum2 = 9;

            int iNum3 = iNum1 + iNum2;
            int iNum4 = iNum1 - iNum2;
            int iNum5 = iNum1 * iNum2;
            int iNum6 = iNum1 / iNum2;//3*9+2
            int iNum7 = iNum1 % iNum2;//3*9+2

            Console.WriteLine("µ¡¼À:{0}+{1}={2}", iNum1, iNum2, iNum3);
            Console.WriteLine("»¬¼À:{0}-{1}={2}", iNum1, iNum2, iNum4);
            Console.WriteLine("°ö¼À:{0}*{1}={2}", iNum1, iNum2, iNum5);
            Console.WriteLine("³ª´°¼À:{0}/{1}={2}", iNum1, iNum2, iNum6);
            Console.WriteLine("³ª¸ÓÁö:{0}%{1}={2}", iNum1, iNum2, iNum7);
        }
    }
}
