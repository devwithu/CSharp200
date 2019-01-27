using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            MyCarendar mycal=new MyCarendar();
            mycal.PrintCalendar(2008);
            int howlong = mycal.HowLongDay(1979, 6, 27, 2008, 8, 16);
            Console.WriteLine(howlong);
        }
    }
}
