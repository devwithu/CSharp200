using System;
using Com.JungBo.Maths;
namespace FunctionProject {
 public class Program {
  public static void Main(string[] args){

    //Srqt(2)�� ������ 1.5�� �̿�->1.42xxx
    Console.WriteLine(YenaMath.Sqrt(2,1.5));

    //Srqt(100)�� ������ 20�� �̿�->10
    Console.WriteLine(YenaMath.Sqrt(100, 20));
  }
 }
}
