using System;
using Com.JungBo.Logic;//using �ʼ�
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            Console.Write("���� �Ѱ��� �Է��ϼ���. ����� �����帳�ϴ�. ");
            int iNum = int.Parse(Console.ReadLine());
            int iSum = UclidMath.SumDivision(iNum);
            Console.WriteLine("{0}�� �ڽ��� ������ ��� �������: {1}",
                iNum,iSum);
            Console.WriteLine("��� ���");
            UclidMath.PrintDivision(iNum);
        }
    }
}
