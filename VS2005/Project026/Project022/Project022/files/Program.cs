using System;
using Com.JungBo.Logics;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("���ϴ� ���� ��¥���� �����帳�ϴ�.");
            Console.WriteLine("���ϴ� �⵵�� ���� �Է��ϼ���.");
            Console.Write("�⵵: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("��: ");
            int month = int.Parse(Console.ReadLine());
            HechoCalendar hc = new HechoCalendar();
            int days=hc.Days(year,month);
            Console.WriteLine("{0}�� {1}������ {2}�� �ֽ��ϴ�.",
                year,month, days );
        }
    }
}
