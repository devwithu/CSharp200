using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Basic
{
    public class OneFor
    {
        public static void Main(string[] args)
        {
            Asterisk.ShowLine(20);
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
