using System;

namespace WindowCardPlayProject
{
	/// <summary>
	/// CardCase�� ���� ��� �����Դϴ�.
	/// </summary>
	public class CardCase
	{
		private Card[] card;

		public CardCase()
		{
			// 
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
			card=new Card[20];
		}


		public Card[] GetCards
		{
			get
			{
				return this.card;
			}
		}

	
		public string GetCard(int index)
		{
			return this.card[index].GetCard+" ";
		}

		public void full()
		{
			int count=0;

			while(true)
			{
				Card c=new Card();

				if(!this.isSame(card,c))
				{
					card[count++]=c;
				}

				if(count==20) break;
			}

		}


		public bool isSame(Card[]a, Card b)
		{
			bool isSame=false;
			foreach(Card i in a)
			{
				if(i!=null && i.Equals(b))
				{
					isSame=true;
					break;
				}
			}


			return isSame;
		}


	}
}
