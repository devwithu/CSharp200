using System;
using Com.JungBo.Infor;
namespace EnumerableProject{
    public class Program{
        public static void Main(string[] args){
            FundInform inform = new FundInform();
            inform.PrintFunds1();  //�ݵ��������
            Console.WriteLine("-------------");
            inform.PrintFunds2();//�ݵ��������
            Console.WriteLine("-------------");
            inform.PrintFunds3();//�ݵ��������
            Console.WriteLine("-------------");
            //�ݵ��������
            foreach (string var in inform.GetAllFunds()){
                Console.WriteLine(var);
            }
        }
    }
}
