using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace StudentDbLinq
{
    public partial class Form1 : Form
    {
        //Linq사용을 위한 컨텍스트를 생성한다.
        StudentLinqDataContext stdb = new StudentLinqDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        //구룹박스를 감춘다.라디오 버튼을 누르면 구룹박스가 보인다.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.gbShowAll.Visible = false;
            this.gbInsert.Visible = false;
            this.gbExit.Visible = false;
        }
        //모든 학생보이기 구룹박스를 보인다.
        private void rdShowAll_CheckedChanged(
            object sender, EventArgs e)
        {
            if (rdShowAll.Checked)
            {
                this.gbShowAll.Visible = true;
            }
            else
            {
                this.gbShowAll.Visible = false;
            }
        }
        //등록, 변경을 위한 구룹박스를 보인다.
        private void rdInsert_CheckedChanged(
            object sender, EventArgs e)
        {
            if (rdInsert.Checked)
            {
                this.gbInsert.Visible = true;
                this.gbInsert.Location = new Point(21, 101);
            }
            else
            {
                this.gbInsert.Visible = false;
            }
        }
        //탈퇴, 삭제를 위한 구룹박스를 보인다.
        private void rdExit_CheckedChanged(
                   object sender, EventArgs e)
        {
            if (rdExit.Checked)
            {
                this.gbExit.Visible = true;
                this.gbExit.Location = new Point(21, 101);
            }
            else
            {
                this.gbExit.Visible = false;
            }
        }
        //데이터그리드 뷰에서 다른 학생을 선택하면 
        //변경된 데이터를 텍스트박스에 보인다.
        private void dataGridView1_SelectionChanged(
        object sender, EventArgs e)
        {
            try
            {
                this.txtId.Text = this.dataGridView1[0,
                this.dataGridView1.SelectedCells[0].RowIndex].Value as string;
                this.txtName.Text = this.dataGridView1[1,
                this.dataGridView1.SelectedCells[0].RowIndex].Value as string;
                this.txtPhone.Text = this.dataGridView1[2,
                this.dataGridView1.SelectedCells[0].RowIndex].Value as string;
                this.txtAddress.Text = this.dataGridView1[3,
                this.dataGridView1.SelectedCells[0].RowIndex].Value as string;
                this.txtExitId.Text = this.dataGridView1[0,
                this.dataGridView1.SelectedCells[0].RowIndex].Value as string;
                this.studentBindingSource.Position = 
                    this.dataGridView1.SelectedCells[0].RowIndex;
            }
            catch { }
        }
        //탈퇴안한 모든 학생 보이기
        private void btnShowAll_Click(object sender, EventArgs e)
        {

           var sts= (from c in stdb.Student
                                 where c.Student_chk=='N'
                                 select c).ToList();
            this.studentBindingSource.DataSource = sts;
            this.dataGridView1.DataSource = this.studentBindingSource.DataSource;
            this.bindingNavigator1.BindingSource = this.studentBindingSource;
        }
        public  bool InsertStudent(string id, string name, string phone, string address)
        {
            //개체 형식으로 만든다.
              var stu = new  Student
                {
                    Student_ID=id,
                    Student_Name= name,
                    Student_Phone = phone,
                    Student_Address=address,
                    Student_chk='N',
                    Student_InDate=DateTime.Now
                };
            stdb.Student.InsertOnSubmit(stu);//insert 실행
            try
            {
                //System.Data.Linq.ConflictMode
                stdb.SubmitChanges(ConflictMode.FailOnFirstConflict);
                return true;
            }
            catch
            {
                stdb.Refresh(System.Data.Linq.RefreshMode.KeepChanges, stu);
                return false;
            }
        }
        //등록한다.
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            string name = this.txtName.Text;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(address))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            try
            {
                InsertStudent(id, name, phone, address);
                MessageBox.Show("성공적으로 학생을 추가 했습니다.");
                btnSearch_Click(sender,e);//추가한 학생 보이기
            }
            catch
            {
                MessageBox.Show("학생추가에 실패했습니다.");
            }
        }
        //아이디로 학생을 찾는다.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            try
            {
                List<Student> sts = (from c in stdb.Student
                           where c.Student_ID == this.txtId.Text.Trim()
                           && c.Student_chk=='N'
                           select c).ToList<Student>();

                //찾는 학생이 없다면
                int count = sts.Count;
                if (count <= 0)
                {
                    throw new Exception("찾는 학생이 없습니다.");
                }
                this.studentBindingSource.DataSource = sts;
                this.dataGridView1.DataSource = this.studentBindingSource.DataSource;
                this.bindingNavigator1.BindingSource = this.studentBindingSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }//탈퇴한 학생
        private void SearchExitId(string id)
        {
            try
            {
                List<Student> sts = (from c in stdb.Student
                                     where c.Student_ID == this.txtId.Text.Trim()
                                     && c.Student_chk == 'Y'
                                     select c).ToList<Student>();
                //찾는 학생이 없다면
                int count = sts.Count;
                if (count <= 0)
                {
                    throw new Exception("찾는 학생이 없습니다.");
                }
                this.studentBindingSource.DataSource = sts;
                this.dataGridView1.DataSource = this.studentBindingSource.DataSource;
                this.bindingNavigator1.BindingSource = this.studentBindingSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //학생정보를 변경한다.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            string name = this.txtName.Text;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(address))
            {
                MessageBox.Show("공백이 올 수 없습니다.");
                return;
            }
            try
            {
                var result = stdb.Student.Single(o => o.Student_ID == id);
                result.Student_Name = name;
                result.Student_Phone = phone;
                result.Student_Address = address;
                result.Student_InDate = DateTime.Now;
                try
                {
                    stdb.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    MessageBox.Show("성공적으로 학생정보를 변경 했습니다.");
                    btnSearch_Click(sender, e);//추가한 학생 보이기
                }
                catch
                {
                    stdb.Refresh(RefreshMode.KeepChanges, result);
                    MessageBox.Show("학생정보를 변경에 실패했습니다.");
                }
                
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //이름으로 찾는다. 이름 중 한 글자를 넣어도 찾을 수 있다.
        private void btnLikeName_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            try
            {
                List<Student> sts = (from c in stdb.Student
                     where c.Student_Name.Contains(this.txtName.Text.Trim())
                     && c.Student_chk == 'N'
                     select c).ToList<Student>();

                //찾는 학생이 없다면
                int count = sts.Count;
                if (count <= 0)
                {
                    throw new Exception("찾는 학생이 없습니다.");
                }
                this.studentBindingSource.DataSource = sts;
                this.dataGridView1.DataSource = this.studentBindingSource.DataSource;
                this.bindingNavigator1.BindingSource = this.studentBindingSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //탈퇴시킨다. DB에는 남아있고 chk='Y'로 표시한다.
        private void btnExitId_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            try
            {
                var result = stdb.Student.Single(o => o.Student_ID == id);
                result.Student_chk = 'Y';
                try
                {
                    stdb.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    MessageBox.Show("성공적으로 탈퇴했습니다.");
                    SearchExitId(id);
                }
                catch
                {
                    stdb.Refresh(RefreshMode.KeepChanges, result);
                    MessageBox.Show("탈퇴에 실패했습니다.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //학생을 삭제한다. DB에 남지 않는다.
        private void btnDelInfo_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("공백이 추가될 수 없습니다.");
                return;
            }
            try
            {
                var result = stdb.Student.Single(rr => rr.Student_ID == id);
                stdb.Student.DeleteOnSubmit(result);
                try
                {
                    stdb.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    MessageBox.Show("성공적으로 삭제되었습니다.");
                    btnShowAll_Click(sender, e);
                }
                catch
                {
                    stdb.Refresh(RefreshMode.KeepChanges, result);
                    MessageBox.Show("삭제에 실패했습니다.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        //모든 학생을 보인다.
        private void btnExWith_Click(object sender, EventArgs e)
        {
            var sts = (from c in stdb.Student
                                 select c).ToList();
            this.studentBindingSource.DataSource = sts;
            this.dataGridView1.DataSource = this.studentBindingSource.DataSource;
            this.bindingNavigator1.BindingSource = this.studentBindingSource;
        }
    }
}
