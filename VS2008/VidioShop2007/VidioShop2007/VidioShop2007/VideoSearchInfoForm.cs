using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace VidioShop2007
{
    public partial class VideoSearchInfoForm : Form
    {
        VideoSearchDao dao;
        public VideoSearchInfoForm()
        {
            InitializeComponent();
        }

        private void VideoSearchInfoForm_Load(object sender, EventArgs e)
        {

            ListViewUpdate();
            
        }

        public void ListViewUpdate()
        {
            DataSet ds;
            dao = new VideoSearchDao();
            ds = dao.GetAllVideo();

            ListViewItem lvi;

            foreach (DataRow r in ds.Tables["GetAllVideo"].Rows)
            {
                lvi = new ListViewItem(r["video_no"].ToString());
                lvi.SubItems.Add(r["video_name"].ToString());
                lvi.SubItems.Add(r["video_cost"].ToString());
                this.lvVideoList.Items.Add(lvi);
            }
        }

        private void lvVideoList_SelectedIndexChanged(object sender, EventArgs e)
        {//리스트 선택시 데이터의 내용을 보여줌
            DataSet ds;
            string currNum = this.lvVideoList.FocusedItem.Text.Trim();

            ds = dao.GetVideo(currNum);

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            
            this.tbVcode.Text = dr["video_no"].ToString();
            this.tbVtitle.Text = dr["video_name"].ToString();
            this.tbVclass.Text = dr["video_class"].ToString();
            this.tbVact.Text = dr["video_act"].ToString();
            this.tbVdirect.Text = dr["video_direct"].ToString();
            this.tbVage.Text = dr["video_age"].ToString();
            this.tbVcost.Text = dr["video_cost"].ToString();

        }

        private void btnModify_Click(object sender, EventArgs e)
        {//수정 버튼 클릭시            
            this.btnOk.Visible = false;
            this.btnOK2.Visible = true;

            this.tbVcode.ReadOnly = true;
            this.tbVtitle.ReadOnly = false;
            this.tbVclass.ReadOnly = false;
            this.tbVact.ReadOnly = false;
            this.tbVdirect.ReadOnly = false;
            this.tbVage.ReadOnly = false;
            this.tbVcost.ReadOnly = false;

            this.btnModify.Visible = false;

        }

        private void btnOK2_Click(object sender, EventArgs e)
        {//수정 후 OK2 버튼 클릭시

            bool isL = false;

            string video_no = this.tbVcode.Text;
            string video_name = this.tbVtitle.Text;
            string video_class = this.tbVclass.Text;
            string video_act = this.tbVact.Text;
            string video_direct = this.tbVdirect.Text;
            string video_age = this.tbVage.Text;
            string video_cost = this.tbVcost.Text;

            if (string.IsNullOrEmpty(video_no) ||
                string.IsNullOrEmpty(video_name) ||
                string.IsNullOrEmpty(video_class) ||
                string.IsNullOrEmpty(video_act) ||
                string.IsNullOrEmpty(video_direct) ||
                string.IsNullOrEmpty(video_age) ||
                string.IsNullOrEmpty(video_cost))
            {
                MessageBox.Show("입력사항을 모두 기입하여 주세요", "입력오류");
                return;
            }

            isL = dao.UpdateVideo(video_no, video_name, video_act, video_direct, video_age, video_class, video_cost);

            if (isL)
            {
                MessageBox.Show(video_name + "인 비디오 정보 수정 완료");

                this.btnOk.Visible = true;
                this.btnOK2.Visible = false;
                this.btnModify.Visible = true;


                this.tbVcode.Text = "";
                this.tbVtitle.Text = "";
                this.tbVclass.Text = "";
                this.tbVact.Text = "";
                this.tbVdirect.Text = "";
                this.tbVage.Text = "";
                this.tbVcost.Text = "";

                this.tbVcode.ReadOnly = true;
                this.tbVtitle.ReadOnly = true;
                this.tbVclass.ReadOnly = true;
                this.tbVact.ReadOnly = true;
                this.tbVdirect.ReadOnly = true;
                this.tbVage.ReadOnly = true;
                this.tbVcost.ReadOnly = true;

                this.lvVideoList.Items.Clear();

                ListViewUpdate();
            }
            else
            {
                MessageBox.Show(video_name + "인 비디오 정보가 수정되지 않았습니다", "비디오 정보 수정 오류");
                return;
            }

        }


        

        private void btnInsert_Click_1(object sender, EventArgs e)
        {// 삽입 버튼을 클릭시
            this.tbVcode.Text = "자동부여";
            this.tbVtitle.Text = "";
            this.tbVclass.Text = "";
            this.tbVact.Text = "";
            this.tbVdirect.Text = "";
            this.tbVage.Text = "";
            this.tbVcost.Text = "";
                        
            this.tbVtitle.ReadOnly = false;
            this.tbVclass.ReadOnly = false;
            this.tbVact.ReadOnly = false;
            this.tbVdirect.ReadOnly = false;
            this.tbVage.ReadOnly = false;
            this.tbVcost.ReadOnly = false;

            this.tbVtitle.Focus();
            this.btnInsert.Visible = false;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {//삽입 작업 후 OK버튼 눌렀을 때


            bool isL = false;

            string video_no = this.tbVcode.Text;
            string video_name = this.tbVtitle.Text;
            string video_class = this.tbVclass.Text;
            string video_act = this.tbVact.Text;
            string video_direct = this.tbVdirect.Text;
            string video_age = this.tbVage.Text;
            string video_cost = this.tbVcost.Text;

            if (string.IsNullOrEmpty(video_no) ||
                string.IsNullOrEmpty(video_name) ||
                string.IsNullOrEmpty(video_class) ||
                string.IsNullOrEmpty(video_act) ||
                string.IsNullOrEmpty(video_direct) ||
                string.IsNullOrEmpty(video_age) ||
                string.IsNullOrEmpty(video_cost))
            {
                MessageBox.Show("입력사항을 모두 기입하여 주세요", "입력오류");
                return;
            }

            isL = dao.InsertViedo(video_name, video_act, video_direct, video_age, video_class, video_cost);

            if (isL)
            {
                MessageBox.Show(video_name + "인 비디오 정보 입력 완료");

                this.tbVcode.Text = "";
                this.tbVtitle.Text = "";
                this.tbVclass.Text = "";
                this.tbVact.Text = "";
                this.tbVdirect.Text = "";
                this.tbVage.Text = "";
                this.tbVcost.Text = "";

                this.tbVcode.ReadOnly = true;
                this.tbVtitle.ReadOnly = true;
                this.tbVclass.ReadOnly = true;
                this.tbVact.ReadOnly = true;
                this.tbVdirect.ReadOnly = true;
                this.tbVage.ReadOnly = true;
                this.tbVcost.ReadOnly = true;

                this.btnInsert.Show();
                this.lvVideoList.Items.Clear();

                ListViewUpdate();
            }
            else
            {
                MessageBox.Show(video_name + "인 비디오 정보가 입력되지 않았습니다", "비디오 정보 입력 오류");
                return;
            } 

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {//검색버튼
            DataSet ds;
            string video_no = this.tbSearchNo.Text;
            string video_name = this.tbSearchName.Text;

            if (string.IsNullOrEmpty(video_no) && string.IsNullOrEmpty(video_name))
            {
                MessageBox.Show("비디오 번호나 비디오 이름을 입력하세요", "오류");
                return;
            }

            ds = dao.GetVideoS(video_no, video_name);

            this.lvVideoList.Items.Clear();

            ListViewItem lvi;

            foreach (DataRow r in ds.Tables["GetVideoS"].Rows)
            {
                lvi = new ListViewItem(r["video_no"].ToString());
                lvi.SubItems.Add(r["video_name"].ToString());
                lvi.SubItems.Add(r["video_cost"].ToString()); 
                this.lvVideoList.Items.Add(lvi);
            }

            this.tbSearchNo.Text="";
            this.tbSearchName.Text="";


           
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        { // 리셋
            this.lvVideoList.Items.Clear();
            ListViewUpdate();

        }
      
    }
}