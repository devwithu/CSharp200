using System;
using Com.JungBo.Maths;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Z z1 = new Z(3, 2);
            Z z2 = new Z(3 ,- 5);
            //Z1�� ������ ���������� �ٸ� ��ü
            Z z3 = new Z(z1);
            Console.WriteLine(z3);
            z3.X = 5;             //x�� 5����
            z3.Y = -9;            //y�� -9����

            Console.WriteLine(z1);
            Console.WriteLine(z2);
            Console.WriteLine(z3);
        }
    }
}
