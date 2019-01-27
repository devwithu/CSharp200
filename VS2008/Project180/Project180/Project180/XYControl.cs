using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using Com.JungBo.Logic;
namespace Project180
{
    public partial class XYControl : UserControl{
private float orginX = 0.0f;
private float orginY=0.0f;
Rectangle rect; //��Ʈ�� ũ��
private float pixH = 100.0f;//max���� ���� �ȼ�
float HeightR = 2.0f;//+y,-y �ΰ�
LivingDateTime bio;
DateTime dt;
Calendar cal;
int lastOfDay;
float steps;
bool isFirst = true;

PointFs physical = new PointFs(Color.Red);
//PointFs emotion = new PointFs(Color.Blue);
//PointFs intelec = new PointFs(Color.Brown);

public XYControl(){
    InitializeComponent();
    rect = this.ClientRectangle;//��Ʈ���� ��Ÿ���� �簢��
    this.orginX = rect.Left + 100.0f;  //����� x����
    this.orginY = rect.Top + (rect.Height) / 2;//����� y����
    this.BackColor = Color.White;//������ �������
    this.Remove();//List�� �ִ� ��� ������ �����ϴ� �޼��� ȣ��
}

//public void DrawX(Graphics g){
//    Pen xPen = new Pen(Color.Brown, 1);//����, �α�1
//    float stX = this.orginX- 50.0f;
//    float stY = this.orginY;
//    float endX = rect.Right-  20.0f;
//    float endY = this.orginY;
//    g.DrawLine(xPen, new PointF(stX, stY),new PointF(endX, endY));
//    g.DrawLine(xPen, new PointF(endX - 10, endY-5),
//        new PointF(endX, endY)); //-->Ȱ����
//    g.DrawLine(xPen, new PointF(endX - 10, endY +5), 
//        new PointF(endX, endY));//-->
//    Pen axisXPen = new Pen(Color.DarkSlateGray, 1);
//    Font axisXFont = new Font("Arial", 9);
//    SolidBrush axisXBrush = new SolidBrush(Color.SteelBlue);

//    g.DrawString("X", axisXFont, axisXBrush, endX - 10, endY + 10);
   
//    xPen.Dispose();
//    axisXBrush.Dispose();
//    axisXFont.Dispose();
//    axisXPen.Dispose();
//    //--------------------Day��� rotate �̿뿹��-------------------
//    GraphicsPath gpY = new GraphicsPath();
//    Matrix rotateMatrix = new Matrix();
//    rotateMatrix.RotateAt(0,new PointF(stX, stY + 100));

//    gpY.AddString("Day", new FontFamily("Arial"),
//        (int)FontStyle.Regular, 10, new PointF(endX-100f, endY+20), 
//        new StringFormat());
//    gpY.Transform(rotateMatrix);
//    g.FillPath(Brushes.Black, gpY);

//    gpY.Dispose();
//    rotateMatrix.Dispose();
//    //----------------------------------------------
//}
//public void DrawY(Graphics g){
//    Pen xPen = new Pen(Color.Brown, 1);
//    float stX = this.orginX;
//    float stY = rect.Top + 50.0f;
//    float endX = this.orginX;
//    float endY = rect.Bottom - 50.0f;
//    g.DrawLine(xPen, new PointF(stX, stY),new PointF(endX, endY));
//    g.DrawLine(xPen, new PointF(endX - 5, stY + 10), 
//        new PointF(endX, stY)); //-->Ȱ����
//    g.DrawLine(xPen, new PointF(endX + 5, stY+10), 
//        new PointF(endX, stY)); //>
//    Pen axisXPen = new Pen(Color.DarkSlateGray, 1);
//    Font axisXFont = new Font("Arial", 9);
//    SolidBrush axisXBrush = new SolidBrush(Color.SteelBlue);
//    g.DrawString("Y", axisXFont, axisXBrush, stX - 20, stY );
//    xPen.Dispose();
//    axisXBrush.Dispose();
//    axisXFont.Dispose();
//    axisXPen.Dispose();
//    //---------------------Amplitude���
//    GraphicsPath gpY = new GraphicsPath();
//    Matrix rotateMatrix = new Matrix();
//    rotateMatrix.RotateAt(-90, new PointF(stX , stY+100));
//    gpY.AddString("Amplitude", new FontFamily("Arial"),
//        (int)FontStyle.Regular, 10,new PointF(endX, 100f),
//        new StringFormat());
//    gpY.Transform(rotateMatrix);
//    g.FillPath(Brushes.Black, gpY);
//    gpY.Dispose();
//    rotateMatrix.Dispose();
//    //-----------------------------------
//}
////���̿����뿡 ���� ǥ��
//public void DrawToDay(Graphics g){
//    Pen xPen = new Pen(Color.Black, 2);
//    bio.SetToDay(dt.Year, dt.Month, dt.Day);//���� ��¥ ����
//    float stX = this.orginX + steps * bio.ToDay.Day;
//    float stY = rect.Top + 100.0f;
//    float endX = this.orginX + steps * bio.ToDay.Day;
//    float endY = rect.Bottom - 100.0f;
//    g.DrawLine(xPen, new PointF(stX, stY), 
//        new PointF(endX, endY));
//    xPen.Dispose();
//}
//������ܿ� ���̿����� ���� ���
//public void DrawNotice(Graphics g, float stX, float stY, 
//    float endX, float endY, Color c, String st){
//    Pen xPen = new Pen(c, 1);
//    Font axisXFont = new Font("Arial", 9);
//    SolidBrush axisXBrush = new SolidBrush(c);
//    g.DrawLine(xPen, new PointF(stX, stY), 
//        new PointF(endX, endY));
//    g.DrawString(st, axisXFont, axisXBrush, endX, endY - 5);
//    axisXFont.Dispose();
//    axisXBrush.Dispose();
//    xPen.Dispose();
//}//
public void DrawPhysical(Graphics g) {
    Pen xPen = new Pen(Color.Red, 1);
    float stX = this.orginX;
    float stY = this.orginY;
    //���̿������� ���� ��¥�� �����Ų��.
    bio.SetToDay(dt.Year, dt.Month, 1);
    bio.PerviousDay();//0
    float xy = stY - pixH * ((float)bio.Physical());//������ǥ
    physical.Add(new PointF(stX, xy));
    for (int i = 1; i <= lastOfDay; i++){
        //���̿������� ���� ��¥�� �����Ų��
        bio.SetToDay(dt.Year, dt.Month, i);
        xy = stY - pixH * ((float)bio.Physical());//����
        physical.Add(new PointF(stX + steps * i, xy));
    }
    physical.Draw(g);//List�� ����� ��� Point�� �����Ѵ�.
    xPen.Dispose();
    //������ܿ� Physical ���� ���
    //float endX = rect.Right - 20.0f;
    //float endY = rect.Top;
    //DrawNotice(g, endX - 100, endY + 50, endX - 90,
    //    endY + 50, Color.Red, "Physical");
   
}
//public void DrawEmotial(Graphics g){
//    Pen xPen = new Pen(Color.Blue, 1);
//    float stX = this.orginX;
//    float stY = this.orginY;
//    bio.SetToDay(dt.Year, dt.Month, 1);
//    bio.PerviousDay();//0
//    float xy = stY - pixH * ((float)bio.Emotial());//����
//    emotion.Add(new PointF(stX, xy));
//    for (int i = 1; i <= lastOfDay; i++){
//        bio.SetToDay(dt.Year, dt.Month, i);
//        xy = stY - pixH * ((float)bio.Emotial());//����
//        emotion.Add(new PointF(stX + steps * i, xy));
//    }
//    emotion.Draw(g);//List�� ����� ��� Point�� �����Ѵ�.
//    xPen.Dispose();
//    //������ܿ� Emotial ���� ���
//    float endX = rect.Right - 20.0f;
//    float endY = rect.Top;
//    DrawNotice(g, endX - 100, endY + 70, endX - 90, 
//        endY + 70, Color.Blue, "Emotial");
//}
//public void DrawIntellectual(Graphics g)
//{
//    Pen xPen = new Pen(Color.Brown, 1);
//    float stX = this.orginX;
//    float stY = this.orginY;
//    bio.SetToDay(dt.Year, dt.Month, 1);
//    bio.PerviousDay();//0
//    float xy = stY - pixH * ((float)bio.Intellectual());//����
//    intelec.Add(new PointF(stX, xy));
//    for (int i = 1; i <= lastOfDay; i++){
//        bio.SetToDay(dt.Year, dt.Month, i);
//        xy = stY - pixH * ((float)bio.Intellectual());//����
//        intelec.Add(new PointF(stX + steps * i, xy));
//    }
//    intelec.Draw(g);//List�� ����� ��� Point�� �����Ѵ�.
//    xPen.Dispose();
//    //������ܿ� Intellectual ���� ���
//    float endX = rect.Right - 20.0f;
//    float endY = rect.Top;
//    DrawNotice(g, endX - 100, endY + 90, endX - 90, 
//        endY + 90, Color.Brown, "Intellectual");
//}

//public void DrawVerX(Graphics g,float stX,float stY) {
//    Pen xPen = new Pen(Color.Brown, 1);
//    float endY = stY + 10.0f;
//    g.DrawLine(xPen, new PointF(stX, stY), 
//        new PointF(stX, endY));
//    xPen.Dispose();
//}
//public void DrawVerY(Graphics g, float stX, float stY){
//    Pen xPen = new Pen(Color.Brown, 1);
//    float endX = stX + 10.0f;
//    g.DrawLine(xPen, new PointF(stX, stY), 
//        new PointF(endX, stY));
//    xPen.Dispose();
//}
//public void DrawLineVer(Graphics g) {
//    Pen xPen = new Pen(Color.SpringGreen, 1);
//    float stX = this.orginX;
//    float stY = this.orginY;
//    float stY2 = rect.Top+50;
   
//    float Height = rect.Height - 100f;
//    float Width = rect.Width - 150.0f;
//    Pen axisXPen = new Pen(Color.DarkSlateGray, 1);
//    Font axisXFont = new Font("Arial", 6);
//    SolidBrush axisXBrush = new SolidBrush(Color.SteelBlue);
//    for (int i = 1; i <= lastOfDay; i++){
//        DrawVerX(g, stX + i * steps, stY - 5f);
//        string stV = i.ToString("#");
//        g.DrawString(stV, axisXFont, axisXBrush, 
//            i * steps + stX - 5, stY + 5);
//    }
//    for (float i = 1f; i <= Height-20; i++){
//        if (i % 10 == 0) {
//            DrawVerY(g, stX - 5f, stY2 + i );
//         g.DrawString((Height/(HeightR) - i).ToString("##0"),
//          axisXFont, axisXBrush, stX - 25, (stY2  + i ));
//        }
//    }
//    xPen.Dispose();//������(new��) ��ü�� �ݵ�� Dispose
//    axisXBrush.Dispose();
//    axisXFont.Dispose();
//    axisXPen.Dispose();
//}
private void XYControl_Load(object sender, EventArgs e){
    DateInit(false);
}
private void DateInit(bool bs){
    this.label1.Visible = !bs;
    this.label2.Visible = !bs;
    this.dateTimePicker1.Visible = !bs;
    this.dateTimePicker2.Visible = !bs;
}
private void Remove(){
    //---List�� �ִ� ��� ������ �����Ѵ�.
    physical.Remove();
   // emotion.Remove();
    //intelec.Remove();
}
protected override void OnPaint(PaintEventArgs pe){
    this.Remove();//List�� ���Ե� Point�� ��� �����Ѵ�.
    //����� List�� Point�� ���Ӱ� �׸���.
    int bYear = this.dateTimePicker1.Value.Year;
    int bMonth = this.dateTimePicker1.Value.Month;
    int bDay = this.dateTimePicker1.Value.Day;
    //���ϳ�¥ ����
    bio = new LivingDateTime(bYear, bMonth, bDay);
    //���ó�¥ ����
    dt = new DateTime(this.dateTimePicker2.Value.Year
       , this.dateTimePicker2.Value.Month,
       this.dateTimePicker2.Value.Day,
       new GregorianCalendar());
    //�� ��ȭ�� �˸��� Į����.
    cal = CultureInfo.InvariantCulture.Calendar;
    lastOfDay = cal.GetDaysInMonth(dt.Year, dt.Month, 
        Calendar.CurrentEra);
    steps = (rect.Width - 140.0f) / lastOfDay;
    Graphics g = pe.Graphics;
    if(!isFirst){
        this.DrawPhysical(g);//��ü����
    }
    //if (isFirst){//ó�� �ε��� �� �����ִ� ȭ��
    //    //this.DrawX(g);//x��ǥ
    //    //this.DrawY(g);//y��ǥ
    //    //this.DrawLineVer(g);//���� tic
    //}
    //else{
    // //Invalidate ȣ �ٽ� ȣ���Ͽ� ��� �����ش�.
    //    //this.DrawX(g);//x��ǥ
    //    //this.DrawY(g);//y��ǥ
    //    //DrawToDay(g);
    //    //this.DrawLineVer(g);//���� tic
    //    this.DrawPhysical(g);//��ü����
    //    //this.DrawEmotial(g);//��������
    //    //this.DrawIntellectual(g);//��������
    //}
    //--------------------------
    base.OnPaint(pe);
}
private void dateTimePicker1_ValueChanged(object sender,
    EventArgs e){
    this.Invalidate();//OnPaint�� �ڵ����� ȣ���Ѵ�.
    this.isFirst = false;
}
private void dateTimePicker2_ValueChanged(object sender,
    EventArgs e) {
    this.Invalidate();//OnPaint�� �ڵ����� ȣ���Ѵ�.
    this.isFirst = false;
}
    }
}
