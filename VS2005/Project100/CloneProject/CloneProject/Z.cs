using System;
namespace Com.JungBo.Maths{
    //ICloneable 깊은 복사   섹션 53
    public class Z:ICloneable{
        //중요한 데이터-> 멤버필드
        private double x;
        private double y;
        //외부에서 입력받아 초기화
        public Z(double x, double y){
            this.x = x;
            this.y = y;
        }
        //생성자 오버로딩->이미 존재하는 것을 이용
        public Z():this(0.0, 0.0){}
        //생성자 오버로딩-> 복사생성자
        public Z(Z z):this(z.X,z.Y){}
        //프로퍼티
        public double X {
            get { return x; }
            set { this.x = value; }
        }

        public double Y{
            get { return y; }
            set { this.y = value; }
        }

        //중요한 데이터 변경없이 보여주기
        public override string ToString(){
            if (y < 0){
                return string.Format("({0} - {1}i)",
                    x,Math.Abs(y));
            }
            else{
                return string.Format("({0} + {1}i)",
                    x,  y);
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

        public static double ZAbs(Z az) {
            Z zz=az*(~az);
            return Math.Sqrt(zz.X);
        }
        //Equals 오버라이딩
        public override bool Equals(object obj){
            Z cp = obj as Z;
            if (x == cp.X && y == cp.Y){
                return true;
            }
            else{
                return false;
            }
        }//
        public override int GetHashCode(){
            return base.GetHashCode() + 37;
        }//
        //항상 ==와 != 같이 필요
        public static bool operator ==(Z z1, Z z2){
            //같다면
            return z1.Equals(z2);
        }//
        //항상 ==와 != 같이 필요
        public static bool operator !=(Z z1, Z z2){
            //같지 않다면
            return !z1.Equals(z2);
        }//
        //값은 같지만 다른 개체
        public object Clone(){
            return new Z(this.x, this.y);
        }
    }//class
}
