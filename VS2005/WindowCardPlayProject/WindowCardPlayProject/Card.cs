using System;

namespace WindowCardPlayProject
{
	/// <summary>
	/// Card�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Card
	{

		public  string [] deck={"S","D"};
		public  string [] piece={"1","2","3","4","5","6","7","8","9","10"};
		private string card="";
		
		public Card()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
			init();
		}

		public string GetCard
		{
			get
			{
				return this.card;
			}
		}


		public void init()
		{
			Random r=new Random();
			card=deck[r.Next(2)]+piece[r.Next(10)];
		}


		public override string ToString()
		{
			return this.card;
		}


		public override bool Equals(object obj)
		{
			//A.Equals(B)

			Card temp=(Card)obj;
			bool isEqual=false;

			if(this.card.Equals(temp.GetCard))

			{
				isEqual=true;
			}

			return isEqual;

		}

		public override int GetHashCode()
		{
			return this.card.GetHashCode()+1001;
		}

	}
}
