using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Maths {
    public class DeMoivre {

        //Rotate (도)
        public static Z Rotate(Z z, double t){
            Z z1 = new Z(z.X, z.Y);
            Z z2 = new Z(Math.Cos(ToRadian(t)),
                         Math.Sin(ToRadian(t)));
            Z zz = z1 * z2;
            return zz;
        }//

        public static double FirstTheta(Z z){
            double theta = 0;
            double abs = Z.ZAbs(z);
            double a = z.X;
            double b = z.Y;
            double acotheta=  Math.Acos(a / abs);
            double asitheta = Math.Asin(b / abs);
            if (a >0 &&  b > 0){  //1사분면
                theta = acotheta;
            }
            else if (a< 0 && b > 0){//2사분면
                theta = acotheta;
            }
            else if (a > 0 && b<0){//4사분면
                //음수각을 양수각으로
                theta = Math.PI*2+ asitheta;
            }
            else if (a < 0 && b < 0){//3사분면
                //3사분면 각으로 만들기
                theta = Math.PI  + Math.Abs(asitheta);
            }
            //Console.WriteLine(acotheta);  //코사인각 확인
            //Console.WriteLine(asitheta);  //사인각 확인
            //Console.WriteLine(theta);     //360 기준각 확인
            return theta;  //라디안
        }
        public static double Size(int n, Z z){
            return Math.Pow(Z.ZAbs(z), 1.0 / n);
            //(a*a+b*b)^( 1/(2n) )
        }
        public static double ToRadian(double degree) {
            return degree * Math.PI / 180.0;
        }
        public static double ToDegree(double rad){
            return rad / Math.PI * 180.0;
        }
        public static Z[] CompRoot(int n, Z z){
            Z[] comp = new Z[n];
            for (int i = 0; i < comp.Length; i++) {
                double first = FirstTheta(z);//시작각
                //시작각+등분각
                double theta =
                  (first/n + ToRadian(360.0 / n * i)) % 360.0; 
                double size = Size(n, z);  //크기 구하기
                double cos = Math.Cos(theta);//각도 구하기
                double sin = Math.Sin(theta);//각도 구하기
                comp[i] = size*new Z(cos, sin);
            }
            return comp;
        }
        public static double[] Thetas(int n, Z z){
            double[] comp = new double[n];
            for (int i = 0; i < comp.Length; i++){
                double first = FirstTheta(z);
                double theta = 
                  (first/n + ToRadian(360.0 / n * i))%360.0; 
                comp[i] = theta;
            }
            return comp;
        }
    }
}
