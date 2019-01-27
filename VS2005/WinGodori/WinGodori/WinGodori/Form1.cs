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

        private int mePoint = 0;            // ������
        private int guestPoint = 0;         // ��� ����
        //private int meMulti = 0;          // ���߿� ��� ���� 
        //private int guestMulti = 0;       // ���߿� ��� ����


        private ImageUtil gUtil;    // �̹����׸� ��ƿ
        private ImagePoint gPoint;  // �̹��� ����Ʈ
        private CardInfo cinfo;     // ī�� ����
        private Gamer gamer; // ī�� 
        private GoStopPoint mp = new GoStopPoint();
        private GoStopPoint gp = new GoStopPoint();

        private List<Rectangle> chPoint = new List<Rectangle>();    // �̹����� ���ϴ� ����Ʈ�� �����Ѵ�.

        private int gCount = 11;    // ���� ī��Ʈ
        private int tCount = 0; // �ð� ī��Ʈ
        private int rCount = 0;

        // ��� �� ����
        private Socket linkSock;

        private bool gMaster = false;    // ���ΰ�??
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
            if (e.Button != MouseButtons.Left) return;  // ���� ���콺�� �ƴϸ�

            if (gRunning == false)
            {
                MessageBox.Show("���ʰ� �ƴմϴ�");
                return;
            }
            if (tCount != 0) return;
            int index = -1;
            if ((index = gPoint.Isvalidclick(e.X, e.Y)) == -1) return;  // Ŭ���� ��ȿ���� ������ ����
            if (gamer.MyCards[index] == 100) return;    // Ŭ���� ��ȿ������ ī�尡 ������ ����

            int cnum = gamer.MyCards[index];
            oDeck = 0;
            HitMaster(index);
            SoundPlay("./sounds/11.wav");

            Packet packet = new Packet((byte)CMD.HIT, cnum);
            PacketSend(packet, packet.GetBytesCardNum());

            Console.WriteLine("rCount {0}", rCount);
            ///////////////////////   ī�带 �����ϰ� ����Ѵ� /////////////////////////////////////////////////////////
            if (rCount == 19 && gMaster == false) return;
            byte[] data = new byte[5];
            linkSock.BeginReceive(data, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data);
            Console.WriteLine("Receive");
        }

        public void ShowNotify()    // â�� �ٿ� ��� �Ҷ�
        {
            notifyform myform = new notifyform();
            myform.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e) // 1��
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

        protected override void OnPaint(PaintEventArgs e)   // 2��
        {
            Graphics g = e.Graphics;
            // ���̹��� �׸���
            gUtil.DrawBackGround(g);

            if (gCount != 11)
            {
                // ���� �տ� �� ī��׸���
                gUtil.DrawMyHandCard(g, gamer.MyCards);     // ���տ� �� ī�带 �׸���
                gUtil.DrawBGDeck(g);                        // ��浦�� �׸���
                gUtil.DrawBoardCard(g, gamer.BoardCards);   // ����ī�带 �׸���   
                gUtil.DrawGuestCard(g, gCount);             // ���� ī�带 �׸���.

                gUtil.DrawMePointBoard(g, gamer.MePointBoard);
                gUtil.DrawGuestPointBoard(g, gamer.GPBoard);

                if (oDeck == 1)
                    gUtil.DrawOpenDeck(g, gamer.OpenDeck);

                gUtil.DrawMyScore(g, mePoint);
                gUtil.DrawGuestScore(g, guestPoint);
            }

            Console.WriteLine("OnPaint Master : {0}", gMaster);
        }

        // �ڱ� �ڽ��� ģ �к����ֱ�
        public void HitMaster(int hindex)   // 0��
        {
            timer1.Enabled = true;
            oDeck = 0;
            ///////////////////////////////////////////////////////////////// ��ī�带 ģ��
            int cnum = gamer.MyCards[hindex];   // �� ī�� ��ȣ ����
            gamer.MyCards[hindex] = 100;        // ī���ȣ�� �����Ѵ�.
            chPoint.Add(gPoint.mhRect[hindex]); // Invalidate �� ����
            ///////////////////////////////////////////////////////////////// ģ ī�� ǥ��
            int index = gamer.ReturnBoardPoint(cnum, true);   // ���忡 ī�带 �׷��ְ� ��ġ ����
            Rectangle tmp = gPoint.boardRect[index];
            tmp.Width = 90;
            chPoint.Add(tmp);
            ////////////////////////////////////////////////////////////// �׷��� �� ī��
            chPoint.Add(gPoint.bgdeckRect);
            chPoint.Add(gPoint.bgdeckRect);
            /////////////////////////////////////////////////////////////// �� ġ�� ���� ����
            index = gamer.ReturnBoardPoint(gamer.OpenDeck, true);           // �Ұ�� ���� ó���ϼ���
            tmp = gPoint.boardRect[index];
            tmp.Width = 90;
            chPoint.Add(tmp);
        }

        // �ڽ��� ���� ī�带 �ڽſ� ����� �����´�.
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
            gamer.RemoveDeck(); // �ѹ� ģ �� ����             

            gRunning = !gRunning;
            oDeck++;

            if (rCount++ == 19)
            {
                if (mePoint > guestPoint)
                {
                    SoundPlay("./sounds/win.wav");
                    pictureBox1.Image = Image.FromFile("./images/robot_avatar2.gif");
                    pictureBox2.Image = Image.FromFile("./images/robot_avatar1.gif");
                    MessageBox.Show("��");
                    MasterStart();
                }
                else if (mePoint == guestPoint)
                {
                    MessageBox.Show("������");
                    if (gMaster == true) MasterStart();
                    else MasterWait();
                }
                else
                {
                    SoundPlay("./sounds/lose.wav");
                    pictureBox1.Image = Image.FromFile("./images/robot_avatar1.gif");
                    pictureBox2.Image = Image.FromFile("./images/robot_avatar2.gif");
                    MessageBox.Show("��");
                    MasterWait();
                }

            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MasterStart()
        {
            // ���⼭ ó�� �� �� 
            // ī�带 ��� ���濡�� �����ְ� �ڽ��� ��� �Ѵ� ������ ĥ���ȿ�
            gamer = new Gamer(ref cinfo);
            gamer.MixCard();
            gamer.Distribution(gamer.Cards);

            Init_Value();
            gCount--;

            gMaster = true;
            gRunning = true;

            MessageBox.Show("���Դϴ�");

            Packet packet = new Packet((byte)CMD.START, gamer.Cards);   //ī�带 ������    
            PacketSend(packet, packet.GetBytes());

            this.Invalidate();
        }

        // �ʱ�ȭ ����
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
            gRunning = false;    // �������ΰ�?
            gMaster = false;

            Init_Value();

            MessageBox.Show("����մϴ� ���� �����ֱ⸦ ��ٸ��ʽÿ�.");
            // ó������ ��� ī�带 �޴´�
            if (gCount == 11)
            {

                byte[] data = new byte[193];

                linkSock.BeginReceive(data, 0, 193, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }

            ///////////////                  ī�尡 ������ ����Ѵ� //////////////////////////////////////
            byte[] data2 = new byte[5];
            linkSock.BeginReceive(data2, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data2);

        }
        //////////////////////////////////////////////////   ���� ////////////////////////////////////////////////////////////////


        // ���� ��ư Ŭ����
        private void mnuStartServer_Click(object sender, EventArgs e)
        {
            // �ʱ�ȭ 
            gRunning = false;
            mnuStartServer.Enabled = false;
            mnuConnectServer.Enabled = false;

            Console.WriteLine("Server");

            // client �� ������ ����մϴ�
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);

            sock.Bind(ipep);
            sock.Listen(5);

            // this.Text = " ������ ����մϴ�";

            sock.BeginAccept(new AsyncCallback(OnAccept), sock);
        }


        // �����Ѵ�.
        private void OnAccept(IAsyncResult iar)
        {
            Socket sock = (Socket)(iar.AsyncState);

            linkSock = sock.EndAccept(iar);

            sock.Close();
            Console.WriteLine("OnAccept");

            //      this.Text = "���ӵǾ����ϴ�";
            SoundPlay("./sounds/welcome.wav");

            // ���⼭ ó�� �� �� 
            // ī�带 ��� ���濡�� �����ְ� �ڽ��� ��� �Ѵ� ������ ĥ���ȿ� 
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
            gRunning = false;   // �������ΰ�?
            ///////////////                  ī�尡 ������ ����Ѵ� //////////////////////////////////////
            byte[] data = new byte[5];
            linkSock.BeginReceive(data, 0, 5, SocketFlags.None, new AsyncCallback(OnReceive), data);

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ��Ŷ�� ������
        private void PacketSend(Packet p, byte[] data)
        {

            try
            {
                linkSock.Send(data); // ���� - data���� ������ �񵿱Ⱑ ����.   
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10054)
                {
                    MessageBox.Show("������ ���� �����ϴ�.");
                    mnuConnectServer.Enabled = true;
                    mnuStartServer.Enabled = true;
                    gRunning = false;
                    linkSock.Close();
                    return;
                }
            }
        }

        // ������ �ݵǴ��Լ�
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
                { //  ó������ �ѹ� ��üī�带 �޴´�.
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
                        // �� ���� �Ҷ����� �񵿱⸦ �ѹ� �� �ϰų�
                        // �ƴϸ� �� �����Ұ��̶�� ���� ����� ����Ѵ�.
                        MessageBox.Show("Error in Receive Packet");
                        return;
                    }
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10054)
                {
                    MessageBox.Show("������ ���� �����ϴ�.");
                    mnuConnectServer.Enabled = true;
                    mnuStartServer.Enabled = true;
                    gRunning = false;
                    linkSock.Close();
                    return;
                }
            }

            // ����  ��Ŷ ó���ϴ°�
            Packet packet = new Packet(data, gCount);

            if (packet.cmd == (byte)CMD.START)
            {
                gamer = new Gamer(ref cinfo);
                // ī�带 �޾Ƽ� �����Ѵ�.
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

                    ///////////////////////////////////////////////////////////////// ģ ī�� ǥ��
                    int index = gamer.ReturnBoardPoint(cnum, true);   // ���忡 ī�带 �׷��ְ� ��ġ ����
                    Rectangle tmp = gPoint.boardRect[index];
                    tmp.Width = 90;
                    chPoint.Add(tmp);
                    ////////////////////////////////////////////////////////////// �׷��� �� ī��
                    chPoint.Add(gPoint.bgdeckRect);
                    chPoint.Add(gPoint.bgdeckRect);
                    /////////////////////////////////////////////////////////////// �� ġ�� ���� ����
                    index = gamer.ReturnBoardPoint(gamer.OpenDeck, true);
                    tmp = gPoint.boardRect[index];
                    tmp.Width = 90;
                    chPoint.Add(tmp);
                }));

            }

            //gRunning = true;
            gCount--; // ��Ŷ�� ������ �ƴٴ� ���̹Ƿ� ī��Ʈ�� �ϳ� ���δ�
            //Console.WriteLine("Receive Master : {0}", gMaster);
        }

        ////////////////////////////////////////////////// Ŭ���̾�Ʈ //////////////////////////////////////////////






        // ���� ���� Ŭ����
        private void mnuConnectServer_Click(object sender, EventArgs e)
        {
            // �ʱ�ȭ 
            mnuStartServer.Enabled = false;
            mnuConnectServer.Enabled = false;
            gRunning = false;
            // Console.WriteLine("Client");
            SoundPlay("./sounds/welcome.wav");
            // ������ �����մϴ�.
            linkSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtIP.Text), 8000);

            //  this.Text = "���� �� �Դϴ�";

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

                //  this.Text = "���ӵ� �� �����ϴ�";
                // mnuConnectServer.Enabled = true;
                // mnuStartServer.Enabled = true;
                return;
            }
            //   this.Text = "���� �Ǿ����ϴ�";

            MessageBox.Show("���� �μ���");

            gRunning = true;    // �������ΰ�?
            gMaster = true;

            // ó������ ��� ī�带 �޴´�
            if (gCount == 11)
            {
                byte[] data = new byte[193];
                linkSock.BeginReceive(data, 0, 193, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }
            this.Invalidate();
        }


        // ���� ���
        public void SoundPlay(string s)
        {
            SoundPlayer splay = new SoundPlayer(s);
            splay.Play();
            if (splay != null) splay.Dispose();
        }
    }
}