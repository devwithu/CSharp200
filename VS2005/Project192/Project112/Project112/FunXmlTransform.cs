using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
namespace Com.JungBo.Fund {
 public class FunXmlTransform {
     //이것만 책에 넣을 것.
     public void TransToHtml(string xml, string xsl, string html) {
         XslCompiledTransform transform 
                    = new XslCompiledTransform();
         try{
             transform.Load(xsl);
             transform.Transform(xml, html);
         }
         catch (Exception  ee){ 
             Console.WriteLine(ee.Message);
         }
     }//
     public void TransToHtml(XmlDocument doc, string xsl, string html){
         XslCompiledTransform transform
                    = new XslCompiledTransform();
         //xsl 읽기
         transform.Load(xsl);
         StringReader sr = null;
         XmlReader xmlReader = null;
         XmlWriter xmlWriter = null;
         try{
             //xml 읽기
             sr = new StringReader(doc.OuterXml);
             xmlReader = XmlReader.Create(sr);
             //html 저장용
             XmlWriterSettings setting = new XmlWriterSettings();
             setting.ConformanceLevel = ConformanceLevel.Auto;
             xmlWriter = XmlWriter.Create(html, setting);
             //변환
             transform.Transform(xmlReader, xmlWriter);
         }
         catch (Exception ee){
             Console.WriteLine(ee.Message);
         }
         finally {//반드시 닫기
             xmlWriter.Close();
             xmlReader.Close();
             sr.Close();
         }
     }
 }
}

