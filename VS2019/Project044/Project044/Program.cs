using System;


namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ss = "Hello! My name is Su-mi";
            object obj = ss;//프로모션
            object obj1 = 23; //박싱
            if (obj is string)
            {//인스턴스의 타입
                string tt = (string)obj;//캐스팅
                Console.WriteLine(tt);
            }
            if (obj1 is int)
            {//Int32
                int tt = (int)obj1;//언박싱
                Console.WriteLine(tt);
            }
        }
    }
}