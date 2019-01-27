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
            Icon ic1 = new Icon("icon1.ico");
            this.Icon = ic1;
            //this.Text = " ���� ã��";
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
        private Position boardsize;         // ���� ������
        private Position pre;

        private int cnt = 0;        // 1�ʸ��� 1����
        private int mine = 0;       // ���� ����
        private int smile = 0;      // ������ ID 
        private bool clockflag = true;      // �ð� true = ON
        private bool endflag = false;       // �� ǥ�� 
        private bool soundcheck = true;    // �Ҹ� ��� ����
        private bool mouseflag = false;
        private int clientwidth;
        private int clientheight;
        private int grade = 2;              // default grade


        TimerCallback t;                    // �ð� 
        System.Threading.Timer time;



        // ���ӿ� ����� �̹������� �ε�
        public void LoadImage()
        {
            imglist_mine = initializeImage("bitmap1.bmp", 16);
            imglist_num = initializeImage("bitmap3.bmp", 12);
            imglist_smile = initializeImage("bitmap5.bmp", 5);
        }
        // �ʱ� ���� ��,��,���
        public void Initialize()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
           
            if (grade == 1) // �ʱ�
            {
                this.Size = new Size(178, 268);
                SetClient(10, 9, 9, 168, 232);
            }
            else if (grade == 2)    // �߱�
            {
                this.Size = new Size(290, 380);
                SetClient(40, 16, 16, 280, 344);
            }
            else                     // ���  
            {
                this.Size = new Size(514, 380);
                SetClient(99, 16, 30, 504, 344);
            }

            // �ʱ�ȭ
            Order temp = new Order();
            new_time = temp;
            old_time = temp;
            clockflag = true;
            endflag = false;
            InitMine();
        }
        // ���ڰ���,���� �࿭ ,Ŭ���̾�Ʈũ�� ���� 
        public void SetClient(int m, int r, int c, int width, int height)
        {
            mine = m; // ���� ���� ����
            boardsize.row = r;
            boardsize.col = c;
            clientwidth = width;
            clientheight = height;
        }
        // ���带 �ʱ�ȭ �Ѵ�.
        public void InitMine()
        {
            board = new Block[boardsize.row, boardsize.col];   // ���
            pos = new Position[mine];  // ���� ��ġ ����


            for (int i = 0; i < boardsize.row; i++)
            {
                for (int j = 0; j < boardsize.col; j++)
                {
                    board[i, j].bState = BombState.EMPTY;
                    board[i, j].oState = OpenState.CLOSE;
                    board[i, j].down = false;
                }
            }
            SetMine(); // ���� ����
            CalMine();  // ���� ���
        }
        // ���ڸ� �������� ��ġ�Ѵ�.
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
        // ���� �ֺ��� ���� ���
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
        //// �޴� ����
        //public void BuildMenuSystem()
        //{
        //    MainMenu mainMenu = new MainMenu();

        //    MenuItem game = mainMenu.MenuItems.Add("����(&G)");
        //    MenuItem help = mainMenu.MenuItems.Add("����(&H)");

        //    MenuItem newgame = new MenuItem("�� ����(&N)", new EventHandler(this.NewGame_Clicked), Shortcut.F2);
        //    MenuItem grade1 = new MenuItem("�ʱ�(&B)", new EventHandler(this.Grade1_Clicked));
        //    MenuItem grade2 = new MenuItem("�߱�(&I)", new EventHandler(this.Grade2_Clicked));
        //    MenuItem grade3 = new MenuItem("���(&E)", new EventHandler(this.Grade3_Clicked));
        //    MenuItem sound = new MenuItem("�Ҹ�(&S)", new EventHandler(this.Sound_Clicked));
        //    MenuItem endgame = new MenuItem("������", new EventHandler(this.EndGame_Clicked), Shortcut.CtrlX);
        //    MenuItem mineinfo = new MenuItem("����ã�� ����", new EventHandler(this.Mineinfo_Clicked));
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

        // **************************         �޴� �ڵ�      **********************************//
        public void NewGame_Clicked(object sender, EventArgs e)
        {
            Initialize();
        }  // ������
        public void Grade1_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(1);
            grade = 1;
            KillTime(time);
            Initialize();
        }      // �ʱ� 
        public void Grade2_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(2);
            grade = 2;
            KillTime(time);
            Initialize();
        }   // �߱�
        public void Grade3_Clicked(object sender, EventArgs e)
        {
            Menu_Checked(3);
            grade = 3;
            KillTime(time);
            Initialize();
        }   // ���    
        public void Sound_Clicked(object sender, EventArgs e)
        {
            if (soundcheck)
            {
                this.�Ҹ�SToolStripMenuItem.Checked = false;    // �Ҹ� check ǥ��
                soundcheck = false;
            }
            else
            {
                soundcheck = true;
                this.�Ҹ�SToolStripMenuItem.Checked = true;
            }
            KillTime(time);
            Initialize();
        }   //�Ҹ� Ŭ���� 
        public void EndGame_Clicked(object sender, EventArgs e)
        {
            this.Dispose();
        }  // ������
        public void Mineinfo_Clicked(object sender, EventArgs e)    // ����ã�� ����
        {
            string s = " ���� ã�� v0.9 \n";
            s += "Copyrigh �� 2008 - 0910 made by Kim and modified by Cho\n\n";
            s += " ���� �����̳� �� �� ���α׷��� ���� �˰� ������ ����\n";
            s += " ������ȭ��� ���� �ּ���.";
            MessageBox.Show(s);

        }
        // �޴� üũ ǥ��
        public void Menu_Checked(int n)
        {
            if (n == 1) {
                this.�ʱ�BToolStripMenuItem.Checked = true;
                this.�߱�IToolStripMenuItem.Checked = false;
                this.���EToolStripMenuItem.Checked = false;
            }
            else if (n == 2)
            {
                this.�ʱ�BToolStripMenuItem.Checked = false;
                this.�߱�IToolStripMenuItem.Checked = true;
                this.���EToolStripMenuItem.Checked = false;
            }
            else if (n == 3)
            {
                this.�ʱ�BToolStripMenuItem.Checked = false;
                this.�߱�IToolStripMenuItem.Checked = false;
                this.���EToolStripMenuItem.Checked = true;
            }

        }
        // ***********************************************************************************//

        // ���콺 Ŭ����
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IsBoard(e.X, e.Y) && !endflag)
            {
                Position mouse = new Position();

                mouse = GetIndex(e.Y, e.X);

                if (e.Button == MouseButtons.Left)
                {
                    if (board[mouse.row, mouse.col].oState != OpenState.FLAG) // ����� �ƴϸ�
                    {
                        if (board[mouse.row, mouse.col].bState == BombState.BOMB)
                        {   // ��ź�̸�
                            smile = 2;
                            SmileUpdate();
                            KillTime(time);
                            FailFindMine(mouse.row, mouse.col);
                        }
                        else
                        {
                            if (clockflag)  // ó�� Ŭ�� �Ǵ� ���� �ѹ��� �ð���
                            {
                                StartTime();
                                clockflag = false;
                            }
                            Chain_Bomb(mouse.row, mouse.col);    // ��ź�� �ƴϸ� ���� ����
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right && board[mouse.row, mouse.col].oState != OpenState.OPEN)    // ������ ��ư�̸�
                {
                    if (board[mouse.row, mouse.col].oState == OpenState.CLOSE)  // ó������ ���
                    {
                        board[mouse.row, mouse.col].oState = OpenState.FLAG;
                        DisplayFlagNUM(mine--);
                    }
                    else if (board[mouse.row, mouse.col].oState == OpenState.FLAG)  // �������� ����ǥ
                    {
                        board[mouse.row, mouse.col].oState = OpenState.QUESTION;
                        DisplayFlagNUM(mine++);
                    }
                    else if (board[mouse.row, mouse.col].oState == OpenState.QUESTION)  // �ٽ� CLOSE
                        board[mouse.row, mouse.col].oState = OpenState.CLOSE;

                    Invalidate(GetX(mouse.col), GetY(mouse.row), 16, 16);

                    if (mine == 0)  // ����� ��Ȯ�� �� �����Ѵ�.
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
        // ���콺 �ٿ��
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
        // ��������� EMPTY�ϰ�� ���� ������
        public void Chain_Bomb(int x, int y)   // row -> x colmn -> y
        {   // �ε��� ������ ����� �ʰ� ���»��¿� ��� ���°� �ƴϸ� 
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
        // ���� ã�� ������ ���
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
                SoundPlay("�߿���.wav");
                smile = 3;
                SmileUpdate();
                KillTime(time);
                MessageBox.Show("@@���� ã�� �뼺��@@");
                endflag = true;
            }
        }
        // ������ ��� ��� ���� �����ֱ�
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
        public Position GetIndex(int x, int y) // �ε��� ���
        {
            Position temp = new Position();
            temp.row = (x - 55) / 16;
            temp.col = (y - 12) / 16;
            return temp;
        }
        // Column �� �Է¹޾� x��ǥ�� ����
        public int GetX(int x) { return x * 16 + 12; }
        // Row �� �Է� �޾� y��ǥ�� ����
        public int GetY(int y) { return y * 16 + 55; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawUtil.Draw3DRect(g, 0, 0, clientwidth, clientheight - 20, false, 2);   // �ٱ�����
            DrawUtil.Draw3DRect(g, 9, 9, clientwidth - 9, 46, true, 2);     // ���ʻ���
            DrawUtil.Draw3DRect(g, 9, 52, clientwidth - 9, clientheight - 30, true, 3);   // �������

            DrawNUM(g, clientwidth - 53, 16, new_time);    // �ð�
            DrawSmile(g, (clientwidth / 2) - 12, 16, smile);        // ������
            DrawNUM(g, 15, 16, CalOrder(mine)); //���ڼ�


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
        // �ڸ����� �´� ���ڸ� �׸��� ���� ���ڱ׸��� �Լ��� ���Ѵ�.
        public void DrawNUM(Graphics g, int x, int y, Order o)
        {
            DrawNumImage(g, x, y, o.third);
            DrawNumImage(g, x + 13, y, o.second);
            DrawNumImage(g, x + 26, y, o.first);
        }
        // �ش� ��ȣ�� �׸��� �ش� ��ǥ�� �׸���.
        public void DrawNumImage(Graphics g, int x, int y, int num)
        {
            for (int i = 0; i < 12; i++)
                if (num == i) g.DrawImage(imglist_num.Images[i], x, y);
        }
        public void SmileUpdate()
        {
            Invalidate((clientwidth / 2) - 12, 16, 24, 24);
        }
        // num �� �ش�Ǵ� �����ϱ׸��� ��ǥ�� �׸���.
        public void DrawSmile(Graphics g, int x, int y, int num)
        {
            for (int i = 0; i < 5; i++)
                if (num == i) g.DrawImage(imglist_smile.Images[i], x, y);
        }

        // �ð� ����
        public void StartTime()
        {
            cnt = 0;
            t = new TimerCallback(this.CallClock);
            time = new System.Threading.Timer(t, null, 0, 1000);
        }
        // 1�ʸ��� �ݵǴ� �Լ� 
        public void CallClock(object o)
        {
            if (cnt == 1000)
            {
                MessageBox.Show("�ð��ʰ�");
                endflag = true;
                cnt = 0;
            }
            else
            {
                new_time = CalOrder(cnt);
                // �̹����� ���ŵ� �κи� Invalidate
                if (old_time.first != new_time.first) Invalidate(clientwidth - 53 + 26, 16, 13, 23);
                if (old_time.second != new_time.second) Invalidate(clientwidth - 53 + 13, 16, 13, 23);
                if (old_time.third != new_time.third) Invalidate(clientwidth - 53, 16, 13, 23);

                old_time = new_time;
                cnt++;
            }
        }
        // ��� �� ǥ�� 
        public void DisplayFlagNUM(int value)
        {
            Order temp = new Order();
            temp = CalOrder(value);
            Invalidate(15, 16, 39, 23);
        }
        // �ڸ��� ��� (���� ó�� ����)
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
            { // ���̳ʽ��� ��� 
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
        // �������� ���� ���̸� true �ƴϸ� false
        public bool IsSmile(int x, int y)
        {
            Rectangle r = new Rectangle((clientwidth / 2) - 12, 16, 24, 24);
            Point p = new Point(x, y);
            return r.Contains(p);
        }
        // ���� ���̸� true �ƴϸ� false    //268 ,266
        public bool IsBoard(int x, int y)
        {
            if (x > 12 && x < boardsize.col * 16 + 12 && y > 55 && y < boardsize.row * 16 + 55)
                return true;
            return false;
        }
        // ������ �κи��� Invalidate
        public void Invalidate(int x, int y, int width, int height)
        {
            Rectangle r = new Rectangle(x, y, width, height);
            this.Invalidate(r);
        }
        // ���� ���
        public void SoundPlay(string s)
        {
            splay = new SoundPlayer(s);
            splay.Play();
            if (splay != null) splay.Dispose();
        }
        // �ð� ���̱�
        public void KillTime(System.Threading.Timer t)
        {
            if (t != null) t.Dispose();
        }
        // �̹������� �̸��� �����ۼ��� ������ ����� �� �̹����� �о� ���δ�.
        public ImageList initializeImage(string s, int items)
        {
            Image img = Image.FromFile(s);
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