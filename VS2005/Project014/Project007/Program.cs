using System;
using System.Collections.Generic;
using System.Text;
//��ø for��
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("����� ����մϴ�.");
            Console.Write("���� �Ѱ��� �Է��ϼ���: ");
            int iNum = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ
            
            Console.WriteLine("��� ��������");
            Asterisk.ShowStageDown(iNum);
            Console.WriteLine("��� �ö󰡱�");
            Asterisk.ShowStageUp(iNum);
        }
    }

    public class Asterisk{
        public static void ShowStageDown(int n){
            for (int i = 0; i < n; i++){
                for (int j = 0; j <= i; j++){
                    Console.Write("X");
                }//in for
                Console.WriteLine();
            }//out for
        }//

        public static void ShowStageUp(int n){
            for (int i = 0; i < n; i++){
                for (int k = 0; k < n - i - 1; k++){
                    Console.Write(" ");
                }//in for 1
                for (int j = 0; j <= i; j++){
                    Console.Write("X");
                }//in for 2
                Console.WriteLine();
            }//out for
        }//
    }
}
