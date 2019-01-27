using System;
using System.Collections.Generic;
using System.Text;
namespace Com.JungBo.Maths {
    public class DeMoivre {

        //Rotate (��)
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
            if (a >0 &&  b > 0){  //1��и�
                theta = acotheta;
            }
            else if (a< 0 && b > 0){//2��и�
                theta = acotheta;
            }
            else if (a > 0 && b<0){//4��и�
                //�������� ���������
                theta = Math.PI*2+ asitheta;
            }
            else if (a < 0 && b < 0){//3��и�
                //3��и� ������ �����
                theta = Math.PI  + Math.Abs(asitheta);
            }
            else if (a>0 && b==0){  //���� �Ǽ���
                theta = 0;
            }
            else if (a < 0 && b == 0){  //���� �Ǽ���
                theta = Math.PI;
            }
            else if (a == 0 && b > 0){//���� �����
                theta = Math.PI/2;
            }
            else if (a == 0 && b < 0){//���� �����
                theta = 3*Math.PI / 2;
            }
            //Console.WriteLine(acotheta);  //�ڻ��ΰ� Ȯ��
            //Console.WriteLine(asitheta);  //���ΰ� Ȯ��
            //Console.WriteLine(theta);     //360 ���ذ� Ȯ��
            return theta;  //����
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
                double first = FirstTheta(z);//���۰�
                //���۰�+��а�
                double theta =
                  (first/n + ToRadian(360.0 / n * i)) % 360.0; 
                double size = Size(n, z);  //ũ�� ���ϱ�
                double cos = Math.Cos(theta);//���� ���ϱ�
                double sin = Math.Sin(theta);//���� ���ϱ�
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
