using System;
using System.Xml;//XmlDocument
using Com.JungBo.Fund;


namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string xmlfname = "../../fundxml20080612081256.xml";

            FundXmlRead read = new FundXmlRead();
            FunXmlWrite fxw = new FunXmlWrite();
            //Dom으로 읽기
            XmlDocument doc = read.XMLDomRead(xmlfname);
            //Dom을 파일로 저장
            fxw.SaveXmlDom("../../ddd.xml", doc);

            //콘솔에 출력
            fxw.XMLConsoleWrite(xmlfname);
            //c로 저장
            fxw.XMLFileReadWrite(xmlfname, "../../c.xml");
        }
    }
}