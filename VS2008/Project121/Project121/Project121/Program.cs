using System;
using Com.JungBo.Webs;
namespace Project121
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebReading wread = new WebReading();
            string url = "http://www.hankyung.com";
            string str = wread.WebRead(url);
            Console.WriteLine(str);

            string picurl =
    "http://www.hankyung.com/img/top_title_news.gif";
            string topic = "../../top_title_news.gif";
            //string picurl =
            //"http://www.hankyung.com";
            //         string topic = "../../aaa.txt";
            wread.DownloadString(picurl, topic);
        }
    }
}
