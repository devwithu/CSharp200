using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VidioShop2007
{
    public partial class VLendForm : Form
    {
        VLendDao vdao;
        public VLendForm()
        {
            InitializeComponent();
        }

        private void btnVSearch_Click(object sender, EventArgs e)
        {
            string VNum=this.txtVNoSearch.Text.Trim();
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(VNum)) {
                MessageBox.Show("숫자를 입력하세요");
                return;
            }

            try
            {
                ds = vdao.GetFindVideo(VNum);
            }
            catch (NotFoundException)
            {
                MessageBox.Show(VNum + "번의 비디오는 등록되어있지 않습니다","검색오류");
                return;
            }


            DataTable dt = ds.Tables["GetFindVideo"];
            DataRow dr = dt.Rows[0];
            this.txtVNo.Text = dr["video_no"].ToString();
            this.txtTitle.Text=dr["video_name"].ToString();
            this.txtActor.Text = dr["video_act"].ToString();
            this.txtDirector.Text = dr["video_direct"].ToString();
            this.txtGrade.Text = dr["video_age"].ToString();
            this.txtGenre.Text = dr["video_class"].ToString();
            this.txtPrice.Text = dr["video_cost"].ToString();

            
        }

        private void VLendForm_Load(object sender, EventArgs e)
        {
            vdao = new VLendDao();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllLendVideoList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioCard_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPoint.Visible = false;
            this.label11.Visible = false;
            this.label13.Visible = true;
            this.checkUsePoint.Visible = false;
        }

        private void radioCash_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPoint.Visible = true;
            this.label11.Visible = true;
            this.label13.Visible = false;
            this.checkUsePoint.Visible = true; ;
        }

        private void btnLendOk_Click(object sender, EventArgs e)
        {            
            if (this.checkUsePoint.Checked && this.radioCash.Checked)
            {
                string video_no = this.txtVNoSearch.Text;
                string mem_no = this.txtMSearch.Text;
                string pay_way = this.radioCash.Text;
                
                DateTime lend_date = DateTime.Now;
                DateTime return_date = DateTime.Now.AddDays(5);
                int amount = 0;
                int point = 0;
                try{
                    amount=int.Parse(this.txtAmount.Text);
                    point = int.Parse(this.txtPoint.Text);
                }
                catch  {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }
                //값입력 예외
                if (string.IsNullOrEmpty(video_no) ||
                    string.IsNullOrEmpty(mem_no))
                {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }             
                
                //결제금액이 포인트보다 클때
                if(amount > point)
                {
                    amount = amount - point;
                    point = 0;
                }
                //포인트가 결제금액보다 클때
                else if(point > amount)
                {
                    point = point - amount;
                    amount = 0;                    
                }
                //포인트와 결제금액이 같을때
                else
                {
                    amount = 0;
                    point = 0;
                }

                bool isl = vdao.PointUseInsertLend(video_no, mem_no, lend_date, return_date, amount, point, pay_way);

                if (isl)
                {
                    MessageBox.Show(mem_no + "번 님의 대여가 완료되었습니다");
                    ResetAll();
                    AllLendVideoList();
                }
                else
                {
                    MessageBox.Show("대여실패! 시스템관리자에게 문의하세요");
                }
            }
            else if (this.radioCash.Checked)
            {              
                string video_no = this.txtVNoSearch.Text;
                string mem_no = this.txtMSearch.Text;
                string pay_way = this.radioCash.Text;

                
                DateTime lend_date = DateTime.Now;
                DateTime return_date = DateTime.Now.AddDays(5);

                int amount = 0;
   
                try
                {
                    amount = int.Parse(this.txtAmount.Text);

                }
                catch
                {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }



                int pointAdd = (amount / 10);

                if (string.IsNullOrEmpty(video_no) ||
                    string.IsNullOrEmpty(mem_no))
                {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }

                bool isl = vdao.NoPointInsertLend(video_no, mem_no, lend_date, return_date, amount, pointAdd, pay_way);

                if (isl)
                {
                    MessageBox.Show(mem_no + "번 님의 대여가 완료되었습니다");
                    ResetAll();
                    AllLendVideoList();
                }
                else
                {
                    MessageBox.Show("대여실패! 시스템관리자에게 문의하세요");
                }
            }
            else if (this.radioCard.Checked)
            {
                string video_no = this.txtVNoSearch.Text;
                string mem_no = this.txtMSearch.Text;
                string pay_way = this.radioCard.Text;
                int amount = 0;

                try
                {
                    amount = int.Parse(this.txtAmount.Text);

                }
                catch
                {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }          

                DateTime lend_date = DateTime.Now;
                DateTime return_date = DateTime.Now.AddDays(5);
                                

                if (string.IsNullOrEmpty(video_no) ||
                    string.IsNullOrEmpty(mem_no))
                {
                    MessageBox.Show("항목을 모두 입력하세요", "대여오류");
                    return;
                }

                bool isl = vdao.UseCardInsertLend(video_no, mem_no, lend_date, return_date, amount, pay_way);

                if (isl)
                {
                    MessageBox.Show(mem_no + "번 님의 대여가 완료되었습니다");
                    ResetAll();
                    AllLendVideoList();
                }
                else
                {
                    MessageBox.Show("대여실패! 시스템관리자에게 문의하세요");
                }
            }
            else
            {
                MessageBox.Show("결제수단을 선택하여 주세요", "결제오류");
            }
        }//

        public void ResetAll()
        {
            this.txtVNoSearch.Text = "";
            this.txtVNo.Text = "";
            this.txtTitle.Text = "";
            this.txtActor.Text = "";
            this.txtDirector.Text = "";
            this.txtGrade.Text = "";
            this.txtGenre.Text = "";
            this.txtPrice.Text = "";
            this.txtAmount.Text = "";
            this.checkUsePoint.Checked = false;
        }//


        public void AllLendVideoList()
        {
            string MNum = this.txtMSearch.Text.Trim();

            if (string.IsNullOrEmpty(MNum))
            {
                MessageBox.Show("고객 ID를 입력하세요");
                return;
            }

            bool isMember = vdao.GetFindMember(MNum);
            bool isLendMember = false;            
         
            if(isMember)
            {
                isLendMember = vdao.GetFindLendMember(MNum);
                if (isLendMember)
                {
                    DataSet ds = new DataSet();
                    ds = vdao.GetFindLendMember2(MNum);

                    ListViewItem lvi;
                    this.lvLend.Items.Clear();

                    foreach (DataRow r in ds.Tables["GetFindVideo"].Rows)
                    {
                        lvi = new ListViewItem(r["video_no"].ToString());
                        lvi.SubItems.Add(r["video_name"].ToString());
                        lvi.SubItems.Add(r["lend_date"].ToString());
                        lvi.SubItems.Add(r["return_date"].ToString());
                        this.lvLend.Items.Add(lvi);
                    }

                    DataTable dt = ds.Tables["GetFindVideo"];
                    DataRow dr = dt.Rows[0];
                    this.txtPoint.Text = dr["mem_point"].ToString();
                }
                else
                {
                    this.lvLend.Items.Clear();
                    this.txtPoint.Text = "";
                    MessageBox.Show("대여한 비디오 목록이 없습니다");
                    return;
                }
            }
            else
            {
                DialogResult result;

                result = MessageBox.Show("찾는 회원이 없습니다\n등록 하시겠습니까?", "오류", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AddMemberForm amf = new AddMemberForm();
                    amf.ShowDialog();                    
                }
                return;                
            }             
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.label2.Visible = true;
            this.txtMSearch.Visible = true;
            this.button2.Visible = true;
            this.btnLendOk.Visible = true;
            this.label1.Visible = true;
            this.txtVNoSearch.Visible = true;
            this.btnVSearch.Visible = true;

            this.btnReturnOK.Visible = false;
            this.label14.Visible = false;
            this.button1.Visible = false;
            this.textBox1.Visible = false;
            this.label15.Visible = false;
            this.textBox2.Visible = false;
        }//

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.label2.Visible = false;
            this.txtMSearch.Visible = false;
            this.button2.Visible = false;
            this.btnLendOk.Visible = false;
            this.label1.Visible = false;
            this.txtVNoSearch.Visible = false;
            this.btnVSearch.Visible = false;

            this.btnReturnOK.Visible = true;
            this.label14.Visible = true;
            this.button1.Visible = true;
            this.textBox1.Visible = true;
            this.label15.Visible = true;
            this.textBox2.Visible = true;
            this.textBox2.Text = DateTime.Now.ToString();
            this.lvLend.Items.Clear();
        }//

        

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
                        
            string mem_no = this.textBox1.Text;
            if (string.IsNullOrEmpty(mem_no))
            {
                MessageBox.Show("고객번호를 입력하세요");
                return;
            }

            try
            {
                ds = vdao.ReturnLendVideoSearch(mem_no);
            }
            catch (NotFoundException)
            {
                MessageBox.Show("대여한 비디오가 없습니다");
                return;
            }

            ListViewItem lvi;
            this.lvLend.Items.Clear();

            foreach (DataRow r in ds.Tables["GetFindVideo"].Rows)
            {
                lvi = new ListViewItem(r["video_no"].ToString());
                lvi.SubItems.Add(r["video_name"].ToString());
                lvi.SubItems.Add(r["lend_date"].ToString());
                lvi.SubItems.Add(r["return_date"].ToString());
                this.lvLend.Items.Add(lvi);
            }

            DataTable dt = ds.Tables["GetFindVideo"];
            DataRow dr = dt.Rows[0];

            this.txtVNo.Text = dr["video_no"].ToString();
            this.txtTitle.Text = dr["video_name"].ToString();
            this.txtActor.Text = dr["video_class"].ToString();
            this.txtDirector.Text = dr["video_act"].ToString();
            this.txtGrade.Text = dr["video_direct"].ToString();
            this.txtGenre.Text = dr["video_age"].ToString();
            this.txtPrice.Text = dr["video_cost"].ToString();
        }

        private void btnReturnOK_Click(object sender, EventArgs e)
        {
            string video_no = "";
            string mem_no = "";
            try {
                video_no = this.lvLend.FocusedItem.Text.Trim();
                mem_no = this.textBox1.Text.Trim();
            }
            catch {
                MessageBox.Show("비디오 번호를 선택하세요");
                return;
            }

            if (video_no==null || mem_no==null 
                || string.IsNullOrEmpty(mem_no) || string.IsNullOrEmpty(video_no))
            {
                MessageBox.Show("고객번호를 입력하세요");
                return;
            }
      
            bool isl = vdao.ReturnVideo(video_no, mem_no);
  
            if (isl)
            {
                MessageBox.Show("반납처리 완료");
           
                this.panel1.Visible = true;
                this.label2.Visible = true;
                this.txtMSearch.Visible = true;
                this.button2.Visible = true;
                this.btnLendOk.Visible = true;
                this.label1.Visible = true;
                this.txtVNoSearch.Visible = true;
                this.btnVSearch.Visible = true;
             
                this.btnReturnOK.Visible = false;
                this.label14.Visible = false;
                this.button1.Visible = false;
                this.textBox1.Visible = false;
                this.label15.Visible = false;
                this.textBox2.Visible = false;

                this.radioButton1.Checked = true;
                ResetAll();
                lvLend.Items.Clear();
            
            }
            else
            {
                MessageBox.Show("반납처리 실패! 관리자에게 문의하세요");
            }

        }

        private void tabVLendForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabVLendForm.SelectedTab == this.tabLendList)
            {
                DataSet ds = new DataSet();
                ds = vdao.GetAllLendVideo();
                this.dataGridView1.DataMember = "GetAllLendVideo";
                this.dataGridView1.DataSource = ds;
                this.dataGridView1.Update();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string pid="";
            int cIndex = this.dataGridView1.CurrentRow.Index;
                                    
            pid = this.dataGridView1[0, cIndex].Value.ToString();

            ds = vdao.getPaywayPayAmount(pid);

            DataTable dt = ds.Tables["GetFindVideo"];
            DataRow dr = dt.Rows[0];
            this.txtPayWay.Text = dr["pay_way"].ToString();
            this.txtPayAmount.Text = dr["pay_amount"].ToString();            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}