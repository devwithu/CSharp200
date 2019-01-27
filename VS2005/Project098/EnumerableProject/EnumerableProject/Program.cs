using System;
using Com.JungBo.Infor;
namespace EnumerableProject{
    public class Program{
        public static void Main(string[] args){
            FundInform inform = new FundInform();
            inform.PrintFunds1();  //펀드정보출력
            Console.WriteLine("-------------");
            inform.PrintFunds2();//펀드정보출력
            Console.WriteLine("-------------");
            inform.PrintFunds3();//펀드정보출력
            Console.WriteLine("-------------");
            //펀드정보출력
            foreach (string var in inform.GetAllFunds()){
                Console.WriteLine(var);
            }
        }
    }
}
