using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths{
    //������ �����ε�
    public class Z :ICloneable{
        //�߿��� ������-> ����ʵ�
        private double x;
        private double y;
        //�ܺο��� �Է¹޾� �ʱ�ȭ
        public Z(double x, double y){
            this.x = x;
            this.y = y;
        }
        //������ �����ε�->�̹� �����ϴ� ���� �̿�
        public Z():this(0.0, 0.0){}
        //������ �����ε�-> ���������
        public Z(Z z):this(z.X,z.Y){}
        //������Ƽ
        public double X {
            get { return x; }
            set { this.x = value; }
        }

        public double Y{
            get { return y; }
            set { this.y = value; }
        }

        //�߿��� ������ ������� �����ֱ�
        public override string ToString()
        {
            if (y < 0)
            {
                return string.Format("({0} - {1}i)",
                    x, Math.Abs(y));
            }
            else if (y > 0)
            {
                return string.Format("({0} + {1}i)",
                    x, y);
            }
            else
            {
                return string.Format("({0} )",
                    x);
            }
        }
        public static Z operator +(Z z1, Z z2){
            return new Z(z1.X + z2.X, z1.Y + z2.Y);
        }//

        public static Z operator -(Z z1, Z z2){
            return new Z(z1.X - z2.X, z1.Y - z2.Y);
        }//

        public static Z operator *(Z z1, Z z2){
            return new Z(z1.X * z2.X - z1.Y * z2.Y,
                         z1.X * z2.Y +z2.X * z1.Y);
        }//

        public static Z operator *(double c, Z z1){
            return new Z(c * z1.X, c * z1.Y);
        }//

        public static Z operator ~(Z z1){
            return new Z(z1.X, -z1.Y);
        }//

        public static Z operator /(Z z1, Z z2){
            Z zt = z2 * (~z2);
            Z newZ=z1*(~z2);
            return  newZ/zt.X;
        }//

        public static Z operator /(Z z1, double c){
            return new Z(z1.X / c, z1.Y / c);
        }//
        //�׻� ==�� != ���� �ʿ�
        public static bool operator ==(Z z1, Z z2)
        {
            //���ٸ�
            return z1.Equals(z2);
        }//
        //�׻� ==�� != ���� �ʿ�
        public static bool operator !=(Z z1, Z z2)
        {
            //���� �ʴٸ�
            return !z1.Equals(z2);
        }//
        //Equals �������̵�
        public override bool Equals(object obj)
        {
            Z cp = obj as Z;
            if (x == cp.X && y == cp.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//

        public override int GetHashCode()
        {
            return base.GetHashCode() + 37;
        }//

        public static double ZAbs(Z az) {
            Z zz=az*(~az);
            return Math.Sqrt(zz.X);
        }


        #region ICloneable ���

        public object Clone()
        {
            return new Z(this.x, this.y);
        }

        #endregion
    }//class
}
