using System;
using System.Text;//Encoding
using System.IO;//StreamReader
using System.Net;//Dns, IPAddress, 
using System.Net.Sockets;//TcpListener,NetworkStream
namespace Com.JungBo.Chat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EchoServer server = new EchoServer();
            server.Echo();
        }
    }//
    public class EchoServer
    {
        public const int PORT = 5555;

        public void Echo()
        {
            TcpListener listener = null;
            NetworkStream ns = null;
            StreamReader sr = null;
            TcpClient client = null;
            bool isEnd = false;
            try
            {
                IPAddress address = Dns.GetHostEntry("").AddressList[0];
                //1) 서버소켓을 준비하고 실행시킨다.
                listener = new TcpListener(address, PORT);
                listener.Start();
                Console.WriteLine("server ~~ TcpListener Ready");
                //클라이언트의 소켓에서 언제 붙을 지 모르므로 계속기다린다.
                while (!isEnd)
                {  //클라이언트에서 연결이 끊어지면 끝낸다.
                    //2) 서버에 붙은 클라이언트와 통신할 소켓준비
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("while ~~ Accept");
                    //3) 소켓에 있는 메세지를 이동시킬 통로준비
                    ns = client.GetStream();
                    sr = new StreamReader(ns, Encoding.Default);
                    Console.WriteLine("while ~~ Recieve Ready");
                    while (true)
                    {  //보낸 메세지를 계속 받기위해
                        string message = string.Empty;
                        //4) 클라이언트가 보낸 메세지 받음
                        if ((message = sr.ReadLine()) != null)
                        {
                            Console.WriteLine("[Client Say]:{0}", message);
                        }
                        else
                        {
                            isEnd = true; //서버연결을 끊는다.
                            Console.WriteLine("while ~~ Client Bye");
                            break;
                        }//else
                    }//inner while
                }//outer while
            }
            catch (Exception ee)
            {
                System.Console.WriteLine(ee.Message);
            }
            finally
            {
                //5) 사용이 끝나면 연결을끊는다.
                if (sr != null) sr.Close();
                if (client != null) client.Close();
                listener.Stop();//서버소켓을 닫는다.
            }
        }
    }
}
