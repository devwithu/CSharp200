using System;
namespace Com.JungBo.Logic{
    //Method void, bool, int
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
        //�������ΰ�
        public static bool IsPerfect(int n){
            bool isP = false;
            if (n == SumDivision(n)){
                isP = true;
            }
            return isP;
        }
        //������ ���
        public static void PrintPerfect(int n){
            for (int i = 2; i <= n; i++){
                if (IsPerfect(i)){
                    Console.Write("{0}=", i); PrintDivision(i);
                }
            }
        }
    }
}
