using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){
            //�빮��>�ҹ���>������ ���ڿ�
            Console.WriteLine("h".CompareTo("3"));
            Console.WriteLine("hh".CompareTo("haj"));
            Console.WriteLine("H".CompareTo("3"));
            Console.WriteLine("12".CompareTo("111"));
            Console.WriteLine("h".CompareTo("H"));

            //���ڴ� ���� ũ��
            Console.WriteLine(111.CompareTo(22));
            Console.WriteLine(1.CompareTo(3));
        }
    }
}
