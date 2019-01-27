using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
namespace Com.JungBo.Fund {
 public class FunXmlTransform {
     //�̰͸� å�� ���� ��.
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
         //xsl �б�
         transform.Load(xsl);
         StringReader sr = null;
         XmlReader xmlReader = null;
         XmlWriter xmlWriter = null;
         try{
             //xml �б�
             sr = new StringReader(doc.OuterXml);
             xmlReader = XmlReader.Create(sr);
             //html �����
             XmlWriterSettings setting = new XmlWriterSettings();
             setting.ConformanceLevel = ConformanceLevel.Auto;
             xmlWriter = XmlWriter.Create(html, setting);
             //��ȯ
             transform.Transform(xmlReader, xmlWriter);
         }
         catch (Exception ee){
             Console.WriteLine(ee.Message);
         }
         finally {//�ݵ�� �ݱ�
             xmlWriter.Close();
             xmlReader.Close();
             sr.Close();
         }
     }
 }
}

