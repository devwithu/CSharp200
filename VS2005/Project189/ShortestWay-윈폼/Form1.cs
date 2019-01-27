using System;
using System.Windows.Forms;
using Com.JungBo.Logic;
namespace ShortestWay{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            Floyd fl = new Floyd();
            try{
                // 입력 필드가 입력되었는지 확인
                this.CheckFields();
                // 최단거리 메트릭스 계산
                fl.Distance();
                // 입력된 출발 / 도착지로 계산
                // 리턴되는 결과 문자열 받음
                // 결과 출력
                lblOutput.Text =
                    fl.name[comboBox1.SelectedIndex] + " -> "
                    + fl.Path(comboBox1.SelectedIndex, comboBox2.SelectedIndex)
                    + fl.name[comboBox2.SelectedIndex];
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
        }
        private bool CheckFields(){
            bool ret = false;
            if (comboBox1.SelectedIndex == -1){
                throw new Exception("출발지를 선택해 주세요.");
            }
            else if (comboBox2.SelectedIndex == -1){
                throw new Exception("도착지를 선택해 주세요.");
            }
            else{
                ret = true;
            }
            return ret;
        }
        private void button2_Click(object sender, EventArgs e){
            Floyd fl = new Floyd();
            AllPath ap = new AllPath();//새로운 윈폼
            try{
                fl.Distance();
                ap.richTextBox1.Text = fl.PrintPath();
                ap.Show();//새로운 폼
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
        }//
    }
}
