using System;
namespace Com.JungBo.Maths{
    public class YenaMath{
        //sqrt(a,x), x�� ������ 
        //��) Sqrt(10,3) root(10) ���ϱ� ���۰� 3
        public static double Sqrt(double a, double x) {
            if (x <= 0 || a <= 0) { 
                throw new Exception("���۰��� ����Դϴ�."); }
            for (int i = 0; i < 20; i++){
                x = (x + a / x)/2.0;
            }
            return x;
        }
    }
}