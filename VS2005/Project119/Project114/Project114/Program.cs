using System;
using System.Xml;//XmlDocument
using Com.JungBo.Fund;
namespace Project114 {
 public class Program {
  public static void Main(string[] args){
      string xmlfname = "../../fundxml20080612081256.xml";
      string xmlfname2 = "../../FundAttribute.xml";
    FundXmlRead fxr = new FundXmlRead();
    XmlDocument doc = fxr.XMLDomRead(xmlfname);
    //Console.WriteLine(doc.OuterXml);//��Ʈ ������Ʈ�� �ڽ��� ��� ������
    Console.WriteLine(doc.InnerXml);//���� ������Ʈ�� �ڽ��� ��� ������
    string s2 = fxr.XMLStringRead(xmlfname2);
    Console.WriteLine(s2);
    string s3 = fxr.XMLFileStreamRead(xmlfname2);
    Console.WriteLine(s3);
  }
 }
}