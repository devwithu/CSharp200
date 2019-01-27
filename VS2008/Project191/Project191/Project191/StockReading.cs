using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Xml;
namespace FundProject{
public class StockReading{
//xxx.html �� ������ �о ���ϴ� �κи� ���Ϸ� �����Ѵ�.
//<div id='dataDisplay'�κ��� ã�Ƽ� ����
List<string> stockTables = new List<string>();
//�ֽ������� ��� ���̺��� �����Ѵ�.
List<string> stringTables = new List<string>();

public List<string> StringTables{
    get { return stringTables; }
}
public int Count {
    get { return StringTables.Count; }
}
//xxx.html �� ������ �о ���ϴ� �κи� ���Ϸ� �����Ѵ�.
//<div id='dataDisplay'�κ��� ã�Ƽ� stockTables�� ����
public void ReadNWriteStock3(string url){
    WebRequest request = null;
    WebResponse response = null;
    try{
        request = WebRequest.Create(url);
        response = request.GetResponse();
        string message = string.Empty;
        using (StreamReader sr =
            new StreamReader(response.GetResponseStream(),
                                         Encoding.Default)){
            string ss = DateTime.Now.ToString("yyyyMMddhhmmss");
            Console.WriteLine("Reading!!----");
            while ((message = sr.ReadLine()) != null){
                // <div id="dataDisplay"
                if (message.Contains("<div id=\"dataDisplay\"")){
                    //������
                    message = sr.ReadLine();
                    stockTables.Add(message.Trim());
                }
            }
            Console.WriteLine("Reading End");
            sr.Close();
        }
    }
    catch (Exception ee){
        Console.WriteLine(ee.Message);
    }
}//
 public void StockTables(){
    //xxx ���� ������ ��´�.
    string str = stockTables[0].Substring("<table".Length);
    //yyyy1  table�� ã�´�.
    int sindex = str.IndexOf("<table");
    //<table yyyy1�� ���Ĺ����� ��´�. 
    str = str.Substring(sindex);
    //<table yyyy1 ��ġ�� ã��
    sindex = str.IndexOf("<table");
    //��¼�� 1����
    str = str.Substring(sindex);
    sindex = str.IndexOf("<table");
    //<table yyyy1�� ���� �̷�� </tableã��
    int eindex = str.IndexOf("</table");
    //<table xxx>�� ���� �̷�� �� </table�� ã�´�.
    int lastindex = str.LastIndexOf("</table");
    //������ </table�� �����Ѵ�. ��¼�� 2�� </table>����
    str = str.Substring(0, lastindex); //
    //   <table yyyy1>
    //       �ֽ����� 1
    //   </table>
    string fstr = str.Substring(sindex, eindex - sindex
                                + ("</table>".Length));
    //�� ���� ����
    string lstr = str.Substring(eindex - sindex 
                               + ("</table>".Length));
    StringTables.Add(fstr);
    sindex = lstr.IndexOf("<table");
    eindex = lstr.IndexOf("</table");
    //��¼�� 2�� �����Ѵ�.
    lstr = lstr.Substring(sindex);
    while (lstr.Length > 0) {
        //�Ʒ��� ���� ���� �̷�� ������ ��´�.
        //   <table yyyykkk>
        //       �ֽ����� kkk
        //   </table>
        //       ��¼�� kkk
        sindex = lstr.IndexOf("<table");
        eindex = lstr.IndexOf("</table");
        if (sindex < 0 || eindex < 0) { break; }
        fstr = lstr.Substring(sindex, eindex - sindex 
                               + ("</table>".Length));
        lstr = lstr.Substring(eindex - sindex 
                              + ("</table>".Length));
        StringTables.Add(fstr);
        //��¼�� kkk�� �����Ѵ�.
        lstr = lstr.Substring(sindex);
    }
 }
  }
}