using System;
namespace Com.JungBo.Logic{
 public class Program{
    public static void Main(string[] args){
        Floyd floy = new Floyd();
        floy.PrintPath();
        Console.WriteLine("-----------------------------");
        floy.Distance();
        floy.PrintPath();
        int start = 1;//P2
        int goal = 2;//P3
        Console.Write("{0} -> ", floy.name[start]);
        floy.Path(start, goal);
        Console.Write("{0}", floy.name[goal]);
        Console.WriteLine();    
    }
 }
}
