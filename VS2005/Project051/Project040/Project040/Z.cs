using System;
namespace Com.JungBo.Maths{
    //������Ƽ, ���������
    public class Z{
        //�߿��� ������-> ����ʵ� z=x+yi
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
                    x, Math.Abs(y));
            }
            else{
                return string.Format("({0} + {1}i)",
                    x,  y);
            }
        }
        //������ �����ε�-> ���������->��������
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
    }//class
}
