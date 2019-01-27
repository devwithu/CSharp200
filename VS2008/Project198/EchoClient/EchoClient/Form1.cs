using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace EchoClientWin
{
    public partial class Form1 : Form
    {
        bool 환경보기 = false;
        string dialogName;
        string serverIp;
        int serverport;
        bool isAlive = false;
        //채팅 기본 글꼴 지정
        Font font = new Font("굴림", 10);
        string ss = string.Empty;
        //채팅 글꼴 색상
        Color color = Color.Black;
        //-----------------------
        NetworkStream ns = null;
        StreamWriter sw = null;
        StreamReader sr = null;
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
            //-----------------------------
            // 현재 컴퓨터의 아이피를 기본적으로 보여준다.
            IPHostEntry hostIp = Dns.GetHostByName(Dns.GetHostName());
            // 현재 컴퓨터의 아이피를 기본 아이피로 설정 
            serverIp = hostIp.AddressList[0].ToString();
            // 아이피 상자에 보여줍니다.
            txtIP.Text = serverIp;
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void 시작SToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = true;
            this.환경보기VToolStripMenuItem.Text = "환경보기(&V)";
        }
        private void 환경보기VToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel1Collapsed)
            {
                this.splitContainer1.Panel1Collapsed = false;
                환경보기 = true;
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
                환경보기 = false;
            }
            if (환경보기)
            {
                this.환경보기VToolStripMenuItem.Text = "환경감추기(&V)";
            }
            else
            {
                this.환경보기VToolStripMenuItem.Text = "환경보기(&V)";
            }
        }
        private void btnConn_Click(object sender, EventArgs e)
        {
            dialogName = this.txtName.Text;
            if (string.IsNullOrEmpty(dialogName))
            {
                ShowMessage("대화명을 입력하세요.");
                return;
            }
            serverIp = this.txtIP.Text;
            if (string.IsNullOrEmpty(serverIp))
            {
                ShowMessage("주소를 입력하세요.");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPort.Text))
            {
                ShowMessage("포트를 입력하세요.");
                return;
            }
            serverport = int.Parse(this.txtPort.Text);
            isAlive = true;
            환경보기 = false;
            try
            {
                this.Echo();//이것이 실패하면 작동안함.
                this.환경보기VToolStripMenuItem.Text = "환경보기(&V)";
                this.txtName.ReadOnly = true;
                this.toolStripStatusLabel2.Text = "On Chatting!!";
                this.isAlive = true;
                AppendMessage(string.Format("[{0}님 입장]",
                                            dialogName));
                this.txtSend.Focus();
            }
            catch (Exception eee)
            {
                this.txtName.Text = "";
                this.isAlive = false;
            }
        }
        // 쓰기 스트림으로 메세지를 전송합니다. 
        public void SendMessage(string message)
        {
            try
            {
                // 쓰기 스트림이 유효한지를 체크합니다. 
                if (sw != null)
                {
                    // 누가보냈는지와 메세지 내용을 
                    //조합하여 쓰기 스트림에 씁니다. 
                    sw.WriteLine("[" + dialogName + "] "
                        + message);
                    // 쓰기 스트림에 있는 내용을 방출합니다. 
                    sw.Flush();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("보내기 실패:" + ee.Message);
            }
        }
        // 화면의 대화창에 메세지를 출력합니다. 
        public void AppendMessage(string msg)
        {
            if (this.txtDialog != null && this.txtSend != null)
            {
                // 메세지 추가와 함께 개행되도록 한다. 
                this.txtDialog.AppendText(msg + "\r\n");
                // 메세지창에 포커스를 줌 
                this.txtDialog.Focus();
                // 메세지 추가된 부분까지 스크롤시켜 보여줌 
                this.txtDialog.ScrollToCaret();
            }
        }
        public void Echo()
        {
            try
            {
                client = new TcpClient(this.serverIp,
                    this.serverport);//소켓
                //Console.WriteLine("client~~서버에 접속");
                ns = client.GetStream();
                //소켓에 쓰기와
                sw = new StreamWriter(ns, Encoding.Default);
                sr = new StreamReader(ns, Encoding.Default);
                //ctrl+c
                //소켓에서 읽는 것과 소켓에 쓰는 것 분리
                Thread receiveThread = new Thread(new ThreadStart(run));
                // 이 쓰레드가 멈춰도 프로세스가 멈추지 않는다. 
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show("서버 시작 실패");
                throw ee;
            }
        }
        public void run()
        {
            string message = "start";
            try
            {
                if (client.Connected && sr != null)
                {
                    while ((message = sr.ReadLine()) != null)
                    {
                        AppendMessage(message);
                    }
                }
            }
            catch (Exception e)
            {
                //클라이언트의 FORM이 제거되었지만 
                //서버로 보냈던 메세지가 
                //되돌아 오는데 이것을 
                //FORM의 TEXT에 붙이려고 하면 TEXT가 없어
                //에러를 발생시킬 수 있다.
            }
        }
        private void 종료XToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            try
            {
                SendMessage(
            string.Format("{0}님이 퇴장했습니다.", dialogName));
                // 읽기 스트림을 닫습니다. 
                sr.Close();
                // 쓰기 스트림을 닫습니다. 
                sw.Close();
                // 네트워크 스트림을 닫습니다. 
                ns.Close();
                // 클라이언트 소켓을 닫습니다. 
                client.Close();

            }
            catch { }
            finally
            {
                this.Dispose();
            }
        }
        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                string message = this.txtSend.Text;
                SendMessage(message.Trim());
                // 다시 입력할수 있도록 청소
                this.txtSend.Clear();
            }
            else
            {
                this.toolStripButton1.Visible = true;
            }
        }
        private void txtSend_KeyUp(object sender, KeyEventArgs e)
        {
            this.toolStripButton1.Visible = false;
        }
        private void 글꼴FToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                txtSend.Font = fontDialog1.Font;
                txtSend.ForeColor = fontDialog1.Color;
            }
        }
        private void 배경색ToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDialog.BackColor = colorDialog1.Color;
            }
        }
    }
}