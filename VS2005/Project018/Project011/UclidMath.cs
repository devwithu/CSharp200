using System;
namespace Com.JungBo.Logic{
    //Method void, bool, int
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
        //완전수인가
        public static bool IsPerfect(int n){
            bool isP = false;
            if (n == SumDivision(n)){
                isP = true;
            }
            return isP;
        }
        //완전수 출력
        public static void PrintPerfect(int n){
            for (int i = 2; i <= n; i++){
                if (IsPerfect(i)){
                    Console.Write("{0}=", i); PrintDivision(i);
                }
            }
        }
    }
}
