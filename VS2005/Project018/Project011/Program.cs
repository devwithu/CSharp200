using System;
using Com.JungBo.Logic;//using 필수
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int iNum = 10000;
            Console.WriteLine("{0}까지의 완전수: ",iNum);
            UclidMath.PrintPerfect(iNum);
        }
    }
}
