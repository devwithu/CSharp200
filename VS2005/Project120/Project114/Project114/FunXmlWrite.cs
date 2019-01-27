using System;
using System.Text;
using System.Xml;
using System.IO;
namespace Com.JungBo.Fund {
 public class FunXmlWrite {
    //fname�� �о savename�� ����
    public void XMLFileReadWrite(string fname, string savename) {
     //PI�� �ڵ����� ����
     using (XmlTextWriter xwr = 
               new XmlTextWriter(savename, Encoding.Default)) {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fname);
        ////XML�� PI�� ���ٸ� ���� �� �ִ�.
        //xwr.WriteProcessingInstruction("xml",
        //    "version='1.0' encoding='ks_c_5601-1987'");
        xwr.Formatting = Formatting.Indented;
        xmlDoc.Save(xwr);
     }
    }//
    //�о �ֿܼ� ���
    public void XMLConsoleWrite(string fname){
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fname);
        xmlDoc.Save(Console.Out);
    }//
     //Dom�� ���Ϸ� ����
     public void SaveXmlDom(string fname,XmlDocument doc ){
         XmlWriterSettings setting = new XmlWriterSettings();
         setting.ConformanceLevel = ConformanceLevel.Auto;
         setting.Encoding = System.Text.Encoding.Default;
         setting.Indent = true;
         using (XmlWriter xmlWriter = XmlWriter.Create(fname, setting)) { 
                  doc.WriteTo(xmlWriter);
                  xmlWriter.Close();
         }
     }//
 }
}

