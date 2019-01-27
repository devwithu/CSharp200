using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("원하는 달의 날짜수를 보여드립니다.");
            Console.WriteLine("원하는 년도와 달을 입력하세요.");
            Console.Write("년도: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("달: ");
            int month = int.Parse(Console.ReadLine());
            HechoCalendar hc = new HechoCalendar();
            int days=hc.Days(year,month);
            Console.WriteLine("{0}년 {1}월에는 {2}이 있습니다.",
                year,month, days );
        }
    }
}
