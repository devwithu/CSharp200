using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace WinStudentDb{
    public partial class Form1 : Form{
public Form1(){
    InitializeComponent();
}
//구룹박스를 감춘다.라디오 버튼을 누르면 구룹박스가 보인다.
private void Form1_Load(object sender, EventArgs e){
    this.gbShowAll.Visible = false;
    this.gbInsert.Visible = false;
    this.gbExit.Visible = false;
}
//모든 학생보이기 구룹박스를 보인다.
private void rdShowAll_CheckedChanged(
    object sender, EventArgs e){
    if (rdShowAll.Checked){
        this.gbShowAll.Visible = true;
    }
    else{
        this.gbShowAll.Visible = false;
    }
}
//등록, 변경을 위한 구룹박스를 보인다.
private void rdInsert_CheckedChanged(
    object sender, EventArgs e){
    if (rdInsert.Checked){
        this.gbInsert.Visible = true;
        this.gbInsert.Location = new Point(21, 101);
    }
    else{
        this.gbInsert.Visible = false;
    }
}
//탈퇴, 삭제를 위한 구룹박스를 보인다.
private void rdExit_CheckedChanged(
           object sender, EventArgs e) {
    if (rdExit.Checked) {
        this.gbExit.Visible = true;
        this.gbExit.Location = new Point(21, 101);
    }
    else{
        this.gbExit.Visible = false;
    }
}
//데이터그리드 뷰에서 다른 학생을 선택하면 
//변경된 데이터를 텍스트박스에 보인다.
private void dataGridView1_SelectionChanged(
object sender, EventArgs e){
try {
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
}
catch { }
}
//탈퇴안한 모든 학생 보이기
private void btnShowAll_Click(object sender, EventArgs e){
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//등록한다.
private void btnInsert_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    string name = this.txtName.Text;
    string phone = this.txtPhone.Text;
    string address = this.txtAddress.Text;
    if (string.IsNullOrEmpty(id) ||
        string.IsNullOrEmpty(name) ||
        string.IsNullOrEmpty(phone) ||
        string.IsNullOrEmpty(address)){
        MessageBox.Show("공백이 추가될 수 없습니다.");
        return;
    }
    int count = 0;
    try{
        count = studentTableAdapter.InsertQuery(
            id, name, phone, address);
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        MessageBox.Show("성공적으로 학생을 추가 했습니다.");
    }
    catch {
        MessageBox.Show("학생추가에 실패했습니다.");
    }
}
//아이디로 학생을 찾는다.
private void btnSearch_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id) ){
        MessageBox.Show("공백이 추가될 수 없습니다.");
        return;
    }
    try{
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        int count = 
      studentTableAdapter.GetDataByStudentId(id).Rows.Count;
        if(count<=0){
            throw new Exception("찾는 학생이 없습니다.");
        }
    }
    catch(Exception ee){
        MessageBox.Show(ee.Message);
    }
}
//학생정보를 변경한다.
private void btnUpdate_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    string name = this.txtName.Text;
    string phone = this.txtPhone.Text;
    string address = this.txtAddress.Text;
    if (string.IsNullOrEmpty(id) ||
        string.IsNullOrEmpty(name) ||
        string.IsNullOrEmpty(phone) ||
        string.IsNullOrEmpty(address)){
        MessageBox.Show("공백이 올 수 없습니다.");
        return;
    }
    int count = 0;
    try{
        count = studentTableAdapter.UpdateQuery(
            name, phone, address,id);
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        MessageBox.Show("성공적으로 학생정보를 변경 했습니다.");
    }
    catch{
        MessageBox.Show("학생정보를 변경에 실패했습니다.");
    }
}
//이름으로 찾는다. 이름 중 한 글자를 넣어도 찾을 수 있다.
private void btnLikeName_Click(object sender, EventArgs e){
    string name = this.txtName.Text;
    if (string.IsNullOrEmpty(name)){
        MessageBox.Show("공백이 추가될 수 없습니다.");
        return;
    }
    try{
        studentTableAdapter.FillByNameLike(
            studentDataSet.Student, "%"+name+"%");
        int count = studentTableAdapter.GetDataByNameLike(
                    "%" + name + "%").Rows.Count;
        if (count <= 0){
            throw new Exception("찾는 학생이 없습니다.");
        }
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
}
//탈퇴시킨다. DB에는 남아있고 chk='Y'로 표시한다.
private void btnExitId_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id)){
        MessageBox.Show("공백이 추가될 수 없습니다.");
        return;
    }
    try{
        studentTableAdapter.ExitId(id);
        int count = 
        studentTableAdapter.GetDataByExitId(id).Rows.Count;
        if (count <= 0){
            throw new Exception("탈퇴에 실패했습니다.");
        }
        MessageBox.Show("성공적으로 탈퇴했습니다.");
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//학생을 삭제한다. DB에 남지 않는다.
private void btnDelInfo_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id)){
        MessageBox.Show("공백이 추가될 수 없습니다.");
        return;
    }
    try{
        studentTableAdapter.DeleteQuery(id);
        int count = 
        studentTableAdapter.GetDataByStudentId(id).Rows.Count;
        if (count > 0){
            throw new Exception("삭제에 실패했습니다.");
        }
        MessageBox.Show("성공적으로 삭제되었습니다.");
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//모든 학생을 보인다.
private void btnExWith_Click(object sender, EventArgs e){
    this.studentTableAdapter.FillByAll(
        this.studentDataSet.Student);
}
    }
}

