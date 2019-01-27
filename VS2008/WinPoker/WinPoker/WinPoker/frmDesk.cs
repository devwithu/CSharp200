
                        /***************************************************************
                        *          프로그램명: 소켓통신 2인용 포카게임                 *
                        *          제작  기간: 070703~070710                           *
                        *          만  든  이: 최우인(카드로직), 윤창기(소켓, UI)      *
                        *                                                              *
                        *          개선되어야할 사항:                                  *
                        *              01. 소스 정리 및 기타 버그 수정                 *
                        *              02. 카드 움직임 처리                            *
                        *                                                              *
                        ***************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Media;

namespace Poker
{
    public partial class frmDesk : Form
    {
        private List<PictureBox> MyPicList;     //내 카드 이미지 리스트
        private List<PictureBox> YourPicList;   //상대방 카드 이미지 리스트
        private List<Button> BtnList;           //버튼 리스트
        
        private Socket linkSock;                // 통신할 소켓

        Player me = new Player();               //나
        Player you = new Player();              //상대방  
        Dealer dealer = Dealer.getDealer();     //딜러
        Bet betting = new Bet();                //베팅
             
        bool isServer = false;                  //서버, 클라이언트 구분
        int RSCount = 0;                        //Receive, Send 시에 증가 (OnReceive함수에서 다음처리 구분용)

        public frmDesk()
        {
            InitializeComponent();
        }

        private void frmDesk_Load(object sender, EventArgs e)
        {
            btnStart.Visible  = false;

            MyPicList = new List<PictureBox>();
            YourPicList = new List<PictureBox>();
            BtnList = new List<Button>();

            MyPicList.Add(mCard1);      MyPicList.Add(mCard2);      MyPicList.Add(mCard3);      MyPicList.Add(mCard4);
            MyPicList.Add(mCard5);      MyPicList.Add(mCard6);      MyPicList.Add(mCard7);  
            YourPicList.Add(uCard1);    YourPicList.Add(uCard2);    YourPicList.Add(uCard3);    YourPicList.Add(uCard4);
            YourPicList.Add(uCard5);    YourPicList.Add(uCard6);    YourPicList.Add(uCard7);

            foreach (PictureBox p in MyPicList) p.Image = getImage("empty");
            foreach (PictureBox p in YourPicList) p.Image = getImage("empty");
            
            BtnList.Add(btnDouble); BtnList.Add(btnQuarter);    BtnList.Add(btnHalf);   BtnList.Add(btnFull);
            BtnList.Add(btnCheck);  BtnList.Add(btnBBing);      BtnList.Add(btnCall);   BtnList.Add(btnDie);

            ShowButton(false);

            betting.totalMoney = betting.BBING * 2;
            betting.callMoney = 0;

            me.money -= betting.BBING;
            you.money -= betting.BBING;
        }

        //*****************************************************************************************
        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (linkSock.Connected == true)
                linkSock.Close();

            Application.Exit();
        }

        private void mnuStartServer_Click(object sender, EventArgs e)
        {
            mnuConnectServer.Enabled = false;
            mnuStartServer.Enabled = false;

            //-------------------------------------------------------------------------------------
            // client의 접속을 대기한다.
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8000);

            sock.Bind(ipep);
            sock.Listen(5);

            // 접속을 대기한다.
            this.Text = "접속을 대기합니다.";

            // 비동기로 대기를 한다.
            sock.BeginAccept(new AsyncCallback(OnAccept), sock); // 2번째 인자가
            // OnAccept의 에 전달되도록
        }

        private void OnAccept(IAsyncResult iar)
        {
            Socket sock = (Socket)(iar.AsyncState); // BeginAccept의 2번째 인자
            linkSock = sock.EndAccept(iar);
            sock.Close(); // 이제 listen 할 필요는 없다.

            //다른 쓰레드에서 간접적인 방법으로 컨트롤을 만든 쓰레드에게 요청
            this.Invoke(new MethodInvoker(delegate() {
                this.Text = "접속 되었습니다.";
                btnStart.Visible = true;
            }));
        }

        private void mnuConnectServer_Click(object sender, EventArgs e)
        {
            // 멤버 변수 초기화
            mnuConnectServer.Enabled = false;
            mnuStartServer.Enabled = false;


            frmIP f = new frmIP();
            f.StartPosition = FormStartPosition.CenterParent;

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    linkSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(f.IP.ToString()), 8000);
                    this.Text = "접속중입니다.";
                    linkSock.BeginConnect(ipep, new AsyncCallback(OnConnect), 0);
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                    return;
                }
            }
        }

        private void OnConnect(IAsyncResult iar)
        {
            try
            {
                linkSock.EndConnect(iar);
            }
            catch (SocketException)
            {
                this.Invoke(new MethodInvoker(delegate() {
                    this.Text = "서버에 접속할수 없습니다.";
                    MessageBox.Show("접속 에러");
                    mnuConnectServer.Enabled = true;
                    mnuStartServer.Enabled = true;
                }));
                return;
            }
            this.Invoke(new MethodInvoker(delegate() {
                this.Text = "접속 되었습니다.";
            }));

            byte[] data = new byte[8];
            linkSock.BeginReceive(data, 0, 8, SocketFlags.None, new AsyncCallback(OnReceive), data);

        }

        //*****************************************************************************************
        private void OnReceive(IAsyncResult iar)
        {
            //-------------------------------------------------------------------------------------
            try
            {
                //서버가 시작버튼을 누르고 처음패를 보낼떄 까지 기달린다.
                byte[] data = (byte[])iar.AsyncState;
                Packet packet = new Packet(data);

                //---------------------------------------------------------------
                //0번: 클라이언트는 처음에 플레이어를 생성
                if (RSCount == 0)
                {
                    UpdateLabel();
                }
                //---------------------------------------------------------------
                //0~3번: 
                if (RSCount >= 0 && RSCount <= 2)
                {
                    you.cards.Add(new Card(packet.PacketNum1));
                    me.cards.Add(new Card(packet.PacketNum2));

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        ShowCard(CardState.YourCard, RSCount, ShowState.Hide); pause();
                        ShowCard(CardState.MyCard, RSCount, ShowState.Show); pause();
                    }));
                    
                    isClickOK = true;   //1~3번 카드 클릭 허락
                }

                //---------------------------------------------------------------
                //3~4번: 카드를 3장씩 받은 상태에서 한장 선택하면 다음패 받을 사람을 체크...
                if (RSCount == 3 || RSCount == 4)
                {
                    for (int i = 0; i < you.cards.Count; i++)
                    {
                        if (you.cards[i].ID == packet.PacketNum1)
                        {
                            uCard = you.cards[i];
                            you.cards.Insert(3, uCard);
                            you.cards.RemoveAt(i);
                        }
                    }
                    //상대방의 세번째 카드를 보여준다 (인덱스 번호는 2)
                    ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); 
                }

                //---------------------------------------------------------------
                if (isServer == true && RSCount == 4)
                    CheckNext();

                //---------------------------------------------------------------
                if (RSCount == 5 && isServer==false)
                {
                    try
                    {
                        you.cards.Add(new Card(packet.PacketNum1));
                        me.cards.Add(new Card(packet.PacketNum2));

                        dealer.Winner(ref me, ref you);

                        this.Invoke(new MethodInvoker(delegate()
                        {
                            if (me.isBoss == true)
                            {
                                ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                                ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                            }
                            else
                            {
                                ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                                ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        this.Text = ex.Message;
                    }
                    
                }

                //-------------------------------------------------------------
                if (RSCount == 5)
                {
                    dealer.Winner(ref me, ref you);
                    
                    //내가 이겼으면 버튼 활성화
                    if(me.isBoss == true)
                        ShowButton(true);
                    else
                        ShowButton(false);

                }
                //-------------------------------------------------------------
                if (RSCount >= 6)
                {

                    //betting 값을 받았다.
                    if (packet.PacketNum2 == int.MaxValue)
                    {
                        
                        BETTING betValue = (BETTING)packet.PacketNum1;
                        //MessageBox.Show(betValue.ToString(), isServer.ToString());

                        this.Invoke(new MethodInvoker(delegate()
                        {
                            ShowMsg(betValue);
                            PlaySound((SOUNDSTATE)betValue);
                        }));

                        betting.Go(betValue);
                        you.money -= betting.bettingMoney;
                        UpdateLabel();

                        if (betValue == BETTING.CALL)
                        {

                            if (me.cards.Count == 7)
                            {
                                DecideWinner(DecideWinState.CHECK);
                            }
                            else
                            {
                                betting.noMoreBetting = false;
                                betting.round = 0;
                                CheckNext();
                            }
                        }
                        else if (betValue == BETTING.DIE)
                        {
                            DecideWinner(DecideWinState.WIN); //die를 받으면 내가 이긴다.
                        }
                        else
                            ShowButton(true);
                    }
                    else //카드를 받았다 --;;;
                    {
                        //dealer.Winner(ref me, ref you);

                        you.cards.Add(new Card(packet.PacketNum1));
                        me.cards.Add(new Card(packet.PacketNum2));

                        dealer.Winner(ref me, ref you);

                        this.Invoke(new MethodInvoker(delegate()
                        {
                            if (me.isBoss == true)
                            {
                                if (me.cards.Count == 7)
                                {
                                    ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                                    ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Hide); pause();
                                }
                                else
                                {
                                    ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                                    ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                                }
                            }
                            else
                            {
                                if (me.cards.Count == 7)
                                {
                                    ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Hide); pause();
                                    ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                                }
                                else
                                {
                                    ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                                    ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                                }
                            }

                        }));

                        betting.noMoreBetting = false;
                        betting.round = 0;

                        dealer.Winner(ref me, ref you);
                        //내가 이겼으면 버튼 활성화
                        if (me.isBoss == true)
                            ShowButton(true);
                        else
                            ShowButton(false);
                    }
                    //-------------------------------------------------------------

                    UpdateLabel();
                }

                //-------------------------------------------------------------

                RSCount++;
                //this.Text += "/" + RSCount.ToString();

                linkSock.BeginReceive(data, 0, 8, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10054)
                {
                    MessageBox.Show("접속이 끊어졌습니다.");
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        mnuConnectServer.Enabled = true;
                        mnuStartServer.Enabled = true;
                    }));
                    linkSock.Close();
                    return;
                }
            }
        }
        enum SOUNDSTATE : int { DIE, CHECK, CALL, BBING, DOUBLE, QUARTER, HALF, FULL, WIN, LOSE }

        private void PlaySound(SOUNDSTATE ST)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"..\..\sound\" + ST.ToString() + ".wav";
                player.Play();
                player.Dispose();

            }));
        }
        private void ShowMsg(BETTING B)
        {
            if (B == BETTING.BBING) lblMsg.Text = "삥!";
            else if (B == BETTING.CALL) lblMsg.Text = "콜~";
            else if (B == BETTING.CHECK ) lblMsg.Text = "췍";
            else if (B == BETTING.DIE) lblMsg.Text = "다이";
            else if (B == BETTING.DOUBLE) lblMsg.Text = "따당";
            else if (B == BETTING.FULL) lblMsg.Text = "풀";
            else if (B == BETTING.HALF) lblMsg.Text = "하프";
            else if (B == BETTING.QUARTER) lblMsg.Text = "쿼떠";
        }


        //*****************************************************************************************

        enum CardState { MyCard = 0, YourCard, AllCard };
        enum ShowState { Hide = 0, Show};

        //내카드나 상대방카드 또는 모두를 보여주거나 숨겨주는 함수
        private void ShowCard(CardState CS, ShowState sState)
        {
            if (CS == CardState.MyCard || CS == CardState.AllCard)
                for (int i = 0; i < me.cards.Count; i++)
                {
                    if (sState == ShowState.Hide) MyPicList[i].Image = getImage("cb");
                    else MyPicList[i].Image = getImage(me.cards[i].ImgName);
                    pause();
                }

            if (CS == CardState.YourCard || CS == CardState.AllCard)
                for (int i = 0; i < you.cards.Count; i++)
                {
                    if (sState == ShowState.Hide) YourPicList[i].Image = getImage("cb");
                    else YourPicList[i].Image = getImage(you.cards[i].ImgName);
                    pause();
                }
        }

        //내카드나 상대방 카드의 카드번호에 맞는 카드만 보여주거나 숨겨주는 함수
        private void ShowCard(CardState cState, int CardNum, ShowState sState)
        {
            if (CardNum < 0 || CardNum > 8) return; //카드 번호는 0~6 사이만 허용

            if (cState == CardState.MyCard || cState == CardState.AllCard)
                if (sState == ShowState.Hide ) MyPicList[CardNum].Image = getImage("cb");
                else MyPicList[CardNum].Image = getImage(me.cards[CardNum].ImgName); 

            if (cState == CardState.YourCard || cState == CardState.AllCard)
                if (sState == ShowState.Hide) YourPicList[CardNum].Image = getImage("cb");
                else YourPicList[CardNum].Image = getImage(you.cards[CardNum].ImgName);
        }

        private void UpdateLabel()
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                
                lblTotalMoney.Text = string.Format("{0:c}",betting.totalMoney);
                lblCall.Text = string.Format("{0:c}",betting.callMoney);
                lblMyMoney.Text = string.Format("{0:c}",me.money);
                lblYourMoney.Text = string.Format("{0:c}",you.money);
            }));
        }

        #region 버튼관련이벤트

        private void CheckButton(BETTING B)
        {
            ShowMsg(B);
            PlaySound((SOUNDSTATE)B);

            if (betting.noMoreBetting)
            {
                this.btnDouble.Enabled = false;
                this.btnQuarter.Enabled = false;
                this.btnHalf.Enabled = false;
                this.btnFull.Enabled = false;
                this.btnBBing.Enabled = false;
            }

            betting.Go(B);
            me.money -= betting.bettingMoney;
            //SendBetting(B); //상대방에게 BETTING상태를 보낸다.              

            ShowButton(false);
            SendBetting(B); //상대방에게 BETTING상태를 보낸다.
            UpdateLabel(); //LABEL을 업데이트 한다.
        }

        //------------------------------------------------------
        private void SendBetting(BETTING B)
        {

            Packet packet = new Packet((int)B, (int)int.MaxValue);
            linkSock.Send(packet.GetBytes());

            if (B == BETTING.BBING || B == BETTING.DOUBLE || B == BETTING.QUARTER
                || B == BETTING.HALF || B == BETTING.FULL)
            {
                betting.round++;
            }
            if (B == BETTING.CALL)
            {
                if (me.cards.Count == 7)
                {
                    DecideWinner(DecideWinState.CHECK);
                    //return;
                }

                betting.noMoreBetting = false;
                betting.round = 0;
            }

            if (B == BETTING.CHECK)
            {
                betting.noMoreBetting = true;
            }

            RSCount++;
            //this.Text += "/-" + RSCount.ToString();

        }

        //------------------------------------------------------
        //버튼을 활성화 할지 않할지 확인 
        //개별 버튼 활성화는 오버로드 한다.
        private void ShowButton(bool IsShow)
        {
            if (IsShow == true)
            {
                this.Invoke(new MethodInvoker(delegate()
                    {
                        this.btnDie.Enabled = true;
                        this.btnDie.BackColor = Color.Gray;
                        this.btnCall.Enabled = true;
                        this.btnCall.BackColor = Color.Gray;
                        this.btnCheck.Enabled = false;
                        this.btnCheck.BackColor = Color.White;
                    }));

                if (betting.noMoreBetting)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        this.btnDouble.Enabled = false;
                        this.btnQuarter.Enabled = false;
                        this.btnHalf.Enabled = false;
                        this.btnFull.Enabled = false;
                        this.btnBBing.Enabled = false;
                        this.btnDouble.BackColor = Color.White;
                        this.btnQuarter.BackColor = Color.White;
                        this.btnHalf.BackColor = Color.White;
                        this.btnFull.BackColor = Color.White;
                        this.btnBBing.BackColor = Color.White;
                    }));
                }
                else
                {
                    foreach (Button B in BtnList)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.btnDouble.Enabled = true;
                            this.btnQuarter.Enabled = true;
                            this.btnHalf.Enabled = true;
                            this.btnFull.Enabled = true;
                            this.btnBBing.Enabled = true;
                            this.btnDouble.BackColor = Color.Gray;
                            this.btnQuarter.BackColor = Color.Gray;
                            this.btnHalf.BackColor = Color.Gray;
                            this.btnFull.BackColor = Color.Gray;
                            this.btnBBing.BackColor = Color.Gray;
                        }));
                    }

                    if (betting.callMoney == 0)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.btnDouble.BackColor = Color.White;
                            this.btnDouble.Enabled = false;
                        }));
                    }

                    if (me.isBoss && betting.round == 0)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            this.btnCall.BackColor = Color.White;
                            this.btnCall.Enabled = false;
                            this.btnCheck.BackColor = Color.Gray;
                            this.btnCheck.Enabled = true;
                        }));
                    }
                }
            }
            else
            {
                foreach (Button B in BtnList)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        B.Enabled = false;
                        B.BackColor = Color.White;
                    }));
                }
            }
        }

        //------------------------------------------------------
  
        private void btnDouble_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.DOUBLE);
        }

        private void btnQuarter_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.QUARTER);
        }

        private void btnHalf_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.HALF);
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.FULL);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.CHECK);
        }

        private void btnBBing_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.BBING);
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.CALL);
        }

        private void btnDie_Click(object sender, EventArgs e)
        {
            CheckButton(BETTING.DIE);
            DecideWinner(DecideWinState.LOSE); //내가 졌다
            RSCount++;
        }

        //------------------------------------------------------
        #endregion

        //imgName을 받으면 카드 이미지를 받아온다.
        private Image getImage(string imgName)
        {
            string fileName = @"..\..\img\" + imgName + ".GIF";
            try { return Image.FromFile(fileName); }
            catch (Exception e) 
            { 
                //MessageBox.Show(e.Message); 
                return null; 
            }
        }

        //잠시 대기
        private void pause()
        {
            Application.DoEvents();
            Thread.Sleep(300);
        }

        Card mCard, uCard;

        //서버는 시작 버튼을 누르면 딜러를 생성해 내카드 3장과 상대방카드 3장을 만들고
        //클라이언트로 카드를 보낸다.
        private void btnStart_Click(object sender, EventArgs e)
        {
            isServer = true;

            Packet packet;

            //me = new Player();
            //you = new Player();
            UpdateLabel();
            
            //this.Text = "";
            try
            {
                //--------------------------------------------------------------------------------------------
                for(int i = 0; i < 3 ; i++)
                {
                    you.cards.Add(dealer.PutCard()); me.cards.Add(dealer.PutCard());
                    packet = new Packet(me.cards[i].ID, you.cards[i].ID); linkSock.Send(packet.GetBytes());
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        ShowCard(CardState.YourCard, i, ShowState.Hide); pause();
                        ShowCard(CardState.MyCard, i, ShowState.Show); pause();
                    }));
                    
                    
                    RSCount++;
                    //this.Text += "/" + RSCount.ToString();
                }
                
                isClickOK = true;   //1~3번 카드 클릭 허락
                btnStart.Visible = false;

                
                //--------------------------------------------------------------------------------------------
                byte[] data = new byte[8];
                linkSock.BeginReceive(data, 0, 8, SocketFlags.None, new AsyncCallback(OnReceive), data);
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10054)
                {
                    MessageBox.Show("접속이 끊어졌습니다.");
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        mnuConnectServer.Enabled = true;
                        mnuStartServer.Enabled = true;
                    }));
                    linkSock.Close();
                    return;
                }
            }            
        }

        //패킷
        class Packet
        {
            public int PacketNum1;
            public int PacketNum2;

            public Packet(int PacketNum1, int PacketNum2)
            {
                this.PacketNum1 = PacketNum1;
                this.PacketNum2 = PacketNum2;
            }

            // packet의 크기를 리턴하는 property
            public int Size
            {
                get { return 8; }
            }

            // 자신을 byte[]로 바꾸어주는 함수
            public byte[] GetBytes()
            {
                byte[] data = new byte[Size];
                Buffer.BlockCopy(BitConverter.GetBytes(PacketNum1), 0, data, 0, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(PacketNum2), 0, data, 4, 4);
                return data;
            }

            // byte[] -> packet 를 만들어 주는 생성자
            public Packet(byte[] data)
            {
                if (data.Length != Size) throw new Exception("Bad Packet");

                PacketNum1 = BitConverter.ToInt32(data, 0);
                PacketNum2 = BitConverter.ToInt32(data, 4);
            }
        }

        bool isClickOK = false; //3장 받고 나서는 1~3번 카드는 클릭을 할수 있어야 된다.
        private void mCard1_Click(object sender, EventArgs e) { if (isClickOK == true) CardClick(mCard1, 0); }
        private void mCard2_Click(object sender, EventArgs e) { if (isClickOK == true) CardClick(mCard2, 1); }
        private void mCard3_Click(object sender, EventArgs e) { if (isClickOK == true) CardClick(mCard3, 2); }
        private void CardClick(PictureBox p, int num)
        {
            isClickOK = false;
           
            mCard = me.cards[num];
            me.cards.Insert(3, mCard);
            me.cards.RemoveAt(num);

            ShowCard(CardState.MyCard, ShowState.Show); //내카드 모두를 다시그린다.

            Packet packet = new Packet(me.cards[2].ID, -1);
            linkSock.Send(packet.GetBytes());
                      
             //카드를 3장씩 받고 한장 선택하면 다음패받을 사람을 체크
            if (isServer == true && RSCount == 4)
                CheckNext();

            RSCount++;
            //this.Text += "/" + RSCount.ToString();
        }

        //다음 카드를 얻어서 상대방에게 보낸다.
        private void CheckNext()
        {
            dealer.Winner(ref me, ref you);

            Packet packet;

            if (me.isBoss == true)
            {
                me.cards.Add(dealer.PutCard());
                you.cards.Add(dealer.PutCard());

                this.Invoke(new MethodInvoker(delegate()
                {
                    if (me.cards.Count == 7 && you.cards.Count == 7)
                    {
                        ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                        ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Hide); pause();
                    }
                    else
                    {
                        ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                        ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                    }               
                }));
            }
            else if (me.isBoss == false)
            {
                you.cards.Add(dealer.PutCard());
                me.cards.Add(dealer.PutCard());

                this.Invoke(new MethodInvoker(delegate()
                {
                    if (me.cards.Count == 7 && you.cards.Count == 7)
                    {
                        ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Hide); pause();
                        ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                    }
                    else
                    {
                        ShowCard(CardState.YourCard, you.cards.Count - 1, ShowState.Show); pause();
                        ShowCard(CardState.MyCard, me.cards.Count - 1, ShowState.Show); pause();
                    }              
                }));
            }

            packet = new Packet(me.cards[me.cards.Count - 1].ID, you.cards[you.cards.Count - 1].ID);
            linkSock.Send(packet.GetBytes());
            RSCount++;

            //-------------------------------------------------------------------------------------
            //4번째이후 카드는 자동으로 돌아가야되므로 걸려잇는 구분
            //this.Text += "/카드결정" + RSCount.ToString();

            dealer.Winner(ref me, ref you);

            if (me.isBoss == true)
            {
                ShowButton(true);
            }

            else if (me.isBoss == false)
            {
                ShowButton(false);
            }

            //-------------------------------------------------------------------------------------
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp h = new frmHelp();
            h.StartPosition = FormStartPosition.CenterParent;
            h.ShowDialog();
        }

        enum DecideWinState { CHECK = 1, WIN, LOSE };

        //위너를 결정한다.
        private void DecideWinner(DecideWinState dwState)
        { 
            string msg = "";
            string cap = "";
  
            if (dwState == DecideWinState.CHECK)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    ShowCard(CardState.AllCard, you.cards.Count - 1, ShowState.Show);
                }));
                dealer.Winner(ref me, ref you);
            
            }
            else if (dwState == DecideWinState.WIN){ me.isBoss = true; you.isBoss = false; }
            else if (dwState == DecideWinState.LOSE ){ me.isBoss = false; you.isBoss = true; }

            if (me.isBoss == true)
            {
                me.money += betting.totalMoney;
                msg = "이겼습니다.            ";
                PlaySound(SOUNDSTATE.WIN);
            }
            else
            {
                you.money += betting.totalMoney;
                msg = "졌습니다.              ";
                PlaySound(SOUNDSTATE.LOSE);
            }

            if (dwState == DecideWinState.CHECK) //자기가 DIE한게 아니면 남의 1,2 번 카드를 보여준다.
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    ShowCard(CardState.YourCard, 0, ShowState.Show);
                    ShowCard(CardState.YourCard, 1, ShowState.Show);
                }));

                msg += "\n\n상대: " + you.title.ToString() + "\n\n나:    " + me.title.ToString();
            }

            if(isServer == true )cap = "서버";
            else cap = "클라이언트";
            
            MessageBox.Show(msg, cap);
            
            InitGame();
        }

        //게임 초기화 함수
        private void InitGame()
        {
            if (isServer == true) btnStart.Visible = true; //서버이면 시작버튼 보여줌
            this.Text = "";     //라벨 초기화            
            ShowButton(false);  //버튼은 감춤
            isServer = false;   //서버무유 false
            isClickOK = true;   //1~3번재 카드 클릭 허용
            RSCount = -1;        //보내기 받기 횟수 0
            dealer.Shuffle();   //카드 섞기
            lblMsg.Text = "";
            me.cards.Clear();
            you.cards.Clear();

            betting.totalMoney = betting.BBING * 2;
            betting.callMoney = 0;
            betting.noMoreBetting = false;
            betting.round = 0;

            me.money -= betting.BBING;
            you.money -= betting.BBING;

            foreach (PictureBox p in MyPicList) p.Image = getImage("empty");
            foreach (PictureBox p in YourPicList) p.Image = getImage("empty");

            UpdateLabel();      //라벨 보여줌
        }
    }
    //---------------------------------------------------------------------------------------------
}