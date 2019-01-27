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
        //left와 right가 거의(END) 같아 질때까지
        while (Math.Abs(left - right) > END){
            meanVal = (right + left) / 2.0;
            Console.WriteLine("l={0}, r={1}, c={2}",
                              left, right, meanVal);
            funct.X = left;
            double tl = funct.Function();//left값 구하기
            funct.X = right;
            double tr = funct.Function();//right 값 구하기
            funct.X = meanVal;//중간값
            double tc = funct.Function();
            if (tl * tc < 0){ //f(left)*f(meanVal)<0 
                right = meanVal;//meanVal가 right
            }
            else if (tl * tc > 0){//f(left)*f(meanVal)>0 
                left = meanVal;//meanVal가 left
            }else if(tc==0){
                break;
            }
        }
    }
    //중간값을 이용한 근
    public double MeanVal{
        get { return meanVal; }
    }
 }
}