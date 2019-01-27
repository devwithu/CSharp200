using System;
using System.Net;  //WebRequest, WebResponse
using System.IO;   //Stream
using System.Drawing;
using System.Drawing.Imaging;//ImageFormat
namespace Com.JungBo.WIO {
public class WebFiles {
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
    public Bitmap StreamToBitmap(Stream stream){
        Bitmap bit = new Bitmap(stream);
        return bit;
    }//
    public Bitmap DownloadBitmap(string url){
        WebClient web = new WebClient();
        byte[] downs = web.DownloadData(url);
        Bitmap bit = null;
        using (MemoryStream ms= new MemoryStream(downs)){
           bit = new Bitmap(ms);
        }
        return bit;
    }//
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
