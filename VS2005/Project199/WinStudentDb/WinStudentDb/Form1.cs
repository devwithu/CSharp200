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
//����ڽ��� �����.���� ��ư�� ������ ����ڽ��� ���δ�.
private void Form1_Load(object sender, EventArgs e){
    this.gbShowAll.Visible = false;
    this.gbInsert.Visible = false;
    this.gbExit.Visible = false;
}
//��� �л����̱� ����ڽ��� ���δ�.
private void rdShowAll_CheckedChanged(
    object sender, EventArgs e){
    if (rdShowAll.Checked){
        this.gbShowAll.Visible = true;
    }
    else{
        this.gbShowAll.Visible = false;
    }
}
//���, ������ ���� ����ڽ��� ���δ�.
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
//Ż��, ������ ���� ����ڽ��� ���δ�.
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
//�����ͱ׸��� �信�� �ٸ� �л��� �����ϸ� 
//����� �����͸� �ؽ�Ʈ�ڽ��� ���δ�.
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
//Ż����� ��� �л� ���̱�
private void btnShowAll_Click(object sender, EventArgs e){
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//����Ѵ�.
private void btnInsert_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    string name = this.txtName.Text;
    string phone = this.txtPhone.Text;
    string address = this.txtAddress.Text;
    if (string.IsNullOrEmpty(id) ||
        string.IsNullOrEmpty(name) ||
        string.IsNullOrEmpty(phone) ||
        string.IsNullOrEmpty(address)){
        MessageBox.Show("������ �߰��� �� �����ϴ�.");
        return;
    }
    int count = 0;
    try{
        count = studentTableAdapter.InsertQuery(
            id, name, phone, address);
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        MessageBox.Show("���������� �л��� �߰� �߽��ϴ�.");
    }
    catch {
        MessageBox.Show("�л��߰��� �����߽��ϴ�.");
    }
}
//���̵�� �л��� ã�´�.
private void btnSearch_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id) ){
        MessageBox.Show("������ �߰��� �� �����ϴ�.");
        return;
    }
    try{
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        int count = 
      studentTableAdapter.GetDataByStudentId(id).Rows.Count;
        if(count<=0){
            throw new Exception("ã�� �л��� �����ϴ�.");
        }
    }
    catch(Exception ee){
        MessageBox.Show(ee.Message);
    }
}
//�л������� �����Ѵ�.
private void btnUpdate_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    string name = this.txtName.Text;
    string phone = this.txtPhone.Text;
    string address = this.txtAddress.Text;
    if (string.IsNullOrEmpty(id) ||
        string.IsNullOrEmpty(name) ||
        string.IsNullOrEmpty(phone) ||
        string.IsNullOrEmpty(address)){
        MessageBox.Show("������ �� �� �����ϴ�.");
        return;
    }
    int count = 0;
    try{
        count = studentTableAdapter.UpdateQuery(
            name, phone, address,id);
        studentTableAdapter.FillByStudentId(
            studentDataSet.Student, id);
        MessageBox.Show("���������� �л������� ���� �߽��ϴ�.");
    }
    catch{
        MessageBox.Show("�л������� ���濡 �����߽��ϴ�.");
    }
}
//�̸����� ã�´�. �̸� �� �� ���ڸ� �־ ã�� �� �ִ�.
private void btnLikeName_Click(object sender, EventArgs e){
    string name = this.txtName.Text;
    if (string.IsNullOrEmpty(name)){
        MessageBox.Show("������ �߰��� �� �����ϴ�.");
        return;
    }
    try{
        studentTableAdapter.FillByNameLike(
            studentDataSet.Student, "%"+name+"%");
        int count = studentTableAdapter.GetDataByNameLike(
                    "%" + name + "%").Rows.Count;
        if (count <= 0){
            throw new Exception("ã�� �л��� �����ϴ�.");
        }
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
}
//Ż���Ų��. DB���� �����ְ� chk='Y'�� ǥ���Ѵ�.
private void btnExitId_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id)){
        MessageBox.Show("������ �߰��� �� �����ϴ�.");
        return;
    }
    try{
        studentTableAdapter.ExitId(id);
        int count = 
        studentTableAdapter.GetDataByExitId(id).Rows.Count;
        if (count <= 0){
            throw new Exception("Ż�� �����߽��ϴ�.");
        }
        MessageBox.Show("���������� Ż���߽��ϴ�.");
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//�л��� �����Ѵ�. DB�� ���� �ʴ´�.
private void btnDelInfo_Click(object sender, EventArgs e){
    string id = this.txtId.Text;
    if (string.IsNullOrEmpty(id)){
        MessageBox.Show("������ �߰��� �� �����ϴ�.");
        return;
    }
    try{
        studentTableAdapter.DeleteQuery(id);
        int count = 
        studentTableAdapter.GetDataByStudentId(id).Rows.Count;
        if (count > 0){
            throw new Exception("������ �����߽��ϴ�.");
        }
        MessageBox.Show("���������� �����Ǿ����ϴ�.");
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
    this.studentTableAdapter.Fill(
        this.studentDataSet.Student);
}
//��� �л��� ���δ�.
private void btnExWith_Click(object sender, EventArgs e){
    this.studentTableAdapter.FillByAll(
        this.studentDataSet.Student);
}
    }
}

