using System;
using Com.JungBo.Logic;
namespace DictioaryProject{
    public class Program{
        static void Main(string[] args){
            CardDictionary dic = new CardDictionary();
            dic.MakeCards();
            dic.PrintCards();
            Console.WriteLine("-------------------------");
            dic.Suffle();
            dic.PrintCards();
        }
    }
}
