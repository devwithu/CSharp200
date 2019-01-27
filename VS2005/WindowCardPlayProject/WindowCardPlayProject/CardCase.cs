using System;

namespace WindowCardPlayProject
{
	/// <summary>
	/// CardCase에 대한 요약 설명입니다.
	/// </summary>
	public class CardCase
	{
		private Card[] card;

		public CardCase()
		{
			// 
			// TODO: 여기에 생성자 논리를 추가합니다.
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
