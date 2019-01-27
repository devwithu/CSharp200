using System;
using System.Collections.Generic;
namespace FundProject{
    public class Program{
        public static void Main(string[] args){
string url = "http://www.krx.co.kr/popup/current_market_condition.jsp";
            StockReading stocks = new StockReading();
            stocks.ReadNWriteStock3(url);
            stocks.StockTables();
            StringToFundData stfd = new StringToFundData();
            List<FundData> lfd = stfd.ToFundData(stocks.StringTables);
            stfd.WriteXmlToString(lfd,"../../fundxml"
                   +DateTime.Now.ToString("yyyyMMddhhmmss")+".xml");
        }
    }
}
