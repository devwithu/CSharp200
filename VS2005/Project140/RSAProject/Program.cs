using System;
namespace Com.JungBo.Logic {
public class Program{
    public static void Main(string[] args){
        Console.WriteLine("Twin---------------");
        PrimeNumber.PrintTwinPrime(1000000, 1002000);
        Console.WriteLine("Cousin---------------");
        PrimeNumber.PrintCousinPrime(1000000, 1002000);
    }
}
}
