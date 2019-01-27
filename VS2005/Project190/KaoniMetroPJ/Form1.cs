using System;
using System.Windows.Forms;
namespace Com.JungBo.Logic{
    public partial class Form1 : Form{
        public int startStation; //������
        public int endStation;   //������
        public int payMoney;     //����ö ��� 1~2����
        public int blockStation; //1, 2, 3ȣ��
        public string picName; //�� ���� �׸�pic0~36
        public Form1(){
            InitializeComponent();            
        }
        public void SettingNum(Object picName){
            Floyd fd = new Floyd();  //�÷��̵�
            //pic33���� pic�� ����-> "33" ->33
            int val = int.Parse(picName.ToString().Replace("pic",""));
            if (txtStart.Text == ""){
                txtStart.Text = val.ToString();
                //�׸��� �ش��ϴ� �� 0~36
                txtStartStation.Text = fd.name[val];
            }
            else if (txtEnd.Text == ""){
                if (txtStart.Text.Trim() == val.ToString().Trim()){
  MessageBox.Show("�������� �����ϼ̽��ϴ�. ó������ �ٽ� �����Ͻʽÿ�");
                    txtStart.Text = "";
                    txtEnd.Text = "";
                    txtStartStation.Text = "";
                    txtEndStation.Text = "";
                }
                else{
                    txtEnd.Text = val.ToString();
                    txtEndStation.Text = fd.name[val];
                    //���⼭ ��θ� ������!!
                    fd.Distance();   //�ִܰ�� �����
                    //�����ϴ� ��-> �� �̸��� ���ƿ´�.
                    lblView.Text = fd.name[int.Parse(txtStart.Text)] + "��";
                    fd.pathSt = "";
                    fd.pathln = 2;
                    fd.pathTime = 2;
                    fd.test = "";
                    //������ ��ȣ�� �ΰ�
                    fd.preLine = fd.line[int.Parse(txtStart.Text)];
                    //��ξ��� ���� ��
                    fd.totstation = 1;
                    //�� �� ��������
                    fd.changeLine = 0;
                    //�⺻���
                    payMoney = 1100;
                    //���� ��ȣ��
                    blockStation = 1;
                    //���� �� ��� ���̱�
     lblView.Text += fd.Path(int.Parse(txtStart.Text), int.Parse(txtEnd.Text)) +
                fd.name[int.Parse(txtEnd.Text)].ToString();
                    //ȣ���� ����Ż ���ȯ�� 8���߰�, ȣ������
                    if (fd.line[int.Parse(txtEnd.Text)] != 0 &&
                        fd.line[int.Parse(txtEnd.Text)] != fd.preLine){
                        fd.pathTime += 8;
                        fd.changeLine += 1;
                    }
      //�ҿ�ð�
     lblView.Text += "\n\n�ҿ�ð� : �� " + fd.pathTime.ToString() + "��";
     lblView.Text += "\n\n�� " + fd.totstation.ToString() + "���� ���� �����ϴ�.";
      lblView.Text += "\n\n�� " + fd.changeLine.ToString() + "�� ȯ���մϴ�.";
                    //������ ���� ���� 8���� �ʸӰ��� ������ �ö󰣴�.
                    if (fd.totstation > 8){
                        payMoney = 1300;
                        blockStation = 2;
                    }
                    lblView.Text += "\n\n�ݾ� : " + payMoney.ToString()
                        + " (" + blockStation + "���� ���ݱ���)";
                }
            }
            else if (txtStart.Text != "" && txtEnd.Text != ""){
                txtStart.Text = val.ToString();
                txtStartStation.Text = fd.name[val];
                txtEnd.Text = "";
                txtEndStation.Text = "";
            }
        }
        //�� picXXX ��ó�ڽ��� Ŭ���ϸ� ȣ��ȴ�.-->�߿�!!
        private void pic00_Click(object sender, EventArgs e){
            PictureBox pd = sender as PictureBox;
            SettingNum(pd.Name);   
        }
    }
}