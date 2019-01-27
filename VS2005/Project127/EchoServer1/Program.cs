using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Com.Kaoni.Echo{
    public class Program{
        public static void Main(string[] args){
            EchoServer server = new EchoServer();
            server.Echo();
       }
    }

    public class EchoServer {
        public const int PORT = 5555;

        public void Echo() {
            TcpListener listener=null;
            NetworkStream ns = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            TcpClient client = null;
            try
            {
                IPAddress address = Dns.GetHostEntry("").AddressList[0];
                //1) 서버소켓 준비하기 시작하기
                listener = new TcpListener(address, PORT);
                listener.Start();
                Console.WriteLine("server 1~~ready");

                while(true){
                    Console.WriteLine("while 2~~ready");
                    //2) 클라이언트가 서버소켓에 접속하면 담당 소켓생성
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("while 3~~Accept");
                    //3) 소켓에 있는 메세지를 이동시킬 통로준비
                    ns = client.GetStream();
                    //4) 소켓에서 모니터로 읽기
                    sr = new StreamReader(ns, Encoding.Default);
                    //5) 모니터에서 소켓에 쓰기
                    sw = new StreamWriter(ns, Encoding.Default);
                    while (true) {
                        //6) 소켓에서 문자열 읽기
                        string message = sr.ReadLine();
                        //7) 소켓에 문자열 돌려보내기(echo)
                        sw.WriteLine("[server: {0}]", message);
                        sw.Flush();
                    }
                }
            }
            catch (Exception ee){
                System.Console.WriteLine(ee.Message);
            }
            finally {
                //8) 사용후 닫기
                if(sw!=null)sw.Close();
                if (sr != null) sr.Close();
                if (client != null) client.Close();
                listener.Stop();
            }
        }
    }
}
