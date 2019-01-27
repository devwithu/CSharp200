using System;
using Com.JungBo.Maths;
namespace FunctionProject {
 public class Program {
  public static void Main(string[] args){
    double[] mfunct ={-1,0,1,1 };
    //f(x)= -x^3 + x + 1
    Funct func = new Funct(mfunct);
    double right = 3;
    func.X = right;  //-27+3+1
    Console.WriteLine("f({0})={1}", right, func.Function());

    double left = -1;
    func.X = left;  //1-1+1
    Console.WriteLine("f({0})={1}", left, func.Function());

    MeanValue mean = new MeanValue(func, left, right);
    mean.Make();
    Console.WriteLine("f(x)=0�� ������Ű�� x={0}", mean.MeanVal);

    //Ȯ�� 
    func.X = mean.MeanVal;//���� �ٻ簪�� �ְ� Ȯ��
    Console.WriteLine("f({0})={1}", mean.MeanVal, func.Function());
  }
 }
}
