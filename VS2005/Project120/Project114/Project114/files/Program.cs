using System;
using System.Xml;
using Com.JungBo.Fund;
namespace Project114 {
 public class Program {
  public static void Main(string[] args){
    string xmlfname = "../../fundxml20080612081256.xml";
    string xmlfname2 = "../../fundxml20080612081255.xml";
    FundXmlRead read=new FundXmlRead();
    FunXmlWrite fxw = new FunXmlWrite();
    //Dom���� �б�
    XmlDocument doc = read.XMLDomRead(xmlfname);
    //Dom�� ���Ϸ� ����
    fxw.SaveXmlDom("../../ddd.xml", doc);

    //�ֿܼ� ���
    fxw.XMLConsoleWrite(xmlfname);
    //c�� ����
    fxw.XMLFileReadWrite(xmlfname, "../../c.xml");
  }
 }
}