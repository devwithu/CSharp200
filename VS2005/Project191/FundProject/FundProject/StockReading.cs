using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Xml;
namespace FundProject{
public class StockReading{
//xxx.html 웹 문서를 읽어서 원하는 부분만 파일로 저장한다.
//<div id='dataDisplay'부분을 찾아서 저장
List<string> stockTables = new List<string>();
//주식정보를 담는 테이블을 저장한다.
List<string> stringTables = new List<string>();

public List<string> StringTables{
    get { return stringTables; }
}
public int Count {
    get { return StringTables.Count; }
}
//xxx.html 웹 문서를 읽어서 원하는 부분만 파일로 저장한다.
//<div id='dataDisplay'부분을 찾아서 stockTables에 저장
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
                    //다음줄
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
    //xxx 이후 문장을 얻는다.
    string str = stockTables[0].Substring("<table".Length);
    //yyyy1  table을 찾는다.
    int sindex = str.IndexOf("<table");
    //<table yyyy1과 이후문장을 얻는다. 
    str = str.Substring(sindex);
    //<table yyyy1 위치를 찾고
    sindex = str.IndexOf("<table");
    //어쩌구 1제거
    str = str.Substring(sindex);
    sindex = str.IndexOf("<table");
    //<table yyyy1과 쌍을 이루는 </table찾기
    int eindex = str.IndexOf("</table");
    //<table xxx>와 쌍을 이루는 끝 </table을 찾는다.
    int lastindex = str.LastIndexOf("</table");
    //마지막 </table을 제거한다. 어쩌구 2와 </table>제거
    str = str.Substring(0, lastindex); //
    //   <table yyyy1>
    //       주식정보 1
    //   </table>
    string fstr = str.Substring(sindex, eindex - sindex
                                + ("</table>".Length));
    //그 이후 문장
    string lstr = str.Substring(eindex - sindex 
                               + ("</table>".Length));
    StringTables.Add(fstr);
    sindex = lstr.IndexOf("<table");
    eindex = lstr.IndexOf("</table");
    //저쩌구 2를 제거한다.
    lstr = lstr.Substring(sindex);
    while (lstr.Length > 0) {
        //아래와 같이 쌍을 이루는 문장을 얻는다.
        //   <table yyyykkk>
        //       주식정보 kkk
        //   </table>
        //       저쩌구 kkk
        sindex = lstr.IndexOf("<table");
        eindex = lstr.IndexOf("</table");
        if (sindex < 0 || eindex < 0) { break; }
        fstr = lstr.Substring(sindex, eindex - sindex 
                               + ("</table>".Length));
        lstr = lstr.Substring(eindex - sindex 
                              + ("</table>".Length));
        StringTables.Add(fstr);
        //저쩌구 kkk를 제거한다.
        lstr = lstr.Substring(sindex);
    }
 }
  }
}