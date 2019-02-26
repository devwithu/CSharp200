using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Com.JungBo.Basic
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
        public const int PORT = 5555;
        public const string IP = "127.0.0.1";

        public void Echo()
        {
            NetworkStream ns = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            TcpClient client = null;
            try
            {
                //1) 클라이언트 소켓을 준비한다.
                client = new TcpClient(IP, PORT);//소켓
                Console.WriteLine("client~~서버에 접속");
                //2) 소켓에 있는 메세지를 이동시킬 통로준비
                ns = client.GetStream();
                //3) 소켓에서 모니터로 읽기위한 스트림
                sr = new StreamReader(ns, Encoding.Default);
                //4) 모니터에서 소켓으로 메세지를 보내기 위한 스트림
                sw = new StreamWriter(ns, Encoding.Default);
                string ss = string.Empty;
                //ctrl+c
                Console.WriteLine("입력하세요");
                //5) 키보드로 메세지를 입력한다.
                while ((ss = Console.ReadLine()) != null)
                {
                    //6) 서버로 보낸다.
                    sw.WriteLine(ss);//서버로 보내기
                    sw.Flush();
                    //7) 서버에서 돌아온 메세지를 받는다.
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