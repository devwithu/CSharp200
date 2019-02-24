using System;
using System.Text;//StringBuilder
using System.Xml;//XmlTextReader,XmlDocument
using System.IO;//FileStream
namespace Com.JungBo.Fund {
  public class FundXmlRead {
      //xml을 문자열로 
    public XmlDocument XMLDomRead(string fname){
        XmlDocument doc = new XmlDocument();
        doc.Load(fname);// read 
        return doc;
    }//
    //xml을 문자열로 
    public string XMLStringRead(string fname){
        using (XmlTextReader xtr = new XmlTextReader(fname)) {
            XmlDocument doc = new XmlDocument();
            doc.Load(xtr);
            xtr.Close();
            return doc.OuterXml;
        }
    }//
    public string XMLFileStreamRead(string fname){
        StringBuilder sb = new StringBuilder();
       using(FileStream fstream 
                       = new FileStream(fname, FileMode.Open)){
        using (XmlTextReader xtr = new XmlTextReader(fstream)){
            //XmlReader xtr = XmlReader.Create(fstream);
            while (xtr.Read()){ //엘리먼트나 컨텐트
                if (xtr.NodeType == XmlNodeType.Element){
                    sb.Append("<" + xtr.Name);
                    for (int i = 0; i < xtr.AttributeCount; i++){
                        xtr.MoveToAttribute(i);  //속성으로 이동
                        sb.Append(string.Format(" {0}='{1}' ",
                                         xtr.Name, xtr.Value));
                    }
                    sb.Append("> \n");
                }
                else if (xtr.NodeType == XmlNodeType.Text){
                    sb.Append(xtr.Value+" \n");
                }
                else if (xtr.NodeType == XmlNodeType.EndElement){
                    sb.Append("</" + xtr.Name + "> \n");
                }
            }
        }//using
      }//using
        return sb.ToString();
    }//
  }
}
