using System;
namespace Com.JungBo.Logic{
    //관계 연산자 ==, !=, <, <=, >, >=
    public class UclidMath{
        //자신을 제외한 모든 약수의 합
        public static int SumDivision(int n){
            int total = 1;
            for (int i = 2; i < n; i++){
                if (n % i == 0){ //나누어 떨어지면 약수
                    total = total + i; //약수의 합
                }
            }
            return total;
        }//
        //모든 약수 출력 (단 n>1)
        public static void PrintDivision(int n){
            Console.Write("[{0}, ", 1);
            for (int i = 2; i < n; i++){
                if (n % i == 0){ //나누어 떨어지면 
                    Console.Write("{0}, ", i);
                }
            }
            Console.WriteLine("{0}]", n);
        }
        //stn와 endn사이 친화수(Amicable) 출력
        public static void PrintFriend(int stn, int endn){
            for (int i = stn; i <= endn; i++){
                int friA = i;
                int friB = SumDivision(friA);
                int friC = SumDivision(friB);
                if (friA == friC && friA < friB){
                    Console.WriteLine("{0}과 {1}은 친화수다.", friA, friB);
                }
            }
        }
    }
}
