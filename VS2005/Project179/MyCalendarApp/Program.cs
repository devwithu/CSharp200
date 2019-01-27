using System;
namespace Com.JungBo.Logic {
 public class Program{
  public static void Main(string[] args){
    LivingDateTime living = new LivingDateTime(1979, 6, 22);
    living.SetToDay(2008, 8, 17);
    //몇일 살았나
    Console.WriteLine(living.HowLong());
    living.NextDay();
    Console.WriteLine(living.HowLong());
    living.PerviousDay();
    Console.WriteLine(living.HowLong());
    Console.WriteLine(living.Emotial());
    Console.WriteLine(living.Intellectual());
    Console.WriteLine(living.Perceptive());
  }
 }
}
