using System;
using System.Net;  //WebRequest, WebResponse
using System.IO;   //Stream
using System.Drawing;
using System.Drawing.Imaging;//ImageFormat
namespace Com.JungBo.WIO {
public class WebFiles {
    //���� �о ��Ʈ������ �����.
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
    //��Ʈ���� �̹����� �ٲ۴�.
    public Bitmap StreamToBitmap(Stream stream){
        Bitmap bit = new Bitmap(stream);
        return bit;
    }//
    //������ �̹����� �޴´�.
    public Bitmap DownloadBitmap(string url){
        WebClient web = new WebClient();
        byte[] downs = web.DownloadData(url);
        Bitmap bit = null;
        using (MemoryStream ms= new MemoryStream(downs)){
           bit = new Bitmap(ms);
        }
        return bit;
    }//
    //�̹����� �����Ѵ�.
    public void SaveMemoryStream(Bitmap bit, string FileName) {
        MemoryStream ms = new MemoryStream();
        //ImageFormat�̿� �̹��������� �ٸ��� �� �� �ִ�.
        bit.Save(ms, ImageFormat.Bmp);
        using (FileStream outStream = File.OpenWrite(FileName)) {
            ms.WriteTo(outStream);  //�̹��� ����
            outStream.Close();
        }
    }
}
}
