using System;
using System.Collections.Generic;
using System.Text;

namespace  Com.Jungbo.Basic{
    //if~else
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("¦��/Ȧ���� �Ǻ��մϴ�.");

            Console.Write("�Ѱ��� ������ �Է��ϼ���: ");
            int iNum = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ

            bool isE=Numbers.IsEven(iNum);//¦��/Ȧ�� �Ǻ�
            if (isE)
            {  //isE==true�� ����
                Console.WriteLine("{0}��/�� ¦���Դϴ�.",iNum);
            }
            else {
                Console.WriteLine("{0}��/�� Ȧ���Դϴ�.", iNum);
            }
        }
    }

    public class Numbers{
        //¦���ΰ�
        public static bool IsEven(int num){
            bool isP = false;
            if (num % 2 == 0){
                isP = true;
            }
            else { //�����ص� �ȴ�.
                isP = false;
            }
            return isP;
        }
        //Ȧ���ΰ�
        public static bool IsOdd(int num){
            bool isP = false;
            //num%2==1 �� ����
            if (num % 2 != 0){
                isP = true;
            }
            return isP;
        }//
    }
}
