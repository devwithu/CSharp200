using System;
namespace Com.JungBo.Maths{
    public class YenaMath{
        //sqrt(a,x), x는 추측값 
        //예) Sqrt(10,3) root(10) 구하기 시작값 3
        public static double Sqrt(double a, double x) {
            if (x <= 0 || a <= 0) { 
                throw new Exception("시작값은 양수입니다."); }
            for (int i = 0; i < 20; i++){
                x = (x + a / x)/2.0;
            }
            return x;
        }
    }
}