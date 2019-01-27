using System;
namespace Com.JungBo.Maths{
    //프로퍼티, 복사생성자
    public class Z{
        //중요한 데이터-> 멤버필드 z=x+yi
        private double x;
        private double y;
        //외부에서 입력받아 초기화
        public Z(double x, double y){
            this.x = x;
            this.y = y;
        }
        //생성자 오버로딩->이미 존재하는 것을 이용
        public Z():this(0.0, 0.0){}
        //중요한 데이터 변경없이 보여주기
        public override string ToString(){
            if (y < 0){
                return string.Format("({0} - {1}i)",
                    x, Math.Abs(y));
            }
            else{
                return string.Format("({0} + {1}i)",
                    x,  y);
            }
        }
        //생성자 오버로딩-> 복사생성자->깊은복사
        public Z(Z z) : this(z.X, z.Y) { }
        //X 프로퍼티 
        public double X
        {
            get { return x; }
            set { this.x = value; }
        }
        //Y 프로퍼티
        public double Y
        {
            get { return y; }
            set { this.y = value; }
        }
    }//class
}
