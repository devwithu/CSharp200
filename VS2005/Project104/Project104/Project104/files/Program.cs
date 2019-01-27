using System;
using Com.JungBo.Maths;
namespace Project104{
    public class Program{
        public static void Main(string[] args){
            int m=20;
            int n=15;
            Console.WriteLine("{0}, {1}의 최대공약수 {2}",
                m,n,Recursion.GCD(m,n));
            Console.WriteLine("{0}, {1}의 최소공배수 {2}",
                m, n, Recursion.LCM(m, n));
        }
    }
}
