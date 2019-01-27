using System;
using System.Net;  //WebClient
using System.IO;   //StreamReader, Stream
namespace Com.JungBo.Webs {
 public class WebReading {
     //웹화면의 HTML을 모두 가져온다.
    public string WebRead(string url) {
        WebClient web = new WebClient();  
        string str = "";
        using (Stream stream = web.OpenRead(url)) {
            using (StreamReader sr = new StreamReader(stream)){
                str = sr.ReadToEnd();
            }
        }
        return str;
    }//
    //웹화면의 HTML을 모두 가져온다.
    public string DownloadString(string url){
        WebClient web = new WebClient();
        string str = web.DownloadString(url);
        return str;
    }//
    //그림이나 파일을 저장한다.
    public void DownloadString(string url,string fname){
        WebClient web = new WebClient();
        web.DownloadFile(url, fname);
    }//
 }
}
