using System;
using System.Collections.Generic;
using System.Text;
//Math.Abs() ���
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("���̾Ƹ�带 ����մϴ�.");
            Console.Write("Ȧ���� ���� �Ѱ��� �Է��ϼ���: ");
            int iNum = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ

            Asterisk.ShowDiamond(iNum);
            Console.WriteLine();
            Asterisk.ShowReverseDiamond(iNum);
        }
    }
    public class Asterisk{
        //���̾Ƹ����
        public static void ShowDiamond(int n){
            for (int i = 0; i < n; i++){
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write(" ");
                }
                for (int k = 0; k < n - 2 * Math.Abs(i - n / 2); k++){
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
        //����� X�� �ٲ� ���̾Ƹ����
        public static void ShowReverseDiamond(int n){
            for (int i = 0; i < n; i++){
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write("X");
                }
                for (int k = 0; k < n - 2 * Math.Abs(i -n / 2); k++){
                    Console.Write(" ");
                }
                for (int j = 0; j < Math.Abs(i - n / 2); j++){
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
    }
}
