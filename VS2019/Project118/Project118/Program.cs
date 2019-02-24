using System;
using Com.JungBo.Fund;


namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CSV  ->  XML로 변환하기
            string[] fundList ={
        "CJ,65400,-1100",
        "CJ인터넷,16200,200",
        "KT&G, 64800, -1800"};

            FundInformWrite fw = new FundInformWrite();
            //xml로 바꿔서 출력
            string fundstring = fw.ToDataXML(fundList);
            Console.WriteLine(fundstring);
        }
    }
}