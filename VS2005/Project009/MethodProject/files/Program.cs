using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("5Ģ �����Դϴ�.");
            Console.WriteLine("���� ������ ���ڼ�");

            Console.Write("ù��° ���� �Է��ϼ���(����): ");
            int iNum1 = int.Parse(Console.ReadLine());

            Console.Write("+,-,*,/,% �� ���ϴ� ������ �Է�: ");
            string opp = Console.ReadLine();

            Console.Write("�ι�° ���� �Է��ϼ���(����): ");
            int iNum2 = int.Parse(Console.ReadLine());
            //��ü����
            OperationCalculator oppCal 
                               = new OperationCalculator();
            //�޼���ȣ��
            int iNum3 = oppCal.Calculator(iNum1,iNum2,opp);
            Console.WriteLine("{0} {1} {2}={3}", 
                                        iNum1,opp, iNum2, iNum3);
        }
    }

    public class OperationCalculator {
        //�޼��� ����
        public int Calculator(int x, int y, string opp){
            int z = 0;//��Ģ�������� ������ �ӽ� ����
            //��Ģ������ � ���ΰ� ����
            switch (opp){
                case "+": z = x + y; break;
                case "-": z = x - y; break;
                case "x": z = x * y; break;
                case "/": z = x / y; break;
                case "%": z = x % y; break;
            }
            return z;//��Ģ���꿡 �˸��� ���� �����Ѵ�.
        }
    }
}
