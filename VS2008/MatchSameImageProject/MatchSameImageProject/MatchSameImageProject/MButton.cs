using System;
using System.Windows.Forms;
using System.Drawing;
namespace MatchSameImageProject
{

	public class MButton : System.Windows.Forms.Button
	{
		private int x;   //x좌표
		private int y;   //y좌표
		private bool amIEnd=false;//뒤집혔는가  false 뒤 true 앞(뒤집힘)
		//private int gifN=12;
		private int gifD=12;    //기본번호
		private Image me;       //고유그림 고유번호관련
		private Image back;     //기본그림
		private int myNum=12;   //고유번호
		public MButton(int x,int y,int z)
		{
			this.x=x;
			this.y=y;
			myNum=z;  //고유번호
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
