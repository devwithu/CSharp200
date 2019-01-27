using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace StudentLinq{
    public partial class Form1 : Form{
public Form1(){
    InitializeComponent();
}
//linq 사용을 위한 컨텍스트 연결
StudentDataContext stdb = new StudentDataContext();
//SELECT * FROM STUDENT
private void btnShowAll_Click(object sender, EventArgs e){
    IEnumerable<Student> sts= (from c in stdb.Student
                         select c).ToList();
    this.dataGridView1.DataSource = sts;
}
//SELECT * FROM STUDENT
private void btnShowAll2_Click(object sender, EventArgs e){
    List<Student> sts = (from c in stdb.Student
                         select c).ToList();
    this.dataGridView1.DataSource = sts;
}
//SELECT * FROM STUDENT
private void btnShowAll3_Click(object sender, EventArgs e){
    //VARIABLE  변수
    var sts = (from c in stdb.Student
                         select c).ToList();
    this.dataGridView1.DataSource = sts;
}
private void Form1_Load(object sender, EventArgs e){
    try{
        //SELECT STUDENT_ID FROM STUDENT
        List<string> sts = (from c in stdb.Student
                             select c.Student_ID).ToList();
        //STUDENT_ID를 콤보박스에 대입
        this.comboBox1.DataSource = sts;
    }
    catch (Exception ee){

        MessageBox.Show(ee.Message);
    }
}
//SELECT * FROM STUDENT WHERE STUDENT_ID=@STUDENT_ID
//결과가 1개의 ROW
private void comboBox1_SelectedIndexChanged(
                        object sender, EventArgs e){
    try{
        string id = this.comboBox1.SelectedItem as string;
        //1개의 ROW에 해당하는 개체-->Single<Student>()
        Student st = (from c in stdb.Student
                      where c.Student_ID == id.Trim()
                      select c).Single<Student>();
        //각 텍스트박스에 해당 값 대입
        this.txtName.Text = st.Student_Name;
        this.txtPhone.Text = st.Student_Phone;
        this.txtAddress.Text = st.Student_Address;
        this.txtIndate.Text = st.Student_InDate.ToString();
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
}
//SELECT * FROM STUDENT WHERE STUDENT_ID=@STUDENT_ID
//그리드뷰에 대입
private void btnId_Click(object sender, EventArgs e){
    var sts = (from c in stdb.Student
               where c.Student_ID == this.txtIdSearch.Text.Trim()
               select c).ToList();
    this.dataGridView1.DataSource = sts;
}
//SELECT STUDENT_NAME FROM STUDENT
//WHERE STUDENT_ID=@STUDENT_ID
private void btnName_Click(object sender, EventArgs e){
    try{
        this.txtNameResult.Text = (from c in stdb.Student
              where c.Student_ID == this.txtIdSearch.Text
              select c.Student_Name).Single().ToString();
    }
    catch (Exception ee){
        MessageBox.Show(ee.Message);
    }
}//
    }
}