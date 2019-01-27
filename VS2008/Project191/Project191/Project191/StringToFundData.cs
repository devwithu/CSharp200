using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.IO;
namespace FundProject {
    public class StringToFundData {
  //FundData������ ����
  public List<FundData> ToFundData(List<string> fls){
    List<FundData> fld = new List<FundData>();
    foreach (string  str in fls){
        fld.Add(ToFundData(str));
    }
    return fld;
  }
  //�ֽ� ������ �̾Ƽ� FundData�� �����
  public FundData ToFundData(string funds){
    string fundName = string.Empty;
    string fundPrice = string.Empty;
    string prevPrice = string.Empty;//������ �������� ������
    int opp = funds.Contains("tri_blue_down.gif") ? -1 : 1;
    int idFIndex = funds.IndexOf("<td");
    int idLIndex = funds.IndexOf("</td>");
    //<td     >CJ  ���� <td     ����-->  >CJ 
    string idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    funds = funds.Substring(idLIndex + ("</td>".Length));
    int idgtTag = idstring.IndexOf(">");//>ã��
    //�ѱ۹��� valign="top">CJ���ͳ�            </td>
    idstring = idstring.Trim().Substring(idgtTag + (">").Length);//>����
    fundName = idstring;
    idFIndex = funds.IndexOf("<td");
    idLIndex = funds.IndexOf("</td>");
    idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    funds = funds.Substring(idLIndex + ("</td>".Length));
    idgtTag = idstring.IndexOf(">");//>ã��
    idstring = idstring.Substring(idgtTag + 1);//>����
    fundPrice = idstring;
    idFIndex = funds.ToUpper().IndexOf("<FONT");
    idLIndex = funds.ToUpper().IndexOf("</FONT>");
    idstring = funds.Substring(idFIndex, idLIndex - idFIndex);
    idgtTag = idstring.IndexOf(">");//>ã��
    idstring = idstring.Substring(idgtTag + 1);//>����
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
