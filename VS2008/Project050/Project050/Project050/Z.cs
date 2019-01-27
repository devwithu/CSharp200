using System;
namespace Com.JungBo.Maths{
    //������
    public class Z{
        //�߿��� ������-> ����ʵ� z=x+yi
        private double x;    //�Ǽ���
        private double y;    //�����
        //�ܺο��� �Է¹޾� �ʱ�ȭ-> ������
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
    }//class
}
