using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowCardPlayProject
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.PictureBox[] computer_Picture = null;
        System.Windows.Forms.PictureBox[] user_Picture = null;
        private CardCase newCard;
        private CreateCardImage newCardImage;
        private CardWinnerCheck check_winner;

        //첫번째 카드를 알리는 boolean변수..앞면을 보여주고....다음부터는 뒷면으로.
        private bool isStart = false;

        //true ,,,컴퓨터 false.. 사람
        private bool isCheckUser = false;

        //컴퓨터의 패가.. 무브해서 옮겨지는 위치
        private int computerLocationX = 0;
        private int computerLocationY = 0;
        //사람의 패가 .. 무브해서 옮겨지는 위치
        private int userLocationX = 0;
        private int userLocationY = 0;



        //카드의 원래위치를 저장하는 변수
        private int original_locationX = 0;
        private int original_locationY = 0;
        //마우스가 눌러진 좌표
        private int mouseX = 0;
        private int mouseY = 0;
        //마우스의 클릭..마우스 다운일때 mousecheck=true 로써 마우스 무브 이벤트 진입
        private bool mouseCheck = false;

        //사용자카드 및 유저 카드
        private string cardIndex = null;

        //사용자와 컴퓨터의 차례
        private int current_number = 0;
        //배열의 순서
        private int computer_ArrayIndex = 0;
        private int user_ArrayIndex = 0;



        //게임을 다시 시작
        private void gameRestart()
        {
            //폼로드시  카드를 채운다..랜덤으로
            this.newCard = null;
            computer_Picture = null;
            user_Picture = null;
            newCardImage = null;


            createObject();


            newCard.full();
            current_number = 0;
            computer_ArrayIndex = 0;
            user_ArrayIndex = 0;
            //라벨 텍스트 삭제
            this.label_Com.Text = "";
            this.label_User.Text = "";



            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                if (this.panel1.Controls[i].GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    this.panel1.Controls.RemoveAt(i);
                    // Controls의 메소드중 Remove를 시켜버리면 ControlCollection에서 알아서 index하나를
                    // 앞으로 당긴다.
                    i--;
                }
            }

            for (int i = 0; i < this.panel2.Controls.Count; i++)
            {
                if (this.panel2.Controls[i].GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    this.panel2.Controls.RemoveAt(i);
                    i--;
                }
            }

        }
        /// <summary>
        ///CardCase에서 넘어온 카드 정보를 가지고 카드 이미지를 확인함
        /// </summary>
        /// <param name="index">어떤 카드냐</param>
        private void cardcheckForImage(int index)
        {
            //true 일때 컴퓨터
            //fase 일떄 사람

            //랜덤으로 구해지는 값들
            this.cardIndex = newCard.GetCard(this.current_number);

            switch (this.cardIndex.Substring(0, 1).Trim().ToUpper())
            {
                case "S":
                    {
                        if (isCheckUser)		//true일때...컴퓨터
                        {
                            string temp = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card = int.Parse(temp);

                            //컴퓨터 판넬에 이미지 올리기
                            this.dynaminc_PictureBoxMake(isCheckUser);
                        }
                        else
                        {
                            string temp = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card = int.Parse(temp);

                            //사람 판넬에 이미지 올리기
                            this.dynaminc_PictureBoxMake(isCheckUser);
                        }
                    }
                    break;

                case "D":
                    {
                        if (isCheckUser)		//true일때...컴퓨터
                        {
                            string temp2 = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card2 = int.Parse(temp2);

                            //컴퓨터 판넬에 이미지 올리기
                            this.dynaminc_PictureBoxMake(isCheckUser);

                        }
                        else
                        {
                            string temp2 = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card2 = int.Parse(temp2);

                            //사람 판넬에 이미지 올리기
                            this.dynaminc_PictureBoxMake(isCheckUser);

                        }
                    }
                    break;
            }

        }


        /// <summary>
        /// 동적으로 이미지를 생성하게 함
        /// 컴퓨터 판넬과 user판넬에..하나씩 번갈아..보냄
        /// </summary>
        /// <param name="check">check-컴퓨터 vs 유저</param>
        private void dynaminc_PictureBoxMake(bool check)
        {
            if (check)
            {

                if (this.current_number < 2)
                {
                    //첫번째 카드는 앞면을 보여준다.
                    computer_Picture[computer_ArrayIndex] = new PictureBox();
                    computer_Picture[computer_ArrayIndex].Image = this.newCardImage.bringTheImage(this.cardIndex);

                    computer_Picture[computer_ArrayIndex].Location = new System.Drawing.Point(this.panel1.Size.Width
                        , this.panel1.Size.Height);
                }
                else
                {
                    computer_Picture[computer_ArrayIndex] = new PictureBox();
                    computer_Picture[computer_ArrayIndex].Image = this.newCardImage.bringTheBackImage();

                    computer_Picture[computer_ArrayIndex].Location = new System.Drawing.Point(this.panel1.Size.Width + 13
                        , this.panel1.Size.Height);

                }

                computer_Picture[computer_ArrayIndex].Size = new System.Drawing.Size(80, 125);
                //컨트롤 Tag에 카드값을 넣어둔다.
                computer_Picture[computer_ArrayIndex].Tag = (object)this.cardIndex;
                this.panel1.Controls.Add(computer_Picture[computer_ArrayIndex]);

                this.timer_CardMove.Start();

            }
            else
            {
                if (this.current_number < 2)
                {
                    this.user_Picture[this.user_ArrayIndex] = new PictureBox();
                    user_Picture[user_ArrayIndex].Image = this.newCardImage.bringTheImage(this.cardIndex);

                }
                else		//뒤패로 들어간 카드에 이벤트 연결하기  --조이기
                {
                    this.user_Picture[user_ArrayIndex] = new PictureBox();
                    user_Picture[user_ArrayIndex].Image = this.newCardImage.bringTheBackImage();

                    // 이벤트, 마우스 제어 이벤트
                    this.user_Picture[user_ArrayIndex].MouseDown += new MouseEventHandler(user_PictureMouseDown);
                    this.user_Picture[user_ArrayIndex].MouseUp += new MouseEventHandler(user_PictureMouseUp);
                    this.user_Picture[user_ArrayIndex].MouseMove += new MouseEventHandler(user_PictureMouseMove);
                }


                user_Picture[user_ArrayIndex].Location = new System.Drawing.Point(0, 0);
                user_Picture[user_ArrayIndex].Size = new System.Drawing.Size(80, 125);
                //컨트롤 Tag에 카드값을 넣어둔다.
                user_Picture[user_ArrayIndex].Tag = (object)this.cardIndex;

                this.panel2.Controls.Add(user_Picture[user_ArrayIndex]);
                this.timer_CardMove.Start();
            }
        }

        public Form1()
        {
            InitializeComponent();
            createObject();
        }

        public void createObject()
        {
            newCard = new CardCase();
            newCardImage = new CreateCardImage();
            //동적 이미지 생성
            this.computer_Picture = new PictureBox[2];
            //동적 이미지 생성
            this.user_Picture = new PictureBox[2];
            check_winner = new CardWinnerCheck();
        }
        /// <summary>
        /// center에 이미지를 클릭했을떄...카드를 세팅
        /// </summary>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //타이머 이벤트가 작동중.... 카드가 Moving 중일때는 클릭이벤트가 불가능

            if (!this.timer_CardMove.Enabled)
            {
                //2개 2개씩 패를 돌린다.
                if (this.current_number < 4)
                {
                    if (isStart)		//true 일떄..첫번째 카드다.
                    {
                        isStart = false;

                        cardcheckForImage(this.current_number);

                        isCheckUser = !isCheckUser;
                    }
                    else
                    {
                        cardcheckForImage(this.current_number);
                        isCheckUser = !isCheckUser;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 이미지 위에 마우스를 놓았을때...마우스 포인트를 바꾸는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //카드가 각각 2개씩 보내졌다....다 보냈으면 마우스포인트는 변화없음
            if (this.current_number <= 3)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;

        }

       
        /// <summary>
        /// 타이머 객체에 의해 호출되는 메소드..이미지 move메소드
        /// </summary>
        /// <param name="ck">컴퓨터냐 사람이냐</param>
        private void image_move(bool ck)
        {
            if (ck)
            {
                this.computerLocationX = this.computer_Picture[computer_ArrayIndex].Location.X;
                this.computerLocationY = this.computer_Picture[computer_ArrayIndex].Location.Y;

                this.computer_Picture[computer_ArrayIndex].Location = new Point(this.computerLocationX - 20,
                    this.computerLocationY - 10);

                this.computer_Picture[computer_ArrayIndex].BringToFront();

            }
            else
            {
                this.userLocationX = this.user_Picture[user_ArrayIndex].Location.X;
                this.userLocationY = this.user_Picture[user_ArrayIndex].Location.Y;

                this.user_Picture[user_ArrayIndex].Location = new Point(this.userLocationX + 26,
                    this.userLocationY + 10);

                this.user_Picture[user_ArrayIndex].BringToFront();
            }
        }
        //------------------------- 카드의 조이기를 위한 이벤트...들--------------------------------------->


        //카드의 이벤트들..user의 이벤트
        private void user_PictureMouseDown(object sender, MouseEventArgs e)
        {
            this.original_locationX = this.user_Picture[user_ArrayIndex - 1].Location.X;
            this.original_locationY = this.user_Picture[user_ArrayIndex - 1].Location.Y;
            this.user_Picture[user_ArrayIndex - 1].BringToFront();

            this.Cursor = Cursors.NoMove2D;
            this.mouseX = e.X;
            this.mouseY = e.Y;
            this.mouseCheck = true;
        }

        private void user_PictureMouseUp(object sender, MouseEventArgs e)
        {
            this.mouseCheck = false;
            this.Cursor = Cursors.Default;

            this.user_Picture[user_ArrayIndex - 1].BringToFront();
            this.user_Picture[user_ArrayIndex - 1].Location = new Point(this.original_locationX, this.original_locationY);

        }

        private void user_PictureMouseMove(object sender, MouseEventArgs e)
        {
            //마우스가 이미지를 물었을떄..
            if (mouseCheck)
            {

                this.user_Picture[user_ArrayIndex - 1].Left += (e.X - this.mouseX);
                this.user_Picture[user_ArrayIndex - 1].Top += (e.Y - this.mouseY);
                this.user_Picture[user_ArrayIndex - 1].BringToFront();
            }
            this.user_Picture[user_ArrayIndex - 1].BringToFront();
        }


        /// <summary>
        /// 겹쳐져 있는 카드를 Reverse 하기...^^
        /// </summary>
        private void reverseCard()
        {
            string temp;
            string t1;   //원래 picturebox1은 d6
            string t2;	 //원래 picturebox2은 c4


            t1 = (string)this.user_Picture[0].Tag;	//안에 숨어있는 카드
            t2 = (string)this.user_Picture[1].Tag;	//덥혀있는 카드

            //tag를 바꾼뒤
            temp = t1;
            t1 = t2;
            this.user_Picture[0].Tag = (object)t1;
            t2 = temp;
            this.user_Picture[1].Tag = (object)t2;
            //이미지 교환
            this.user_Picture[0].Image = this.newCardImage.bringTheImage(t1);
            this.user_Picture[1].Image = this.newCardImage.bringTheBackImage();
        }
        //키다운.이벤트...^^#승부..
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:	//시작메뉴
                    this.gameRestart();
                    break;

                case Keys.X:
                    Application.Exit();
                    break;

                case Keys.R:
                    this.reverseCard();
                    break;


                case Keys.Space:
                    if (this.current_number > 3)
                        this.viewMatch();
                    else
                        MessageBox.Show("카드가 모자랍니다.", "장난칠래?!");

                    break;
            }
        }


        private void viewMatch()
        {
            //컴퓨터와 User카드의 Tag를 가져온다.

            //컴퓨터 카드의 TAG
            string temp1 = "";

            //카드를 펼치는 부분
            foreach (PictureBox t in computer_Picture)
            {
                int temp = t.Size.Width + 20;

                t.Image = this.newCardImage.bringTheImage((string)t.Tag);

                if (computer_Picture[computer_Picture.Length - 1] == t)
                    t.Location = new Point(t.Location.X + temp,
                        t.Location.Y);

                t.Location = new Point(t.Location.X,
                    t.Location.Y);

                temp1 += (string)t.Tag;
                temp1 += "/";
            }

            //사용자 카드의 Tag
            string temp2 = "";

            //카드를 펼치는 부분
            foreach (PictureBox t in user_Picture)
            {
                int temp = t.Size.Width + 20;

                t.Image = this.newCardImage.bringTheImage((string)t.Tag);

                if (user_Picture[user_Picture.Length - 1] == t)
                    t.Location = new Point(t.Location.X - temp,
                        t.Location.Y);

                t.Location = new Point(t.Location.X,
                    t.Location.Y);

                temp2 += (string)t.Tag;
                temp2 += "/";
            }

            //결과를 정리하는 객체의 메소드
            this.check_winner.checkMatch(temp1, temp2);

            //델리게이트
            operationDelegate startOperator = new operationDelegate(this.check_winner.searchForLightEqual);
            startOperator += new operationDelegate(this.check_winner.eachdoubleCheck);
            startOperator += new operationDelegate(this.check_winner.eachSingleCheck);


            startOperator();

            int index = this.check_winner.WinnerProperty;

            this.showGamePanel(index);
        }

        //결과를 보여주는 메소드
        private void showGamePanel(int index)
        {
            // 0 이면 무승부
            // 1 이면 컴의 승리
            // 2 이면 사용자의 승리

            string temp = "Win!!";
            string temp2 = "Lose!!";
            string temp3 = "Draw!!";

            if (index == 0)
            {
                this.label_Com.Text = temp3;
                this.label_User.Text = temp3;
            }
            else if (index == 1)
            {
                this.label_Com.Text = temp;
                this.label_User.Text = temp2;
                this.isCheckUser = true;
            }
            else
            {
                this.label_Com.Text = temp2;
                this.label_User.Text = temp;
                this.isCheckUser = false;
            }
        }
        private void timer_CardMove_Tick(object sender, EventArgs e)
        {
            if (!this.isCheckUser)
            {
                if ((this.computer_Picture[computer_ArrayIndex].Location.X >
                    this.panel1.Location.X + (this.computer_Picture[computer_ArrayIndex].Size.Width / 2) + 20)
                    || (this.computer_Picture[computer_ArrayIndex].Location.Y > 
                    this.panel1.Location.Y + (this.computer_Picture[computer_ArrayIndex].Size.Height / 2) + 20))
                {
                    image_move(true);
                }
                else
                {
                    this.timer_CardMove.Stop();
                    this.computer_ArrayIndex++;

                    this.current_number++;

                }
            }
            else
            {
                if ((this.user_Picture[user_ArrayIndex].Location.X + (this.user_Picture[user_ArrayIndex].Size.Width / 2) < this.panel2.Location.X)
                        || (this.user_Picture[user_ArrayIndex].Location.Y + (this.user_Picture[user_ArrayIndex].Size.Height / 2) < this.panel2.Location.Y))
                {
                    image_move(false);
                }
                else
                {
                    this.timer_CardMove.Stop();

                    //뒷면 카드의 move가 완료됬다면 카드를 reverse해라.
                    if (user_ArrayIndex == 1)
                        this.reverseCard();

                    this.current_number++;
                    user_ArrayIndex++;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //폼로드시  카드를 채운다..랜덤으로
            newCard.full();
            //첫번째 카드가 간다.
            this.isStart = true;
            //컴퓨터가 먼저한다
            this.isCheckUser = true;
        }

        private void gameStartSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameRestart();
        }

        private void gameExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        
    }
}