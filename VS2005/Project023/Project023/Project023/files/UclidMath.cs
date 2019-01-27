using System;
namespace Com.JungBo.Logic{
    //���� ������ ==, !=, <, <=, >, >=
    public class UclidMath{
        //�ڽ��� ������ ��� ����� ��
        public static int SumDivision(int n){
            int total = 1;
            for (int i = 2; i < n; i++){
                if (n % i == 0){ //������ �������� ���
                    total = total + i; //����� ��
                }
            }
            return total;
        }//
        //��� ��� ��� (�� n>1)
        public static void PrintDivision(int n){
            Console.Write("[{0}, ", 1);
            for (int i = 2; i < n; i++){
                if (n % i == 0){ //������ �������� 
                    Console.Write("{0}, ", i);
                }
            }
            Console.WriteLine("{0}]", n);
        }
        //stn�� endn���� ģȭ��(Amicable) ���
        public static void PrintFriend(int stn, int endn){
            for (int i = stn; i <= endn; i++){
                int friA = i;
                int friB = SumDivision(friA);
                int friC = SumDivision(friB);
                if (friA == friC && friA < friB){
                    Console.WriteLine("{0}�� {1}�� ģȭ����.", friA, friB);
                }
            }
        }
    }
}
