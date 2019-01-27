using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatchSameImageProject
{
    public partial class Form1 : Form
    {
        //����ʵ� ����---------------------
        MButton[] mm;
        MButton tempB;  //ù��° ��ư�� �޾Ƶд�.
        int current = 0;  //ù��° ��ư�ΰ� �ι�° ��ư�ΰ�
        int times = 0;    //������ �ð��� üũ�ϱ�����
        int iters = 0;    //������ ������ ���߸�
        int nums = 12; //��ư���� 12,16,20,24
        int row = 3;     //������ �� 3,4,5,6
        int col = 4;     //Į���� ���⼭�� 4�� ����
        int clicktimes = 0;//���� ȸ�� 2���� 1�� Ŭ��
        int speeding = 3000;//�׸� ������ �ӵ�
        //------------------------------------------------   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.startLb.Visible = true;
            this.���ӽ���SToolStripMenuItem.Enabled = true;
            this.����GToolStripMenuItem.Enabled = false;
            this.Size = new System.Drawing.Size(620, 140);
            this.button2.Enabled = false;
        }

        private void ������NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.����GToolStripMenuItem.Enabled = true;
            //this.���ӽ���SToolStripMenuItem.Enabled = false;
            this.������NToolStripMenuItem.Enabled = false;
            this.startLb.Visible = false;
            this.Size= new System.Drawing.Size(620, 500);
            this.Update();
        }
       
        private void MenuDo(int num)
        {
            TimerStart();
            nums = num;
            this.panel1.Controls.Clear();
            MButtonShow(nums);
            this.button2.Enabled = true;
            this.clicktimes = 0;
            this.label2.Text = "0 times.";
            this.speeding = speeding / (nums/col);
        }//
        private void MButtonShow(int num)
        {
            this.iters = 0;  //  ���������� �ʱ�ȭ
            this.mm = new MButton[num];   //������ ��ư ���� ����
            this.times = 0;  //������ �ð� �ʱ�ȭ
            this.row = mm.Length / col;    //4 : ��ư 4���� ����
            //int col = 4;  // ��ư4��
            ImageArray im = new ImageArray(num);
            int[] aa = im.Getindex();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int x = 30 + 55 * j;
                    int y = 5 + 55 * i;
                    mm[i * col + j] = new MButton(x, y, aa[i * col + j]);
                    mm[i * col + j].MouseUp 
                        += new MouseEventHandler(this.button1_MouseUp);
                    mm[i * col + j].MouseDown 
                        += new MouseEventHandler(this.button1_MouseDown);
                    this.panel1.Controls.Add(mm[i * col + j]);
                }
            }
        }//
        private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            clicktimes++;
            this.label2.Text = (clicktimes/2).ToString() + " times.";
            //MessageBox.Show(sender.ToString());
            //int col = 4;  // ��ư4��
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mm[i * col + j] == (MButton)sender)
                    { //��ư���ȳ�
                        if (!mm[i * col + j].AmIEnd)
                        {//�޸�(����ġ)
                            if (this.current == 0)  //ù��ư
                            {
                                mm[i * col + j].Flops();   //������ ������
                                mm[i * col + j].AmIEnd = true;//������ 
                                this.tempB = mm[i * col + j];  //�ӽù�ư�� ù ��ư�� �Ҵ� ���߿� ������
                                this.current++;      //ù��ư�϶� �������.
                                return;
                            }
                            else
                            {  //�ι�° ��ư
                                mm[i * col + j].Flops();   //������ ������
                                mm[i * col + j].AmIEnd = true;//������ 
                                //this.tempB=mm[i*4+j];  //�ӽù�ư�� ù ��ư�� �Ҵ� ���߿� ������
                                this.current++;      //�ι�°��ư�϶� �������.
                                return;
                            }//else
                        }
                        else if (mm[i * col + j].AmIEnd)  //������ �ո���¶�� �״�� ������
                        {
                            return;
                        }
                    }//if
                }
            }
           
        }

        private void button1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            //int col = 4;  //4�� ����
            //row ���
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((MButton)sender == mm[i * 4 + j])
                    { //��ư ���ҳ�?
                        if (mm[i * col + j].AmIEnd && this.current == 1)  //ù��ư
                        {
                            return;
                        }
                        else if (mm[i * col + j].AmIEnd && this.current >= 2)  //�ι�ư
                        {
                            if (mm[i * col + j].MyNum == this.tempB.MyNum)
                            {  //ù��ư�� �ι�° ��ư���� ������?
                                mm[i * col + j].AmIEnd = true;
                                tempB.AmIEnd = true;
                                this.current = 0;
                                this.iters += 2;
                            }//if
                            else if (mm[i * col + j].MyNum != this.tempB.MyNum)
                            {  //ù��ư�� �ι�° ��ư���� ������?
                                lock (this)
                                {
                                    System.Threading.Thread.Sleep(speeding);
                                    mm[i * col + j].Flips();       //����ġ
                                    mm[i * col + j].AmIEnd = false;  //�� ���þȵ�
                                    tempB.Flips();           //����ġ
                                    tempB.AmIEnd = false;      //�� ���þȵ�
                                    this.current = 0;
                                }
                            }
                        }//else if
                    }//if 1
                }//for 2
            }//for 1
        }

      
        private void TimerStart()
        {
            this.timer1.Enabled = true;

        }//
        private void TimerStop()
        {
            this.timer1.Enabled = false;
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mm[i * col + j].Flops();
                }
            }
            this.timer2.Enabled = true;
            this.times+=15;//�ѹ��� ������ 15�ʸ� ����մϴ�.
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (this.row * 10 < this.times)
            {
                this.TimerStop();
                times = 0;
                this.button2.Enabled = false;
                MessageBox.Show("You Lose");
                return;
            }
            else
            {
                if (this.iters >= this.nums)
                {
                    this.TimerStop();
                    times = 0;
                    this.button2.Enabled = false;
                    MessageBox.Show("You Win");
                    return;
                }
            }
            this.statusStrip1.Items[0].Text = this.times.ToString() + "�� ���";
            this.times++;
        }//
        private void timer2_Tick(object sender, System.EventArgs e)
        {
            //int col = 4;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!mm[i * col + j].AmIEnd)
                    {
                        mm[i * col + j].Flips();
                    }
                }
            }
            this.timer2.Enabled = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            row = 3;
            MenuDo(col * row);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            row = 4;
            MenuDo(col * row);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            row = 5;
            MenuDo(col * row);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            row = 6;
            MenuDo(col * row);
        }

        private void ���ӳ�XToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("�����ðڽ��ϱ�?", "End", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (results == DialogResult.Yes)
            {
                MessageBox.Show("�ȳ��� ��ʽÿ�.");
                this.Dispose();
                this.Close();

            }
        }
    }
}