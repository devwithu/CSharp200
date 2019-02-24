using System;
using System.Text;//StringBuilder
using System.Xml;//XmlTextReader,XmlDocument
using System.IO;//FileStream
namespace Com.JungBo.Fund {
  public class FundXmlRead {
      //xml�� ���ڿ��� 
    public XmlDocument XMLDomRead(string fname){
        XmlDocument doc = new XmlDocument();
        doc.Load(fname);// read 
        return doc;
    }//
    //xml�� ���ڿ��� 
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
            while (xtr.Read()){ //������Ʈ�� ����Ʈ
                if (xtr.NodeType == XmlNodeType.Element){
                    sb.Append("<" + xtr.Name);
                    for (int i = 0; i < xtr.AttributeCount; i++){
                        xtr.MoveToAttribute(i);  //�Ӽ����� �̵�
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
