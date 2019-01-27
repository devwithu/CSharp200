using System;
using System.Net;  //WebClient
using System.IO;   //StreamReader, Stream
namespace Com.JungBo.Webs {
 public class WebReading {
     //��ȭ���� HTML�� ��� �����´�.
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
    //��ȭ���� HTML�� ��� �����´�.
    public string DownloadString(string url){
        WebClient web = new WebClient();
        string str = web.DownloadString(url);
        return str;
    }//
    //�׸��̳� ������ �����Ѵ�.
    public void DownloadString(string url,string fname){
        WebClient web = new WebClient();
        web.DownloadFile(url, fname);
    }//
 }
}
