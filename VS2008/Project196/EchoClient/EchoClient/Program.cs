using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Com.JungBo.Chat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EchoClient client = new EchoClient();
            client.Echo();
        }
    }

    public class EchoClient
    {
        public const int PORT = 9000;
        public const string IP = "10.10.10.39";

        public void Echo()
        {
            NetworkStream ns = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            TcpClient client = null;

            try
            {
                client = new TcpClient(IP, PORT);//소켓
                Console.WriteLine("client~~서버에 접속");
                ns = client.GetStream();
                sr = new StreamReader(ns, Encoding.Default);
                sw = new StreamWriter(ns, Encoding.Default);
                string ss = string.Empty;
                //ctrl+c
                Console.WriteLine("이름을 입력하세요");
                string name = Console.ReadLine();//이름
                while ((ss = Console.ReadLine()) != null)
                {
                    sw.WriteLine(string.Format("[{0}]: {1}", name, ss));//서버로 보내기
                    sw.Flush();
                    string message = sr.ReadLine();//서버에서 받기
                    Console.WriteLine(message);//내화면에 출력
                }
            }
            catch (Exception ee)
            {
                System.Console.WriteLine(ee.Message);

            }
            finally
            {
                sw.Close();
                sr.Close();
                client.Close();
            }
        }
    }
}
