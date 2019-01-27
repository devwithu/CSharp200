using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.IO;
namespace FundProject {
    public class StringToFundData {
  //FundData단위로 저장
  public List<FundData> ToFundData(List<string> fls){
    List<FundData> fld = new List<FundData>();
    foreach (string  str in fls){
        fld.Add(ToFundData(str));
    }
    return fld;
  }
  //주식 정보를 뽑아서 FundData로 만든다
  public FundData ToFundData(string funds){
    string fundName = string.Empty;
    string fundPrice = string.Empty;
    string prevPrice = string.Empty;//음수면 전날보다 내려감
    int opp = funds.Contains("tri_blue_down.gif") ? -1 : 1;
    int idFIndex = funds.IndexOf("<td");
    int idLIndex = funds.IndexOf("</td>");
    //<td     >CJ  에서 <td     제거-->  >CJ 
    string idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    funds = funds.Substring(idLIndex + ("</td>".Length));
    int idgtTag = idstring.IndexOf(">");//>찾기
    //한글문제 valign="top">CJ인터넷            </td>
    idstring = idstring.Trim().Substring(idgtTag + (">").Length);//>제거
    fundName = idstring;
    idFIndex = funds.IndexOf("<td");
    idLIndex = funds.IndexOf("</td>");
    idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    funds = funds.Substring(idLIndex + ("</td>".Length));
    idgtTag = idstring.IndexOf(">");//>찾기
    idstring = idstring.Substring(idgtTag + 1);//>제거
    fundPrice = idstring;
    idFIndex = funds.ToUpper().IndexOf("<FONT");
    idLIndex = funds.ToUpper().IndexOf("</FONT>");
    idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    idgtTag = idstring.IndexOf(">");//>찾기
    idstring = idstring.Substring(idgtTag + 1);//>제거
    prevPrice = opp > 0 ? idstring : "-" + idstring;
    FundData fd = new FundData(fundName, fundPrice, prevPrice);
    return fd;
  }
  public void WriteXmlToString(List<FundData> fld, string filepath){
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Encoding = System.Text.Encoding.UTF8;
    settings.Indent = true;
    XmlWriter xmlWriter = XmlWriter.Create(filepath, settings);
    xmlWriter.WriteStartElement("kosdaq");
    foreach (FundData fdd in fld){
        xmlWriter.WriteStartElement("stock");
            
            xmlWriter.WriteStartElement("stockname");
            xmlWriter.WriteString(fdd.FundName);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("stockprice");
            xmlWriter.WriteString(fdd.FundPrice.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("prevstockprice");
            xmlWriter.WriteString(fdd.PrevPrice.ToString());
            xmlWriter.WriteEndElement();
        xmlWriter.WriteEndElement();
    }
    xmlWriter.WriteEndElement();
    xmlWriter.Close();
  }
 }
}
