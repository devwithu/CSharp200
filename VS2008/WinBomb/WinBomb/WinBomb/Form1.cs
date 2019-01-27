using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
namespace WinBomb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //BuildMenuSystem();
            LoadImage();
            Icon ic1 = new Icon("../../image/icon1.ico");
            this.Icon = ic1;
            //this.Text = " 지뢰 찾기";
            Initialize();
        }


        private Block[,] board;
        Position[] pos;
        private ImageList imglist_mine;
        private ImageList imglist_num;
        private ImageList imglist_smile;
        private SoundPlayer splay;
        private Order new_time;
        private Order old_time;
        private Position boardsize;         // 보드 사이즈
        private Position pre;

        private int cnt = 0;        // 1초마다 1증가
        private int mine = 0;       // 지뢰 개수
        private int smile = 0;      // 스마일 ID 
        private bool clockflag = true;      // 시간 true = ON
        private bool endflag = false;       // 끝 표시 
        private bool soundcheck = true;    // 소리 재생 유무
        private bool mouseflag = false;
        private int clientwidth;
        private int clientheight;
        private int grade = 2;              // default grade


        TimerCallback t;                    // 시간 
        System.Threading.Timer time;



        // 게임에 사용할 이미지들을 로드
        public void LoadImage()
        {
            imglist_mine = initializeImage("bitmap1.bmp", 16);
            imglist_num = initializeImage("bitmap3.bmp", 12);
            imglist_smile = initializeImage("bitmap5.bmp", 5);
        }
        // 초기 셋팅 초,중,고급
        public void Initialize()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;

            if (grade == 1) // 초급
            {
                this.Size = new Size(178, 268);
                SetClient(10, 9, 9, 168, 232);
            }
            else if (grade == 2)    // 중급
            {
                this.Size = new Size(290, 380);
                SetClient(40, 16, 16, 280, 344);
            }
            else                     // 고급  
            {
                this.Size = new Size(514, 380);
                SetClient(99, 16, 30, 504, 344);
            }

            // 초기화
            Order temp = new Order();
            new_time = temp;
            old_time = temp;
            clockflag = true;
            endflag = false;
            InitMine();
        }
        // 지뢰갯수,보드 행열 ,클라이언트크기 셋팅 
        public void SetClient(int m, int r, int c, int width, int height)
        {
            mine = m; // 지뢰 갯수 셋팅
            boardsize.row = r;
            boardsize.col = c;
            clientwidth = width;
            clientheight = height;
        }
        // 보드를 초기화 한다.
        public void InitMine()
        {
            board = new Block[boardsize.row, boardsize.col];   // 블록
            pos = new Position[mine];  // 지뢰 위치 저장


            for (int i = 0; i < boardsize.row; i++)
            {
                for (int j = 0; j < boardsize.col; j++)
                {
                    board[i, j].bState = BombState.EMPTY;
                    board[i, j].oState = OpenState.CLOSE;
                    board[i, j].down = false;
                }
            }
            SetMine(); // 지뢰 셋팅
            CalMine();  // 보드 계산
        }
        // 지뢰를 랜덤으로 설치한다.
        public void SetMine()
        {
            Random r = new Random();
            int count = 0;
            int row = 0;
            int col = 0;

            while (true)
            {
                if (count == mine) break;
                row = r.Next(boardsize.row);
                col = r.Next(boardsize.col);
                if (board[row, col].bState != BombState.BOMB)
                {
                    pos[count].row = row;
                    pos[count].col = col;
                    count++;
                    board[row, col].bState = BombState.BOMB;
                }
            }
        }
        // 지뢰 주변의 숫자 계산
        public void CalMine()
        {
            for (int t = 0; t < mine; t++)
            {
                int x = pos[t].row;
                int y = pos[t].col;

                for (int i = x - 1; i <= x + 1; i++)
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && j >= 0 && i <= (boardsize.row - 1) && j <= (boardsize.col - 1) && board[i, j].bState != BombState.BOMB)
                            board[i, j].bState++;
                    }
            }
        }
        //// 메뉴 구축
        //public void BuildMenuSystem()
        //{
        //    MainMenu mainMenu = new MainMenu();

        //    MenuItem game = mainMenu.MenuItems.Add("게임(&G)");
        //    MenuItem help = mainMenu.MenuItems.Add("도움말(&H)");

        //    MenuItem newgame = new MenuItem("새 게임(&N)", new EventHandler(this.NewGame_Clicked), Shortcut.F2);
        //    MenuItem grade1 = new MenuItem("초급(&B)", new EventHandler(this.Grade1_Clicked));
        //    MenuItem grade2 = new MenuItem("중급(&I)", new EventHandler(this.Grade2_Clicked));
        //    MenuItem grade3 = new MenuItem("고급(&E)", new EventHandler(this.Grade3_Clicked));
        //    MenuItem sound = new MenuItem("소리(&S)", new EventHandler(this.Sound_Clicked));
        //    MenuItem endgame = new MenuItem("끝내기", new EventHandler(this.EndGame_Clicked), Shortcut.CtrlX);
        //    MenuItem mineinfo = new MenuItem("지뢰찾기 정보", new EventHandler(this.Mineinfo_Clicked));
        //    grade2.Checked = true;
        //    sound.Checked = true;

        //    game.MenuItems.Add(newgame);
        //    game.MenuItems.Add(grade1);
        //    game.MenuItems.Add(grade2);
        //    game.MenuItems.Add(grade3);
        //    game.MenuItems.Add(sound);
        //    game.MenuItems.Add(endgame);

        //    help.MenuItems.Add(mineinfo);

        //    this.Menu = mainMenu;
        //}

        // **************************         메뉴 핸들      **********************************//
        public void NewGame_Clicked(object sender, EventArgs e)
        {
            Initialize();
        }  // 새게임
        public void Grade1_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(1);
            grade = 1;
            KillTime(time);
            Initialize();
        }      // 초급 
        public void Grade2_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(2);
            grade = 2;
            KillTime(time);
            Initialize();
        }   // 중급
        public void Grade3_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(3);
            grade = 3;
            KillTime(time);
            Initialize();
        }   // 고급    
        public void Sound_Clicked(object sender, EventArgs e)
        {
            if (soundcheck)
            {
                this.소리SToolStripMenuItem.Checked = false;    // 소리 check 표시
                soundcheck = false;
            }
            else
            {
                soundcheck = true;
                this.소리SToolStripMenuItem.Checked = true;
            }
            KillTime(time);
            Initialize();
        }   //소리 클릭시 
        public void EndGame_Clicked(object sender, EventArgs e)
        {
            this.Dispose();
        }  // 끝내기
        public void Mineinfo_Clicked(object sender, EventArgs e)    // 지뢰찾기 정보
        {
            string s = " 지뢰 찾기 v0.9 \n";
            s += "Copyrigh ⓒ 2008 - 0910 made by Kim and modified by Cho\n\n";
            s += " 지적 사항이나 좀 더 프로그램에 관해 알고 싶으신 분은\n";
            s += " 정보문화사로 메일 주세요.";
            MessageBox.Show(s);

        }
        // 메뉴 체크 표시
        public void Menu_Checked(int n)
        {
            if (n == 1)
            {
                this.초급BToolStripMenuItem.Checked = true;
                this.중급IToolStripMenuItem.Checked = false;
                this.고급EToolStripMenuItem.Checked = false;
            }
            else if (n == 2)
            {
                this.초급BToolStripMenuItem.Checked = false;
                this.중급IToolStripMenuItem.Checked = true;
                this.고급EToolStripMenuItem.Checked = false;
            }
            else if (n == 3)
            {
                this.초급BToolStripMenuItem.Checked = false;
                this.중급IToolStripMenuItem.Checked = false;
                this.고급EToolStripMenuItem.Checked = true;
            }

        }
        // ***********************************************************************************//

        // 마우스 클릭시
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IsBoard(e.X, e.Y) && !endflag)
            {
                Position mouse = new Position();

                mouse = GetIndex(e.Y, e.X);

                if (e.Button == MouseButtons.Left)
                {
                    if (board[mouse.row, mouse.col].oState != OpenState.FLAG) // 깃발이 아니면
                    {
                        if (board[mouse.row, mouse.col].bState == BombState.BOMB)
                        {   // 폭탄이면
                            smile = 2;
                            SmileUpdate();
                            KillTime(time);
                            FailFindMine(mouse.row, mouse.col);
                        }
                        else
                        {
                            if (clockflag)  // 처음 클릭 되는 순간 한번만 시간콜
                            {
                                StartTime();
                                clockflag = false;
                            }
                            Chain_Bomb(mouse.row, mouse.col);    // 폭탄이 아니면 연쇄 반응
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right && board[mouse.row, mouse.col].oState != OpenState.OPEN)    // 오른쪽 버튼이면
                {
                    if (board[mouse.row, mouse.col].oState == OpenState.CLOSE)  // 처음에는 깃발
                    {
                        board[mouse.row, mouse.col].oState = OpenState.FLAG;
                        DisplayFlagNUM(mine--);
                    }
                    else if (board[mouse.row, mouse.col].oState == OpenState.FLAG)  // 다음에는 물음표
                    {
                        board[mouse.row, mouse.col].oState = OpenState.QUESTION;
                        DisplayFlagNUM(mine++);
                    }
                    else if (board[mouse.row, mouse.col].oState == OpenState.QUESTION)  // 다시 CLOSE
                        board[mouse.row, mouse.col].oState = OpenState.CLOSE;

                    Invalidate(GetX(mouse.col), GetY(mouse.row), 16, 16);

                    if (mine == 0)  // 깃발이 정확한 지 점검한다.
                    {
                        HappyEnd();
                    }
                }
            }

            if (!endflag)
            {
                smile = 0;
                SmileUpdate();
            }

            base.OnMouseClick(e);
        }
        // 마우스 다운시
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (IsSmile(e.X, e.Y))
            {
                smile = 4;
                SmileUpdate();
                KillTime(time);
                Initialize();
            }
            else if (!endflag)
            {
                smile = 1;
                SmileUpdate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsBoard(e.X, e.Y) && !endflag)
            {
                Position mouse = new Position();
                mouse = GetIndex(e.Y, e.X);

                if (e.Button == MouseButtons.Left && board[mouse.row, mouse.col].oState != OpenState.FLAG && board[mouse.row, mouse.col].oState != OpenState.OPEN)
                {
                    if (pre.row != mouse.row || pre.col != mouse.col)
                    {
                        board[mouse.row, mouse.col].down = true;
                        Invalidate(GetX(mouse.col), GetY(mouse.row), 16, 16);
                        board[pre.row, pre.col].down = false;
                        Invalidate(GetX(pre.col), GetY(pre.row), 16, 16);
                        pre = mouse;
                        mouseflag = true;
                    }
                }

            }
            else if (!IsBoard(e.X, e.Y) && e.Button == MouseButtons.Left && mouseflag && !endflag)
            {

                board[pre.row, pre.col].down = false;
                Invalidate(GetX(pre.col), GetY(pre.row), 16, 16);
                mouseflag = false;

            }
            base.OnMouseMove(e);
        }
        // 재귀적으로 EMPTY일경우 연쇄 폭발을
        public void Chain_Bomb(int x, int y)   // row -> x colmn -> y
        {   // 인덱스 범위를 벗어나지 않고 오픈상태와 깃발 상태가 아니면 
            while (x >= 0 && x <= (boardsize.row - 1) && y >= 0 && y <= (boardsize.col - 1) && board[x, y].oState != OpenState.OPEN && board[x, y].oState != OpenState.FLAG)
            {
                board[x, y].oState = OpenState.OPEN;
                Invalidate(GetX(y), GetY(x), 16, 16);

                if (board[x, y].bState == BombState.EMPTY)
                {
                    Chain_Bomb(x - 1, y - 1);
                    Chain_Bomb(x - 1, y);
                    Chain_Bomb(x - 1, y + 1);
                    Chain_Bomb(x, y - 1);
                    Chain_Bomb(x, y + 1);
                    Chain_Bomb(x + 1, y - 1);
                    Chain_Bomb(x + 1, y);
                    Chain_Bomb(x + 1, y + 1);
                }
                break;
            }
        }

        // ***********************************************************************************//
        // 지뢰 찾기 성공할 경우
        public void HappyEnd()
        {
            int max = 99;
            if (grade == 1) max = 10;
            if (grade == 2) max = 40;
            bool happy = true;
            for (int i = 0; i < max; i++)
            {
                if (!(board[pos[i].row, pos[i].col].oState == OpenState.FLAG))
                {
                    happy = false;
                    break;
                }
            }
            if (happy)
            {
                SoundPlay("닭울음.wav");
                smile = 3;
                SmileUpdate();
                KillTime(time);
                MessageBox.Show("@@지뢰 찾기 대성공@@");
                endflag = true;
            }
        }
        // 실패할 경우 모든 지뢰 보여주기
        public void FailFindMine(int row, int col)
        {
            if (soundcheck)
                SoundPlay("BANGBANG.wav");
            for (int i = 0; i < mine; i++)
            {
                if (pos[i].row == row && pos[i].col == col) board[row, col].bState = BombState.BOMB;
                else if (board[pos[i].row, pos[i].col].oState == OpenState.FLAG) board[pos[i].row, pos[i].col].bState = BombState.FLAGEND;
                else board[pos[i].row, pos[i].col].bState = BombState.END;

                board[pos[i].row, pos[i].col].oState = OpenState.OPEN;

                Invalidate(GetX(pos[i].col), GetY(pos[i].row), 16, 16);
            }
            endflag = true;
        }

        // ***********************************************************************************//
        public Position GetIndex(int x, int y) // 인덱스 계산
        {
            Position temp = new Position();
            temp.row = (x - 55) / 16;
            temp.col = (y - 12) / 16;
            return temp;
        }
        // Column 을 입력받아 x좌표를 리턴
        public int GetX(int x) { return x * 16 + 12; }
        // Row 을 입력 받아 y좌표를 리턴
        public int GetY(int y) { return y * 16 + 55; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawUtil.Draw3DRect(g, 0, 0, clientwidth, clientheight - 20, false, 2);   // 바깥상자
            DrawUtil.Draw3DRect(g, 9, 9, clientwidth - 9, 46, true, 2);     // 안쪽상자
            DrawUtil.Draw3DRect(g, 9, 52, clientwidth - 9, clientheight - 30, true, 3);   // 보드외형

            DrawNUM(g, clientwidth - 53, 16, new_time);    // 시간
            DrawSmile(g, (clientwidth / 2) - 12, 16, smile);        // 스마일
            DrawNUM(g, 15, 16, CalOrder(mine)); //지뢰수


            for (int x = 12; x <= (boardsize.col - 1) * 16 + 12; x += 16)
            {  // col          
                for (int y = 55; y <= (boardsize.row - 1) * 16 + 55; y += 16)  // row      
                {
                    Position b = new Position();
                    b = GetIndex(y, x);
                    if (board[b.row, b.col].oState == OpenState.CLOSE)
                        g.DrawImage(imglist_mine.Images[15], x, y);
                    if (board[b.row, b.col].oState == OpenState.FLAG)
                        g.DrawImage(imglist_mine.Images[14], x, y);
                    if (board[b.row, b.col].oState == OpenState.QUESTION)
                        g.DrawImage(imglist_mine.Images[13], x, y);
                    if (board[b.row, b.col].oState == OpenState.OPEN)
                        g.DrawImage(imglist_mine.Images[(int)board[b.row, b.col].bState], x, y);
                    if (board[b.row, b.col].down == true)
                    {
                        g.DrawImage(imglist_mine.Images[0], x, y);
                        board[b.row, b.col].down = false;
                    }
                }
            }
            base.OnPaint(e);
        }
        // 자리수에 맞는 숫자를 그리기 위해 숫자그리기 함수를 콜한다.
        public void DrawNUM(Graphics g, int x, int y, Order o)
        {
            DrawNumImage(g, x, y, o.third);
            DrawNumImage(g, x + 13, y, o.second);
            DrawNumImage(g, x + 26, y, o.first);
        }
        // 해당 번호에 그림을 해당 좌표에 그린다.
        public void DrawNumImage(Graphics g, int x, int y, int num)
        {
            for (int i = 0; i < 12; i++)
                if (num == i) g.DrawImage(imglist_num.Images[i], x, y);
        }
        public void SmileUpdate()
        {
            Invalidate((clientwidth / 2) - 12, 16, 24, 24);
        }
        // num 에 해당되는 스마일그림을 좌표에 그린다.
        public void DrawSmile(Graphics g, int x, int y, int num)
        {
            for (int i = 0; i < 5; i++)
                if (num == i) g.DrawImage(imglist_smile.Images[i], x, y);
        }

        // 시간 시작
        public void StartTime()
        {
            cnt = 0;
            t = new TimerCallback(this.CallClock);
            time = new System.Threading.Timer(t, null, 0, 1000);
        }
        // 1초마다 콜되는 함수 
        public void CallClock(object o)
        {
            if (cnt == 1000)
            {
                MessageBox.Show("시간초과");
                endflag = true;
                cnt = 0;
            }
            else
            {
                new_time = CalOrder(cnt);
                // 이미지가 갱신된 부분만 Invalidate
                if (old_time.first != new_time.first) Invalidate(clientwidth - 53 + 26, 16, 13, 23);
                if (old_time.second != new_time.second) Invalidate(clientwidth - 53 + 13, 16, 13, 23);
                if (old_time.third != new_time.third) Invalidate(clientwidth - 53, 16, 13, 23);

                old_time = new_time;
                cnt++;
            }
        }
        // 깃발 수 표시 
        public void DisplayFlagNUM(int value)
        {
            Order temp = new Order();
            temp = CalOrder(value);
            Invalidate(15, 16, 39, 23);
        }
        // 자리수 계산 (음수 처리 가능)
        public Order CalOrder(int value)
        {
            Order temp = new Order();
            bool minus = false;
            if (value < 0)
            {
                value *= -1;
                minus = true;
            }
            temp.first = value % 10;
            temp.second = value / 10 % 10;
            temp.third = value / 100;

            if (minus)
            { // 마이너스일 경우 
                if (temp.third == 0)
                {
                    if (temp.second == 0)
                    {
                        temp.second = 11;
                    }
                    else temp.third = 11;
                }
            }
            return temp;
        }
        // 스마일을 범위 안이면 true 아니면 false
        public bool IsSmile(int x, int y)
        {
            Rectangle r = new Rectangle((clientwidth / 2) - 12, 16, 24, 24);
            Point p = new Point(x, y);
            return r.Contains(p);
        }
        // 보드 안이면 true 아니면 false    //268 ,266
        public bool IsBoard(int x, int y)
        {
            if (x > 12 && x < boardsize.col * 16 + 12 && y > 55 && y < boardsize.row * 16 + 55)
                return true;
            return false;
        }
        // 지정한 부분만을 Invalidate
        public void Invalidate(int x, int y, int width, int height)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            this.Invalidate(r);
        }
        // 음악 재생
        public void SoundPlay(string s)
        {
            splay = new SoundPlayer("../../image/" + s);
            splay.Play();
            if (splay != null) splay.Dispose();
        }
        // 시간 죽이기
        public void KillTime(System.Threading.Timer t)
        {
            if (t != null) t.Dispose();
        }
        // 이미지파일 이름과 아이템수를 가져와 계산한 후 이미지를 읽어 들인다.
        public ImageList initializeImage(string s, int items)
        {
            Image img = Image.FromFile("../../image/" + s);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            int width = img.Width / items;
            int height = img.Height;

            ImageList imgList = new ImageList();
            ImageList tempList = new ImageList();

            tempList.ColorDepth = ColorDepth.Depth24Bit;
            tempList.ImageSize = new Size(width, height);
            tempList.Images.AddStrip(img);

            imgList.ColorDepth = ColorDepth.Depth24Bit;
            imgList.ImageSize = new Size(height, width);

            for (int i = 0; i < tempList.Images.Count; i++)
            {
                Image temp = tempList.Images[i];
                temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                imgList.Images.Add(temp);
            }
            return imgList;

        }

        //private void menuStrip1_MouseHover(object sender, EventArgs e)
        //{
        //    if (this.menuStrip1.Visible)
        //    {
        //        this.menuStrip1.Visible = false;
        //    }
        //    else {
        //        this.menuStrip1.Visible = true;
        //    }
        //}



    }
}