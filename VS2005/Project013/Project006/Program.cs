using System;
using System.Collections.Generic;
using System.Text;
//for��
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("�Էµ� �� ��ŭ X�� ����մϴ�.");
            Console.Write("���� �Ѱ��� �Է��ϼ���: ");
            int iNum = int.Parse(Console.ReadLine());//ù ��° �� �Է��� ��ȯ

            Asterisk.ShowLine(iNum);
        }
    }
    //���� ���ӽ����̽��� ���ο� Ŭ���� ����
    public class Asterisk{
        //�Է¹��� �� ��ŭ X�� ����Ѵ�.
        public static void ShowLine(int n){
            //n�� 3�̸� i�� 0,1,2�� �� x ��� 
            for (int i = 0; i < n; i++){
                Console.Write("X");//������ �ٿ���
            }
            Console.WriteLine();//�Ʒ��� �� ��
        }// 
    }
}
