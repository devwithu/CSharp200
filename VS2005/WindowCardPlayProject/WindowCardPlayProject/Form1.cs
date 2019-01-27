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

        //ù��° ī�带 �˸��� boolean����..�ո��� �����ְ�....�������ʹ� �޸�����.
        private bool isStart = false;

        //true ,,,��ǻ�� false.. ���
        private bool isCheckUser = false;

        //��ǻ���� �а�.. �����ؼ� �Ű����� ��ġ
        private int computerLocationX = 0;
        private int computerLocationY = 0;
        //����� �а� .. �����ؼ� �Ű����� ��ġ
        private int userLocationX = 0;
        private int userLocationY = 0;



        //ī���� ������ġ�� �����ϴ� ����
        private int original_locationX = 0;
        private int original_locationY = 0;
        //���콺�� ������ ��ǥ
        private int mouseX = 0;
        private int mouseY = 0;
        //���콺�� Ŭ��..���콺 �ٿ��϶� mousecheck=true �ν� ���콺 ���� �̺�Ʈ ����
        private bool mouseCheck = false;

        //�����ī�� �� ���� ī��
        private string cardIndex = null;

        //����ڿ� ��ǻ���� ����
        private int current_number = 0;
        //�迭�� ����
        private int computer_ArrayIndex = 0;
        private int user_ArrayIndex = 0;



        //������ �ٽ� ����
        private void gameRestart()
        {
            //���ε��  ī�带 ä���..��������
            this.newCard = null;
            computer_Picture = null;
            user_Picture = null;
            newCardImage = null;


            createObject();


            newCard.full();
            current_number = 0;
            computer_ArrayIndex = 0;
            user_ArrayIndex = 0;
            //�� �ؽ�Ʈ ����
            this.label_Com.Text = "";
            this.label_User.Text = "";



            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                if (this.panel1.Controls[i].GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    this.panel1.Controls.RemoveAt(i);
                    // Controls�� �޼ҵ��� Remove�� ���ѹ����� ControlCollection���� �˾Ƽ� index�ϳ���
                    // ������ ����.
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
        ///CardCase���� �Ѿ�� ī�� ������ ������ ī�� �̹����� Ȯ����
        /// </summary>
        /// <param name="index">� ī���</param>
        private void cardcheckForImage(int index)
        {
            //true �϶� ��ǻ��
            //fase �ϋ� ���

            //�������� �������� ����
            this.cardIndex = newCard.GetCard(this.current_number);

            switch (this.cardIndex.Substring(0, 1).Trim().ToUpper())
            {
                case "S":
                    {
                        if (isCheckUser)		//true�϶�...��ǻ��
                        {
                            string temp = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card = int.Parse(temp);

                            //��ǻ�� �ǳڿ� �̹��� �ø���
                            this.dynaminc_PictureBoxMake(isCheckUser);
                        }
                        else
                        {
                            string temp = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card = int.Parse(temp);

                            //��� �ǳڿ� �̹��� �ø���
                            this.dynaminc_PictureBoxMake(isCheckUser);
                        }
                    }
                    break;

                case "D":
                    {
                        if (isCheckUser)		//true�϶�...��ǻ��
                        {
                            string temp2 = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card2 = int.Parse(temp2);

                            //��ǻ�� �ǳڿ� �̹��� �ø���
                            this.dynaminc_PictureBoxMake(isCheckUser);

                        }
                        else
                        {
                            string temp2 = this.cardIndex.Substring(1, 2).Trim().ToUpper();
                            int temp_Card2 = int.Parse(temp2);

                            //��� �ǳڿ� �̹��� �ø���
                            this.dynaminc_PictureBoxMake(isCheckUser);

                        }
                    }
                    break;
            }

        }


        /// <summary>
        /// �������� �̹����� �����ϰ� ��
        /// ��ǻ�� �ǳڰ� user�ǳڿ�..�ϳ��� ������..����
        /// </summary>
        /// <param name="check">check-��ǻ�� vs ����</param>
        private void dynaminc_PictureBoxMake(bool check)
        {
            if (check)
            {

                if (this.current_number < 2)
                {
                    //ù��° ī��� �ո��� �����ش�.
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
                //��Ʈ�� Tag�� ī�尪�� �־�д�.
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
                else		//���з� �� ī�忡 �̺�Ʈ �����ϱ�  --���̱�
                {
                    this.user_Picture[user_ArrayIndex] = new PictureBox();
                    user_Picture[user_ArrayIndex].Image = this.newCardImage.bringTheBackImage();

                    // �̺�Ʈ, ���콺 ���� �̺�Ʈ
                    this.user_Picture[user_ArrayIndex].MouseDown += new MouseEventHandler(user_PictureMouseDown);
                    this.user_Picture[user_ArrayIndex].MouseUp += new MouseEventHandler(user_PictureMouseUp);
                    this.user_Picture[user_ArrayIndex].MouseMove += new MouseEventHandler(user_PictureMouseMove);
                }


                user_Picture[user_ArrayIndex].Location = new System.Drawing.Point(0, 0);
                user_Picture[user_ArrayIndex].Size = new System.Drawing.Size(80, 125);
                //��Ʈ�� Tag�� ī�尪�� �־�д�.
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
            //���� �̹��� ����
            this.computer_Picture = new PictureBox[2];
            //���� �̹��� ����
            this.user_Picture = new PictureBox[2];
            check_winner = new CardWinnerCheck();
        }
        /// <summary>
        /// center�� �̹����� Ŭ��������...ī�带 ����
        /// </summary>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Ÿ�̸� �̺�Ʈ�� �۵���.... ī�尡 Moving ���϶��� Ŭ���̺�Ʈ�� �Ұ���

            if (!this.timer_CardMove.Enabled)
            {
                //2�� 2���� �и� ������.
                if (this.current_number < 4)
                {
                    if (isStart)		//true �ϋ�..ù��° ī���.
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
        /// �̹��� ���� ���콺�� ��������...���콺 ����Ʈ�� �ٲٴ� �̺�Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //ī�尡 ���� 2���� ��������....�� �������� ���콺����Ʈ�� ��ȭ����
            if (this.current_number <= 3)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;

        }

       
        /// <summary>
        /// Ÿ�̸� ��ü�� ���� ȣ��Ǵ� �޼ҵ�..�̹��� move�޼ҵ�
        /// </summary>
        /// <param name="ck">��ǻ�ͳ� ����̳�</param>
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
        //------------------------- ī���� ���̱⸦ ���� �̺�Ʈ...��--------------------------------------->


        //ī���� �̺�Ʈ��..user�� �̺�Ʈ
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
            //���콺�� �̹����� ��������..
            if (mouseCheck)
            {

                this.user_Picture[user_ArrayIndex - 1].Left += (e.X - this.mouseX);
                this.user_Picture[user_ArrayIndex - 1].Top += (e.Y - this.mouseY);
                this.user_Picture[user_ArrayIndex - 1].BringToFront();
            }
            this.user_Picture[user_ArrayIndex - 1].BringToFront();
        }


        /// <summary>
        /// ������ �ִ� ī�带 Reverse �ϱ�...^^
        /// </summary>
        private void reverseCard()
        {
            string temp;
            string t1;   //���� picturebox1�� d6
            string t2;	 //���� picturebox2�� c4


            t1 = (string)this.user_Picture[0].Tag;	//�ȿ� �����ִ� ī��
            t2 = (string)this.user_Picture[1].Tag;	//�����ִ� ī��

            //tag�� �ٲ۵�
            temp = t1;
            t1 = t2;
            this.user_Picture[0].Tag = (object)t1;
            t2 = temp;
            this.user_Picture[1].Tag = (object)t2;
            //�̹��� ��ȯ
            this.user_Picture[0].Image = this.newCardImage.bringTheImage(t1);
            this.user_Picture[1].Image = this.newCardImage.bringTheBackImage();
        }
        //Ű�ٿ�.�̺�Ʈ...^^#�º�..
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:	//���۸޴�
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
                        MessageBox.Show("ī�尡 ���ڶ��ϴ�.", "�峭ĥ��?!");

                    break;
            }
        }


        private void viewMatch()
        {
            //��ǻ�Ϳ� Userī���� Tag�� �����´�.

            //��ǻ�� ī���� TAG
            string temp1 = "";

            //ī�带 ��ġ�� �κ�
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

            //����� ī���� Tag
            string temp2 = "";

            //ī�带 ��ġ�� �κ�
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

            //����� �����ϴ� ��ü�� �޼ҵ�
            this.check_winner.checkMatch(temp1, temp2);

            //��������Ʈ
            operationDelegate startOperator = new operationDelegate(this.check_winner.searchForLightEqual);
            startOperator += new operationDelegate(this.check_winner.eachdoubleCheck);
            startOperator += new operationDelegate(this.check_winner.eachSingleCheck);


            startOperator();

            int index = this.check_winner.WinnerProperty;

            this.showGamePanel(index);
        }

        //����� �����ִ� �޼ҵ�
        private void showGamePanel(int index)
        {
            // 0 �̸� ���º�
            // 1 �̸� ���� �¸�
            // 2 �̸� ������� �¸�

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

                    //�޸� ī���� move�� �Ϸ��ٸ� ī�带 reverse�ض�.
                    if (user_ArrayIndex == 1)
                        this.reverseCard();

                    this.current_number++;
                    user_ArrayIndex++;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //���ε��  ī�带 ä���..��������
            newCard.full();
            //ù��° ī�尡 ����.
            this.isStart = true;
            //��ǻ�Ͱ� �����Ѵ�
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