using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Jungbo.Basic{
    //���׿�����
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("¦��/Ȧ���� �Ǻ��մϴ�.");

            Console.Write("�Ѱ��� ������ �Է��ϼ���: ");
            int iNum = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ

            bool isE = Numbers.IsOdd(iNum);//Ȧ���ΰ�?
            if (isE){  //isE==true�� ����
                Console.WriteLine("{0}��/�� Ȧ���Դϴ�.", iNum); 
            }
            else{
                Console.WriteLine("{0}��/�� ¦���Դϴ�.", iNum);
            }
        }
    }
    public class Numbers{
        //¦���ΰ�
        public static bool IsEven(int num)
        {
            bool isP = (num%2==0) ?true:false;
            return isP;
        }
        //Ȧ���ΰ�
        public static bool IsOdd(int num)
        {
            return (num % 2 == 1) ? true : false;;
        }//
    }
}
