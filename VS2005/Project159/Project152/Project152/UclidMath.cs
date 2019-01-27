using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Logic {
    public class UclidMath
    {
        public static bool IsPerfect(int n) {
            bool isP = false;
            if (n == SumDivision(n)) {
                isP = true;
            }
            return isP;
        }//
        //약수의 총합
        public static int SumDivision(int n) {
            int total = 1;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) { total += i; }
            }
            return total;
        }//
        //모든 약수 출력
        public static void PrintDivision(int n) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[1, ");
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) {
                    sb.Append(i+", ");
                }
            }
            sb.Append(n + "] ");
            Console.WriteLine(sb.ToString());
        }
        //친화수 출력
        public static void PrintFriend(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                int tempB = SumDivision(i);
                int tempA = SumDivision(tempB);
                if(i>tempB && i==tempA){
                    Console.WriteLine("{0}<-->{1}", i, tempB);
                    PrintDivision(i);
                    PrintDivision(tempB);
                }
               
            }
        }
       

        public static  int GCD(int n, int m) {
            
            if(n*m==0 || n<0 || m<0  ){
                throw new UnFittableException("0이나 음수로 최대공약수를 구할 수 없습니다.");
            }
            if (n == m)
            {
                return n;
            }
            else { 
               while(n!=m){
                   if (n > m)
                   {
                       n -= m;
                   }
                   else {
                       m -= n;
                   }
               }
               return n;
            }
        }//

        public static int LCM(int n, int m) {
            if (n * m == 0 || n < 0 || m < 0)
            {
                throw new UnFittableException("0이나 음수로 최소 공배수를 구할 수 없습니다.");
            }
            return n * m / GCD(n, m);
        }//




    }
}
