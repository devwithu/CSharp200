using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
namespace Com.JungBo.Chat{
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
        public EchoServer() {
            handleList.Clear();
        }
        public void Echo() {
            try{
                IPAddress address = Dns.GetHostEntry("").AddressList[0];
                listener = new TcpListener(address, PORT);
                listener.Start();
                System.Console.WriteLine("Server Ready 1-------");
                while(true){
                    //클라이언트 하나당 소켓 하나
                    TcpClient client = listener.AcceptTcpClient();
                    //클라이언트 쓰레드 처리 담당 핸들러
                    EchoHandler handler = new EchoHandler(this, client);
                    Add(handler);  //동기화 시킨다.
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
        public void Add(EchoHandler handle){
            lock (handleList.SyncRoot){
                handleList.Add(handle);
            }
        }
        public void Remove(EchoHandler handle){
            lock (handleList.SyncRoot){
                handleList.Remove(handle);
            }
        }
        public void broadcast(String str){
            lock(handleList.SyncRoot){
                string dstes = DateTime.Now.ToString("[yyyy-MM-dd:hh-mm-ss]: ");
                Console.Write(dstes);
                Console.WriteLine(str);
                //클라이언트 쓰레드 처리 담당 핸들러 
                foreach (EchoHandler echohand in handleList){
                    EchoHandler echosay = echohand as EchoHandler;
                    if (echosay!=null) {
                        //모든 클라이언트에게 메세지 보내기
                        echosay.SendMessage(str);
                    }
                }
            }//ArrayList에 락(동기화)
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
        public EchoHandler(EchoServer server, TcpClient client) {
            this.server = server;
            this.client = client;
            try{
                ns = client.GetStream();
                Socket socket = client.Client;
                clientname = socket.RemoteEndPoint.ToString();
                Console.WriteLine(clientname + "님 입장.");
                //소켓에서 메세지 읽기
                sr = new StreamReader(ns, Encoding.Default);
                //소켓에 메세지 쓰기
                sw = new StreamWriter(ns, Encoding.Default);
            }
            catch (Exception ee){
                Console.WriteLine("연결에 실패했습니다.");
            }
        }
        //다른 클라이언트에게 메세지 보내기
        public void SendMessage(string message){
            sw.WriteLine("[server: {0}]", message);
            sw.Flush();
        }
        //쓰레드 생성하기
        public void Start(){
            Thread t = new Thread(
                        new ThreadStart(ProcessClient));
            t.Start();
        }
        //모든 클라이언트에게 메세지를 보낸다.
        public void ProcessClient(){
            try{
                while ((str = sr.ReadLine()) != null){
                    server.broadcast(str);
                }
            }
            catch (Exception){
                Console.WriteLine(clientname + "님 퇴장.");
                sw.Flush();
            }
            finally{
                //클라이언트가 대화에게 나가면 연결 끊기
                server.Remove(this);
                sw.Close();
                sr.Close();
                client.Close();
            }
        }
    }//
}
