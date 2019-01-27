using System;
namespace Com.JungBo.Maths {
 public class MeanValue {
    public const double END = 0.00000000000001;
    private Funct funct;
    private double left;//left
    private double right;
    private double meanVal;
    public MeanValue(Funct ff, double l, double r) {
        funct = ff;
        this.left = l;
        this.right = r;
    }
    public void Make(){
        //left�� right�� ����(END) ���� ��������
        while (Math.Abs(left - right) > END){
            meanVal = (right + left) / 2.0;
            Console.WriteLine("l={0}, r={1}, c={2}",
                              left, right, meanVal);
            funct.X = left;
            double tl = funct.Function();//left�� ���ϱ�
            funct.X = right;
            double tr = funct.Function();//right �� ���ϱ�
            funct.X = meanVal;//�߰���
            double tc = funct.Function();
            if (tl * tc < 0){ //f(left)*f(meanVal)<0 
                right = meanVal;//meanVal�� right
            }
            else if (tl * tc > 0){//f(left)*f(meanVal)>0 
                left = meanVal;//meanVal�� left
            }else if(tc==0){
                break;
            }
        }
    }
    //�߰����� �̿��� ��
    public double MeanVal{
        get { return meanVal; }
    }
 }
}