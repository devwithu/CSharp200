using System;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){
            //대문자>소문자>숫자형 문자열
            Console.WriteLine("h".CompareTo("3"));
            Console.WriteLine("hh".CompareTo("haj"));
            Console.WriteLine("H".CompareTo("3"));
            Console.WriteLine("12".CompareTo("111"));
            Console.WriteLine("h".CompareTo("H"));
            //숫자는 숫자 크기
            Console.WriteLine(111.CompareTo(22));
            Console.WriteLine(1.CompareTo(3));
            Console.WriteLine("CJ".CompareTo("CJ"));
            Console.WriteLine("한".CompareTo("12"));
        }
    }
}
