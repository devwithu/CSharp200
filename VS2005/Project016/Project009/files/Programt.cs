using System;
using System.Collections.Generic;
using System.Text;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Abs(-23.5));//���밪
            Console.WriteLine(Math.Abs(23.5));//���밪
            Console.WriteLine(Math.Ceiling(-23.3));//�ø� -23
            Console.WriteLine(Math.Ceiling(23.3));//�ø� 24
            Console.WriteLine(Math.Floor(23.3));//���� 23
            Console.WriteLine(Math.Floor(-23.2));//���� -24
            Console.WriteLine(Math.Round(34.5376,2));//�Ҽ���°�ڸ� �ݿø� 2°�ڸ� �����
            Console.WriteLine(Math.Exp(2));//e(2.718)�� 2�� 
            Console.WriteLine(Math.Pow(3,2));//3�� 2��
            Console.WriteLine(Math.Sqrt(10));//10�� ������
            Console.WriteLine(Math.Sin(90*Math.PI/180.0));//90�� ->�������� ����
            Console.WriteLine(Math.PI*10*10);//�������� 10�� ���ǳ���

        }
    }
}
