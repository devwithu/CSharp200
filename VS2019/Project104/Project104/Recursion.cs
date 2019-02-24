using System;
namespace Com.JungBo.Maths{
    public class Recursion{
       public static  int GCD(int m, int n){
            if (n == m){
                return m;
            }
            else {
                if (m > n){
                    return GCD(m - n, n);
                }
                else{
                    return GCD(m, n - m);
                }
            }
        }//GCD
        public static int LCM(int m, int n){
            return (m * n) / GCD(m, n);

        }//Lcm : 최소공배수 구하기
    }//class
}//namespace
