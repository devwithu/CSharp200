using System;
using System.Text;
using System.Xml;
using System.IO;
namespace Com.JungBo.Fund {
 public class FunXmlWrite {
    //fname을 읽어서 savename에 저장
    public void XMLFileReadWrite(string fname, string savename) {
     //PI가 자동으로 붙음
     using (XmlTextWriter xwr = 
               new XmlTextWriter(savename, Encoding.Default)) {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fname);
        ////XML에 PI가 없다면 붙일 수 있다.
        //xwr.WriteProcessingInstruction("xml",
        //    "version='1.0' encoding='ks_c_5601-1987'");
        xwr.Formatting = Formatting.Indented;
        xmlDoc.Save(xwr);
     }
    }//
    //읽어서 콘솔에 출력
    public void XMLConsoleWrite(string fname){
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fname);
        xmlDoc.Save(Console.Out);
    }//
     //Dom을 파일로 저장
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

