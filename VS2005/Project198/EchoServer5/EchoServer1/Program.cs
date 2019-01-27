using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Com.JungBo.Logger;
using System.Collections;
namespace Com.Kaoni.Echo{
    public class Program{
        public static void Main(string[] args){
            EchoServer server = new EchoServer();
            server.Echo();
       }
    }

    public class EchoServer {
        public const int PORT = 9000;
        private TcpListener listener = null;
        public static ArrayList handleList = new ArrayList(10);
        private static Mutex mutex = new Mutex();
        public EchoServer() {
            handleList.Clear();
        }

        public void Echo() {

            try
            {
                IPAddress address = Dns.GetHostEntry("").AddressList[0];
                listener = new TcpListener(address, PORT);
                listener.Start();
                System.Console.WriteLine("Server Ready 1-------");

                while(true){
                    TcpClient client = listener.AcceptTcpClient();
                    EchoHandler handler = new EchoHandler(this, client);
                    Add(handler);
                    handler.Start();
                }
                
            }
            catch (Exception ee){
                System.Console.WriteLine("2-------------------");
                System.Console.WriteLine(ee.Message);
                
            }finally{
                System.Console.WriteLine("3-------------------");
                listener.Stop();
            }
        }

        public void Add(EchoHandler handle)
        {
            lock (handleList.SyncRoot)
            {
                handleList.Add(handle);
                try
                {
                    Thread.Sleep(400);
                    //시작을 위한 여유시간을 준다.
                }
                catch
                {
                }
            }

        }
        public void Remove(EchoHandler handle)
        {
            lock (handleList.SyncRoot)
            {
                if(handle!=null){
                    handleList.Remove(handle);
                }
                try
                {
                    Thread.Sleep(400);
                    //삭제를 위한 여유시간을 준다.
                }
                catch
                {
                }
            }
        }


        public void broadcast(String str)
        {
            lock(handleList.SyncRoot){
                string dstes = DateTime.Now.ToString("[yyyy-MM-dd:hh-mm-ss]: ");
                Console.Write(dstes);
                Console.WriteLine(str);
               
                foreach (EchoHandler echohand in handleList){
                    if (echohand != null) {
                        echohand.SendMessage(str);
                    }
                }
            }
        }
    }


    public class EchoHandler{
        EchoServer server;
        TcpClient client;
        NetworkStream ns = null;
        StreamReader sr = null;
        StreamWriter sw = null;
        String str = string.Empty;
        string clientname;
        public EchoHandler(EchoServer server, TcpClient client)
        {
            this.server = server;
            this.client = client;
            try
            {
                ns = client.GetStream();
                Socket socket = client.Client;
                clientname = socket.RemoteEndPoint.ToString();
                Console.WriteLine(clientname + "님 입장.");
                sr = new StreamReader(ns, Encoding.Default);
                sw = new StreamWriter(ns, Encoding.Default);
            }
            catch (Exception ee)
            {
                Console.WriteLine("연결에 실패했습니다.");
            }
        }

        public void SendMessage(string message)
        {
            sw.WriteLine("{0}", message);
            sw.Flush();
        }

        public void Start()
        {
            Thread t = new Thread(
                        new ThreadStart(ProcessClient));
            t.Start();
            try
            {
                 Thread.Sleep(400);
                //시작을 위한 여유시간을 준다.
            }
            catch {  
            }
           
        }



        public void ProcessClient()
        {
            try
            {
                if(client.Connected){
                    while ((str = sr.ReadLine()) != null)
                    {
                        server.broadcast(str);
                    }
                }
               
            }
            catch (Exception)
            {
                sw.Flush();//보내지 못한 것이 있다면 
                //보냄
            }
            finally
            {
                Console.WriteLine(clientname + "님 퇴장.");
                server.Remove(this);
                Thread.Sleep(300);//삭제여유시간
                if(sw!=null)sw.Close();
                if (sr != null) sr.Close();
                if (client != null) client.Close();
            }
        }
    }

}
