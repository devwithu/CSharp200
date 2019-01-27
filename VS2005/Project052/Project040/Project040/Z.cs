using System;
namespace Com.JungBo.Maths{
    //������ �����ε�
    public class Z{
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
        //�߿��� ������ ������� �����ֱ�
        public override string ToString(){
            if (y < 0){
                return string.Format("({0} - {1}i)",
                    x,Math.Abs(y));
            }
            else {
                return string.Format("({0} + {1}i)",
                    x,  y);
            }
        }
        //������ �����ε�-> ���������
        public Z(Z z) : this(z.X, z.Y) { }
        //X ������Ƽ
        public double X
        {
            get { return x; }
            set { this.x = value; }
        }
        //Y ������Ƽ
        public double Y
        {
            get { return y; }
            set { this.y = value; }
        }
        //������ �����ε� +
        public static Z operator +(Z z1, Z z2){
            return new Z(z1.X + z2.X, z1.Y + z2.Y);
        }//
        //������ �����ε� -
        public static Z operator -(Z z1, Z z2){
            return new Z(z1.X - z2.X, z1.Y - z2.Y);
        }//
        //������ �����ε� *
        public static Z operator *(Z z1, Z z2){
            return new Z(z1.X * z2.X - z1.Y * z2.Y,
                         z1.X * z2.Y +z2.X * z1.Y);
        }//
        //������ �����ε� c*Z
        public static Z operator *(double c, Z z1){
            return new Z(c * z1.X, c * z1.Y);
        }//
        //������ �����ε� ~Z
        public static Z operator ~(Z z1){
            return new Z(z1.X, -z1.Y);
        }//
        //������ �����ε� /
        public static Z operator /(Z z1, Z z2){
            Z zt = z2 * (~z2);
            Z newZ=z1*(~z2);
            return  newZ/zt.X;
        }//
        //������ �����ε� z/c
        public static Z operator /(Z z1, double c){
            return new Z(z1.X / c, z1.Y / c);
        }//
        //������ �����ε��� �̿��� ���Ҽ� ũ��
        public static double ZAbs(Z az) {
            Z zz=az*(~az);
            return Math.Sqrt(zz.X);
        }
    }//class
}
