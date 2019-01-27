using System;
using Com.JungBo.Logic;   //InstallmentSavings
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            
            //연복리
            double r = 4.6;   //연복리 4.6%
            double a = 100000;//월 적금액
            int year = 1;     //적금기간 년도
            double result =
                InstallmentSavings.Savings(a, r, year);

            string s = "연복리 {0}%, 월 {1}원 씩 {2}년";
            s += "을 입금하면 {3:#,#}원을 받는다.";
            //#.# 소수점 1자리 #소수점 제거
            Console.WriteLine(s,r,a,year,result);
            //아래와 동일
            string ss =
                string.Format(s, r, a, year, result);
            Console.WriteLine(ss);
        }
    }
}