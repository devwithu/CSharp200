using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.Write("n�� ¦���� n/2 ");
            Console.WriteLine("n�� Ȧ���� n*3+1�� 1�����.");
            Console.Write("������ �Է��ϼ���: ");
            int num = int.Parse(Console.ReadLine());
            Numbers.MakeOne(num);
        }
    }
}
