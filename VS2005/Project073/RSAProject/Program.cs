using System;
using Com.JungBo.Logic;   //InstallmentSavings
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            
            //������
            double r = 4.6;   //������ 4.6%
            double a = 100000;//�� ���ݾ�
            int year = 1;     //���ݱⰣ �⵵
            double result =
                InstallmentSavings.Savings(a, r, year);

            string s = "������ {0}%, �� {1}�� �� {2}��";
            s += "�� �Ա��ϸ� {3:#,#}���� �޴´�.";
            //#.# �Ҽ��� 1�ڸ� #�Ҽ��� ����
            Console.WriteLine(s,r,a,year,result);
            //�Ʒ��� ����
            string ss =
                string.Format(s, r, a, year, result);
            Console.WriteLine(ss);
        }
    }
}