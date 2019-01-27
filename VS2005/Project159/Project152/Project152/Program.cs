using System;
using Com.JungBo.Logic;
namespace Project154{
 public class Program{
    public static void Main(string[] args){
        IReduceFraction irdf1 = new IReduceFraction(30, 60);
        IReduceFraction irdf2 = new IReduceFraction(6, 20);
        IReduceFraction irdf3 = irdf1 + irdf2;
        IReduceFraction irdf4 = irdf1 - irdf2;
        Console.WriteLine(irdf1.ToString());
        Console.WriteLine(irdf2.ToString());
        Console.WriteLine(irdf3.ToString());
        Console.WriteLine(irdf4.ToString());
    }
 }
}
