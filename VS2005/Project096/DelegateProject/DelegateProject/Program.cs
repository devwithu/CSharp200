using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic {
    public class Program {
        public static void Main(string[] args){

            StringToFundData stfd = new StringToFundData();
            stfd.FundDataForMarathone();//�����ֽ� �������̱�
            Console.WriteLine("----------------");
            stfd.FundData("CJ", "KTF");//CJ~KTGxxx�� ����ִ°͵�
        }
    }
}
