using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Com.JungBo.Chat;
namespace Com.JungBo.Chat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EchoServer server = new EchoServer();
            server.Echo();
        }
    }
    public class EchoServer
    {
        public const int PORT = 9000;
        public void Echo()
        {
            TcpListener listener = null;
            try
            {
                //서버 자신의 IP를 찾는다.
                IPAddress address = Dns.GetHostEntry("").AddressList[0];
                //서버소켓을 준비한다. 
                listener = new TcpListener(address, PORT);
                //서버소켓을 시작한다.
                listener.Start();
                Console.WriteLine("server 1~~ready");
                //클라이언트가 붙을 때까지 기다린다.
                while (true)
                {
                    //클라이언트가 붙으면 담당 소켓을 생성한다.
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("while 2~~Accept");
                    //클라이언트하나당 하나의 쓰레드
                    Thread t = new Thread(
                        new ParameterizedThreadStart(ProcessClient));
                    //쓰레드에 소켓을 넘긴다.
                    t.Start(client);  //아규먼트가 있는 쓰레드
                }
            }
            catch (Exception ee)
            {
                System.Console.WriteLine(ee.Message);

            }
        }
        //클라이언트 하나당 담당 쓰레드에서 소켓에 쓰고 
        //소켓에서 메세지를 가져온다.
        public void ProcessClient(object o)
        {
            //Start 메서드에서 받은 개체
            TcpClient client = o as TcpClient;
            NetworkStream ns = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            string clientname = "";
            try
            {
                //소켓에서 네트워크 스트림을 얻는다.
                ns = client.GetStream();
                Socket socket = client.Client;
                clientname = socket.RemoteEndPoint.ToString();
                Console.WriteLine(clientname + "이 붙었습니다.");
                //소켓에서 메세지를 가져온다.
                sr = new StreamReader(ns, Encoding.Default);
                //소켓에 메세지를 쓴다.
                sw = new StreamWriter(ns, Encoding.Default);
                while (true)
                {
                    //소켓에서 메세지를 가져온다.
                    string message = sr.ReadLine();
                    //소켓에 메세지를 쓴다.
                    sw.WriteLine("[server: {0}]", message);
                    sw.Flush();
                    string dstes =
                    DateTime.Now.ToString("[yyyy-MM-dd:hh-mm-ss]: ");
                    Console.Write(dstes);
                    Console.WriteLine(message);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(clientname + "이 떨어졌습니다.");
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
