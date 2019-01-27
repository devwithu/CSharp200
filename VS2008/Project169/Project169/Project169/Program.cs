using System;
namespace Com.JungBo.Logic
{
    public class EvenMain
    {
        public static void Main(string[] args)
        {
            EvenWithPrime ev = new EvenWithPrime();
            //30을 이루는 소수들
            ev.PrintNums(8);
            //30을 이루는 두 소수
            //ev.Print2Num(30);
        }
    }
}
