using System;
using System.Net;  //WebRequest, WebResponse
using System.IO;   //Stream
using System.Drawing;
using System.Drawing.Imaging;//ImageFormat
namespace Com.JungBo.WIO {
public class WebFiles {
    //웹을 읽어서 스트림으로 만든다.
    public Stream ReadNWriteStock(string url){
        WebRequest request = null;
        WebResponse response = null;
        Stream stream = null;
        try{
            request = WebRequest.Create(url);
            response = request.GetResponse();
            stream = response.GetResponseStream() ;
        }
        catch (Exception ee){
            Console.WriteLine(ee.Message);
        }
        return stream;
    }//
    //스트림을 이미지로 바꾼다.
    public Bitmap StreamToBitmap(Stream stream){
        Bitmap bit = new Bitmap(stream);
        return bit;
    }//
    //웹에서 이미지를 받는다.
    public Bitmap DownloadBitmap(string url){
        WebClient web = new WebClient();
        byte[] downs = web.DownloadData(url);
        Bitmap bit = null;
        using (MemoryStream ms= new MemoryStream(downs)){
           bit = new Bitmap(ms);
        }
        return bit;
    }//
    //이미지를 저장한다.
    public void SaveMemoryStream(Bitmap bit, string FileName) {
        MemoryStream ms = new MemoryStream();
        //ImageFormat이용 이미지종류를 다르게 할 수 있다.
        bit.Save(ms, ImageFormat.Bmp);
        using (FileStream outStream = File.OpenWrite(FileName)) {
            ms.WriteTo(outStream);  //이미지 저장
            outStream.Close();
        }
    }
}
}
