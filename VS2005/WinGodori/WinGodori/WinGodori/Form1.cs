using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Media;
namespace WinGodori
{
    struct PageChange
    {
        public int num;
        public Rectangle Rect;
    }

    public partial class Form1 : Form
    {

        private int mePoint = 0;            // 내점수
        private int guestPoint = 0;         // 상대 점수
        //private int meMulti = 0;          // 나중에 배수 구현 
        //private int guestMulti = 0;       // 나중에 배수 구현


        private ImageUtil gUtil;    // 이미지그릴 유틸
        private ImagePoint gPoint;  // 이미지 포인트
        private CardInfo cinfo;     // 카드 정보
        private Gamer gamer; // 카드 
        private GoStopPoint mp = new GoStopPoint();
        private GoStopPoint gp = new GoStopPoint();

        private List<Rectangle> chPoint = new List<Rectangle>();    // 이미지가 변하는 포인트을 저장한다.

        private int gCount = 11;    // 게임 카운트
        private int tCount = 0; // 시계 카운트
        private int rCount = 0;

        // 통신 할 소켓
        private Socket linkSock;

        private bool gMaster = false;    // 선인가??
        private bool gRunning = false;
        private int oDeck = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("./images/robot_avatar.gif");
            pictureBox2.Image = Image.FromFile("./images/robot_avatar.gif");
        }

        protected override void OnLoad(EventArgs e)
        {
            cinfo = new CardInfo();
            gPoint = new ImagePoint();
            gUtil = new ImageUtil(ref gPoint);
        }



        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;  // 왼쪽 마우스가 아니면

            if (gRunning == false)
            {
                MessageBox.Show("차례가 아닙니다");
                return;
            }
            if (tCount != 0) return;
            int index = -1;
            if ((index = gPoint.Isvalidclick(e.X, e.Y)) == -1) return;  // 클릭이 유효하지 않으면 리턴
            if (gamer.MyCards[index] == 100) return;    // 클릭은 유효하지만 카드가 없으면 리턴

            int cnum = gamer.MyCards[index];
            oDeck = 0;
            HitMaster(index);
            SoundPlay("./sounds/11.wav");

            Packet packet = new Packet((byte)CMD.HIT, cnum);
            PacketSend(packet, packet.GetBytesCardNum());

