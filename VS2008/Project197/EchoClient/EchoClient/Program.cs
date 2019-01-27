using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
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
        NetworkStream ns = null;
        StreamWriter sw = null;
        TcpClient client = null;

        public void Echo()
        {
            string name = string.Empty;
            try
            {
                client = new TcpClient(IP, PORT);//소켓
                Console.WriteLine("client~~서버에 접속");
                ns = client.GetStream();
                //소켓에 쓰기와
                sw = new StreamWriter(ns, Encoding.Default);

                string ss = string.Empty;

                //ctrl+c
                Console.WriteLine("이름을 입력하세요");
                name = Console.ReadLine();//이름
                Console.WriteLine(name + "님 즐거운 채팅하세요.");
                //소켓에서 읽기 분리---------
                ClientThread clientth = new ClientThread(client);
                clientth.Start();


                while ((ss = Console.ReadLine()) != null)
                {
                    sw.WriteLine(string.Format("[{0}]: {1}", name, ss));
                    //서버로 보내기
                    sw.Flush();
                }
                //---------------------------
                sw.WriteLine("{0}님이 퇴장했습니다.", name);
                sw.Flush();
            }
            catch (Exception ee)
            {

                System.Console.WriteLine(ee.Message);

            }
            finally
            {
                sw.Close();
                client.Close();
            }
        }
    }


    public class ClientThread
    {
        TcpClient client;
        StreamReader sr;
        NetworkStream ns = null;
        string str;
        public ClientThread(TcpClient client)
        {
            this.client = client;
            ns = client.GetStream();
            sr = new StreamReader(ns, Encoding.Default);
        }
        public void Start()
        {
            Thread clientThread = new Thread(new ThreadStart(run));
            clientThread.Start();
        }

        public void run()
        {

            try
            {
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
