using System;
using System.Text;//StringBuilder
using System.Xml;//XmlTextReader,XmlDocument
using System.IO;//FileStream
namespace Com.JungBo.Fund {
  public class FundXmlRead {

      public XmlDocument XMLDomRead(string fname){
        XmlDocument doc = new XmlDocument();
        doc.Load(fname);
        return doc;
      }//

    public string XMLStringRead(string fname){
        using (XmlTextReader xtr = new XmlTextReader(fname)) {
            XmlDocument doc = new XmlDocument();
            doc.Load(xtr);
            xtr.Close();
            return doc.OuterXml;
        }
    }//
    //파일스트림 이용,  PI가 붙지 않는다.
    public string XMLFileStreamRead(string fname){
        StringBuilder sb = new StringBuilder();
       using(FileStream fstream 
                       = new FileStream(fname, FileMode.Open)){
        using (XmlTextReader xtr = new XmlTextReader(fstream)){
            //XmlReader xtr = XmlReader.Create(fstream);
            while (xtr.Read()){
                if (xtr.NodeType == XmlNodeType.Element){
                    sb.Append("<" + xtr.Name);
                    for (int i = 0; i < xtr.AttributeCount; i++){
                        xtr.MoveToAttribute(i);
                        sb.Append(string.Format(" {0}='{1}' ",
                                         xtr.Name, xtr.Value));
                    }
                    sb.Append(">\n");
                }
                else if (xtr.NodeType == XmlNodeType.Text){
                    sb.Append(xtr.Value+"\n");
                }
                else if (xtr.NodeType == XmlNodeType.EndElement){
                    sb.Append("</" + xtr.Name + ">\n");
                }
            }
        }//using
      }//using
        return sb.ToString();
    }//
  }
}
