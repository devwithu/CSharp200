using System;
using System.Windows.Forms;
using Com.JungBo.Logic;
namespace Project190
{
    public partial class Form1 : Form
    {
        public int startStation; //승차역
        public int endStation;   //하차역
        public int payMoney;     //지하철 요금 1~2구역
        public int blockStation; //1, 2, 3호선
        public string picName; //각 역의 그림pic0~36
        public Form1()
        {
            InitializeComponent();
        }
        public void SettingNum(Object picName)
        {
            Floyd fd = new Floyd();  //플로이드
            //pic33에서 pic을 제거-> "33" ->33
            int val = int.Parse(picName.ToString().Replace("pic", ""));
            if (txtStart.Text == "")
            {
                txtStart.Text = val.ToString();
                //그림에 해당하는 역 0~36
                txtStartStation.Text = fd.name[val];
            }
            else if (txtEnd.Text == "")
            {
                if (txtStart.Text.Trim() == val.ToString().Trim())
                {
                    MessageBox.Show("같은역을 선택하셨습니다. 처음부터 다시 선택하십시요");
                    txtStart.Text = "";
                    txtEnd.Text = "";
                    txtStartStation.Text = "";
                    txtEndStation.Text = "";
                }
                else
                {
                    txtEnd.Text = val.ToString();
                    txtEndStation.Text = fd.name[val];
                    //여기서 경로를 가져옴!!
                    fd.Distance();   //최단경로 만들기
                    //시작하는 역-> 역 이름을 갖아온다.
                    lblView.Text = fd.name[int.Parse(txtStart.Text)] + "▶";
                    fd.pathSt = "";
                    fd.pathln = 2;
                    fd.pathTime = 2;
                    fd.test = "";
                    //전역은 몇호선 인가
                    fd.preLine = fd.line[int.Parse(txtStart.Text)];
                    //경로안의 역의 수
                    fd.totstation = 1;
                    //몇 번 갈아탔나
                    fd.changeLine = 0;
                    //기본요금
                    payMoney = 1100;
                    //현재 몇호선
                    blockStation = 1;
                    //경유 역 모두 붙이기
                    lblView.Text += fd.Path(int.Parse(txtStart.Text), int.Parse(txtEnd.Text)) +
                               fd.name[int.Parse(txtEnd.Text)].ToString();
                    //호선을 갈아탈 경우환승 8분추가, 호선변경
                    if (fd.line[int.Parse(txtEnd.Text)] != 0 &&
                        fd.line[int.Parse(txtEnd.Text)] != fd.preLine)
                    {
                        fd.pathTime += 8;
                        fd.changeLine += 1;
                    }
                    //소요시간
                    lblView.Text += "\n\n소요시간 : 약 " + fd.pathTime.ToString() + "분";
                    lblView.Text += "\n\n총 " + fd.totstation.ToString() + "개의 역을 지납니다.";
                    lblView.Text += "\n\n총 " + fd.changeLine.ToString() + "번 환승합니다.";
                    //경유한 역의 수가 8개가 너머가면 가격이 올라간다.
                    if (fd.totstation > 8)
                    {
                        payMoney = 1300;
                        blockStation = 2;
                    }
                    lblView.Text += "\n\n금액 : " + payMoney.ToString()
                        + " (" + blockStation + "구간 현금기준)";
                }
            }
            else if (txtStart.Text != "" && txtEnd.Text != "")
            {
                txtStart.Text = val.ToString();
                txtStartStation.Text = fd.name[val];
                txtEnd.Text = "";
                txtEndStation.Text = "";
            }
        }
        //각 picXXX 픽처박스를 클릭하면 호출된다.-->중요!!
        private void pic00_Click(object sender, EventArgs e)
        {
            PictureBox pd = sender as PictureBox;
            SettingNum(pd.Name);
        }
    }
}