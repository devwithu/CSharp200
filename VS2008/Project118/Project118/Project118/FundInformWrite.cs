using System;
using System.Text;
namespace Com.JungBo.Fund {
 public class FundInformWrite {
    //CSV 데이터  --> XML
    public string ToDataXML(string fundindex){
        //"CJ,65400,-1100"  -->
        //{"CJ","65400","-1100"}로 변환
        string[] funds = XMLUtil.ToFund(fundindex);
        //아래와 같이 바꾸기
        //<stock>
        //  <stockname>CJ</stockname>
        //  <stockprice>65400</stockprice>
        //  <prevstockprice>-1100</prevstockprice>
        //</stock>
        StringBuilder sb = new StringBuilder();
        sb.Append("<stock> \n");
        sb.Append("\t <stockname>");
        sb.Append(XMLUtil.ToEntity(funds[0]));//"CJ"
        sb.Append("</stockname> \n");
        sb.Append("\t <stockprice>");
        sb.Append(funds[1]);//"65400"
        sb.Append("</stockprice> \n");
        sb.Append("\t <prevstockprice>");
        sb.Append(funds[2]);//"-1100"
        sb.Append("</prevstockprice> \n");
        sb.Append("</stock> \n");
        return sb.ToString();
    }
    public string ToDataXML(string[] fundlist){
        StringBuilder sb = new StringBuilder();
        sb.Append("<?xml version='1.0' encoding='euc-kr'> \n");
        sb.Append("<kosdaq> \n");
        foreach (string fundstr in fundlist){
            sb.Append(ToDataXML(fundstr));
        }
        sb.Append("</kosdaq>");
        return sb.ToString();
    }
 }
}