            Console.WriteLine("rCount {0}", rCount);
            ///////////////////////   카드를 전송하고 대기한다 /////////////////////////////////////////////////////////
            if (rCount == 19 && gMaster == false) return;
            byte[] data = new byte[5];
            linkSock.BeginReceive(data, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data);
            Console.WriteLine("Receive");
        }

        public void ShowNotify()    // 창을 뛰워 줘야 할때
        {
            notifyform myform = new notifyform();
            myform.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e) // 1번
        {
            if (chPoint.Count == 0)
            {
                tCount = 0;
                timer1.Enabled = false;
                if (oDeck == 2) ClearBoard();
            }
            else
            {
                this.Invalidate(chPoint[0]);
                if (chPoint[0] == gPoint.bgdeckRect) oDeck++;
                chPoint.RemoveAt(0);
                tCount++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)   // 2번
        {
            Graphics g = e.Graphics;
            // 백이미지 그리기
            gUtil.DrawBackGround(g);

            if (gCount != 11)
            {
                // 내가 손에 든 카드그리기
                gUtil.DrawMyHandCard(g, gamer.MyCards);     // 내손에 든 카드를 그린다
                gUtil.DrawBGDeck(g);                        // 배경덱을 그린다
                gUtil.DrawBoardCard(g, gamer.BoardCards);   // 보드카드를 그린다   
                gUtil.DrawGuestCard(g, gCount);             // 상대방 카드를 그린다.

                gUtil.DrawMePointBoard(g, gamer.MePointBoard);
                gUtil.DrawGuestPointBoard(g, gamer.GPBoard);

                if (oDeck == 1)
                    gUtil.DrawOpenDeck(g, gamer.OpenDeck);

                gUtil.DrawMyScore(g, mePoint);
                gUtil.DrawGuestScore(g, guestPoint);
            }

            Console.WriteLine("OnPaint Master : {0}", gMaster);
        }

        // 자기 자신이 친 패보여주기
        public void HitMaster(int hindex)   // 0번
        {
            timer1.Enabled = true;
            oDeck = 0;
            ///////////////////////////////////////////////////////////////// 내카드를 친다
            int cnum = gamer.MyCards[hindex];   // 내 카드 번호 저장
            gamer.MyCards[hindex] = 100;        // 카드번호를 셋팅한다.
            chPoint.Add(gPoint.mhRect[hindex]); // Invalidate 될 영역
            ///////////////////////////////////////////////////////////////// 친 카드 표시
            int index = gamer.ReturnBoardPoint(cnum, true);   // 보드에 카드를 그려주고 위치 저장
            Rectangle tmp = gPoint.boardRect[index];
            tmp.Width = 90;
            chPoint.Add(tmp);
            ////////////////////////////////////////////////////////////// 그려질 덱 카드
            chPoint.Add(gPoint.bgdeckRect);
            chPoint.Add(gPoint.bgdeckRect);
            /////////////////////////////////////////////////////////////// 덱 치기 보드 정리
            index = gamer.ReturnBoardPoint(gamer.OpenDeck, true);           // 쌀경우 에러 처리하세요
            tmp = gPoint.boardRect[index];
            tmp.Width = 90;
            chPoint.Add(tmp);
        }

        // 자신이 먹은 카드를 자신에 보드로 가져온다.
        public void ClearBoard()
        {
            SoundPlay("./sounds/11.wav");
            timer1.Enabled = true;
            gamer.ClearSelectCard();
            chPoint.Add(gPoint.backRect);
            if (gRunning)
            {
                gamer.RenewPointBoard(gamer.MePointBoard);
                chPoint.Add(gPoint.mpboardRect);
                mePoint = mp.CalTotal(gamer.MePointBoard);
                chPoint.Add(new Rectangle(208, 495, 16 * 3, 30));
            }
            else
            {
                gamer.RenewPointBoard(gamer.GPBoard);
                chPoint.Add(gPoint.gpboardRect);
                guestPoint = mp.CalTotal(gamer.GPBoard);
                chPoint.Add(new Rectangle(208, 152, 16 * 3, 30));
            }
            gamer.RemoveDeck(); // 한번 친 덱 제거             

            gRunning = !gRunning;
            oDeck++;

            if (rCount++ == 19)
            {
                if (mePoint > guestPoint)
                {
                    SoundPlay("./sounds/win.wav");
                    pictureBox1.Image = Image.FromFile("./images/robot_avatar2.gif");
                    pictureBox2.Image = Image.FromFile("./images/robot_avatar1.gif");
                    MessageBox.Show("승");
                    MasterStart();
                }
                else if (mePoint == guestPoint)
                {
                    MessageBox.Show("나가리");
                    if (gMaster == true) MasterStart();
                    else MasterWait();
                }
                else
                {
                    SoundPlay("./sounds/lose.wav");
                    pictureBox1.Image = Image.FromFile("./images/robot_avatar1.gif");
                    pictureBox2.Image = Image.FromFile("./images/robot_avatar2.gif");
                    MessageBox.Show("패");
                    MasterWait();
                }

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MasterStart()
        {
            // 여기서 처리 할 곳 
            // 카드를 섞어서 상대방에게 보내주고 자신은 대기 한다 상대방이 칠동안에
            gamer = new Gamer(ref cinfo);
            gamer.MixCard();
            gamer.Distribution(gamer.Cards);

            Init_Value();
            gCount--;

            gMaster = true;
            gRunning = true;

            MessageBox.Show("선입니다");

            Packet packet = new Packet((byte)CMD.START, gamer.Cards);   //카드를 보내고    
            PacketSend(packet, packet.GetBytes());

            this.Invalidate();
        }

        // 초기화 변수
        public void Init_Value()
        {
            gCount = 11;
            gCount = 11;
            mePoint = 0;
            guestPoint = 0;
            rCount = 0;
            gp = new GoStopPoint();
            mp = new GoStopPoint();
        }

        public void MasterWait()
        {
            gRunning = false;    // 게임중인가?
            gMaster = false;

            Init_Value();

            MessageBox.Show("대기합니다 선이 보내주기를 기다리십시오.");
            // 처음에는 모든 카드를 받는다
            if (gCount == 11)
            {

                byte[] data = new byte[193];

                linkSock.BeginReceive(data, 0, 193, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }

            ///////////////                  카드가 오는지 대기한다 //////////////////////////////////////
            byte[] data2 = new byte[5];
            linkSock.BeginReceive(data2, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data2);

        }
        //////////////////////////////////////////////////   서버 ////////////////////////////////////////////////////////////////


        // 서버 버튼 클릭시
        private void mnuStartServer_Click(object sender, EventArgs e)
        {
            // 초기화 
            gRunning = false;
            mnuStartServer.Enabled = false;
            mnuConnectServer.Enabled = false;

            Console.WriteLine("Server");

            // client 의 접속을 대기합니다
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);

            sock.Bind(ipep);
            sock.Listen(5);

            // this.Text = " 접속을 대기합니다";

            sock.BeginAccept(new AsyncCallback(OnAccept), sock);
        }


        // 접속한다.
        private void OnAccept(IAsyncResult iar)
        {
            Socket sock = (Socket)(iar.AsyncState);

            linkSock = sock.EndAccept(iar);

            sock.Close();
            Console.WriteLine("OnAccept");

            //      this.Text = "접속되었습니다";
            SoundPlay("./sounds/welcome.wav");

            // 여기서 처리 할 곳 
            // 카드를 섞어서 상대방에게 보내주고 자신은 대기 한다 상대방이 칠동안에 
            gamer = new Gamer(ref cinfo);
            gp = new GoStopPoint();
            mp = new GoStopPoint();
            gamer.MixCard();
            gamer.Distribution(gamer.Cards);
            gCount--;
            Packet packet = new Packet((byte)CMD.START, gamer.Cards);
            PacketSend(packet, packet.GetBytes());

            this.Invalidate();

            gMaster = false;
            gRunning = false;   // 게임중인가?
            ///////////////                  카드가 오는지 대기한다 //////////////////////////////////////
            byte[] data = new byte[5];
            linkSock.BeginReceive(data, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data);

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 패킷을 보낸다
        private void PacketSend(Packet p, byte[] data)
        {

            try
            {
                linkSock.Send(data); // 전송 - data량이 많으면 비동기가 좋다.   
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10054)
                {
                    MessageBox.Show("접속이 끊어 졌습니다.");
                    mnuConnectServer.Enabled = true;
                    mnuStartServer.Enabled = true;
                    gRunning = false;
                    linkSock.Close();
                    return;
                }
            }
        }

        // 받으면 콜되는함수
        private void OnReceive(IAsyncResult iar)
        {
            this.Invalidate();
            Console.WriteLine("OnReceive");
            byte[] data = (byte[])iar.AsyncState;

            try
            {
                int n = linkSock.EndReceive(iar);
                Console.WriteLine("n : {0}", n);

                if (gCount == 11)
                { //  처음에만 한번 전체카드를 받는다.
                    if (n != 193)
                    {
                        // linkSock.BeginReceive(data, 0, 193-n, SocketFlags.None, new AsyncCallback(OnReceive), data);
                        MessageBox.Show("error in receive packet");
                        return;

                    }
                }
                else
                {
                    if (n != 5)
                    {
                        // 다 도착 할때까지 비동기를 한번 더 하거나
                        // 아니면 곧 도착할것이라고 보고 동기로 대기한다.
                        MessageBox.Show("Error in Receive Packet");
                        return;
                    }
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10054)
                {
                    MessageBox.Show("접속이 끊어 졌습니다.");
                    mnuConnectServer.Enabled = true;
                    mnuStartServer.Enabled = true;
                    gRunning = false;
                    linkSock.Close();
                    return;
                }
            }

            // 받은  패킷 처리하는곳
            Packet packet = new Packet(data, gCount);

            if (packet.cmd == (byte)CMD.START)
            {
                gamer = new Gamer(ref cinfo);
                // 카드를 받아서 정리한다.
                gamer.Distribution(packet.total_card);
            }
            else if (packet.cmd == (byte)CMD.HIT)
            {

                this.Invoke(new MethodInvoker(delegate()
                {

                    Graphics g = this.CreateGraphics();
                    SoundPlay("./sounds/11.wav");
                    timer1.Enabled = true;
                    oDeck = 0;
                    int cnum = packet.cardnum;
                    //////////////////////////////////////////////////////////////////
                    //  Console.WriteLine("Receive {0}",rCount++);
                    //  Console.WriteLine("{0}",cnum);
                    //  Console.WriteLine("----------------------------------------------------");
                    ///////////////////////////////////////////////////////////////////
                    gUtil.DrawTestCard(g, cnum, gPoint.gvRect);
                    chPoint.Add(gPoint.gvRect);

                    ///////////////////////////////////////////////////////////////// 친 카드 표시
                    int index = gamer.ReturnBoardPoint(cnum, true);   // 보드에 카드를 그려주고 위치 저장
                    Rectangle tmp = gPoint.boardRect[index];
                    tmp.Width = 90;
                    chPoint.Add(tmp);
                    ////////////////////////////////////////////////////////////// 그려질 덱 카드
                    chPoint.Add(gPoint.bgdeckRect);
                    chPoint.Add(gPoint.bgdeckRect);
                    /////////////////////////////////////////////////////////////// 덱 치기 보드 정리
                    index = gamer.ReturnBoardPoint(gamer.OpenDeck, true);
                    tmp = gPoint.boardRect[index];
                    tmp.Width = 90;
                    chPoint.Add(tmp);
                }));

            }

            //gRunning = true;
            gCount--; // 패킷을 받으면 쳤다는 말이므로 카운트를 하나 줄인다
            //Console.WriteLine("Receive Master : {0}", gMaster);
        }

        ////////////////////////////////////////////////// 클라이언트 //////////////////////////////////////////////






        // 서버 접속 클릭시
        private void mnuConnectServer_Click(object sender, EventArgs e)
        {
            // 초기화 
            mnuStartServer.Enabled = false;
            mnuConnectServer.Enabled = false;
            gRunning = false;
            // Console.WriteLine("Client");
            SoundPlay("./sounds/welcome.wav");
            // 서버에 접속합니다.
            linkSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtIP.Text), 8000);

            //  this.Text = "접속 중 입니다";

            linkSock.BeginConnect(ipep, new AsyncCallback(OnConnect), 0);
        }

        private void OnConnect(IAsyncResult iar)
        {
            Console.WriteLine("OnConnect");
            try
            {
                linkSock.EndConnect(iar);
            }
            catch (SocketException)
            {

                //  this.Text = "접속될 수 없습니다";
                // mnuConnectServer.Enabled = true;
                // mnuStartServer.Enabled = true;
                return;
            }
            //   this.Text = "접속 되었습니다";

            MessageBox.Show("먼저 두세요");

            gRunning = true;    // 게임중인가?
            gMaster = true;

            // 처음에는 모든 카드를 받는다
            if (gCount == 11)
            {
                byte[] data = new byte[193];
                linkSock.BeginReceive(data, 0, 193, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }
            this.Invalidate();
        }


        // 음악 재생
        public void SoundPlay(string s)
        {
            SoundPlayer splay = new SoundPlayer(s);
            splay.Play();
            if (splay != null) splay.Dispose();
        }
    }
}