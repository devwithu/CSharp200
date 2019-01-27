using System;
using System.Windows.Forms;
using System.Drawing;
namespace MatchSameImageProject
{

	public class MButton : System.Windows.Forms.Button
	{
		private int x;   //x��ǥ
		private int y;   //y��ǥ
		private bool amIEnd=false;//�������°�  false �� true ��(������)
		//private int gifN=12;
		private int gifD=12;    //�⺻��ȣ
		private Image me;       //�����׸� ������ȣ����
		private Image back;     //�⺻�׸�
		private int myNum=12;   //������ȣ
		public MButton(int x,int y,int z)
		{
			this.x=x;
			this.y=y;
			myNum=z;  //������ȣ
			//	this.Location.X=x;
			//	this.Location.Y=y;
			this.Location = new System.Drawing.Point(x, y);
			this.Size = new System.Drawing.Size(50, 50);
			back=MButtonImage.TheBackImage();
			me=MButtonImage.TheImage(this.myNum);
			Flips();
			//Flops();
		}
		public int GifD
		{
			get{return this.gifD;}
			set{this.gifD=value;}
		}
		public int MyNum
		{
			get{return this.myNum;}
		}
		public int X
		{
			get{return this.x;}
			set{this.x=value;}
		}
		public int Y
		{
			get{return this.y;}
			set{this.y=value;}
		}
		public bool AmIEnd
		{
			get{return this.amIEnd;}
			set{this.amIEnd=value;}
		}

		public void Flips()
		{
			this.Image=back;
		}
		public void Flops()
		{
			this.Image=me;
		}



	}
}
