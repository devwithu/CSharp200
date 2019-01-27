using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringToFundData stfd = new StringToFundData();
            stfd.FundDataForMarathone();//관심주식 정보보이기
            Console.WriteLine("----------------");
            stfd.FundData("CJ", "KTF");//CJ~KTGxxx가 들어있는것들
        }
    }
}
