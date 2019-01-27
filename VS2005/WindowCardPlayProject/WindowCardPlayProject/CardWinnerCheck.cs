using System;

namespace WindowCardPlayProject
{
	/// <summary>
	/// 카드를 펼친후.... 이긴사람을 판별하는 클래스
	/// </summary>
	/// 

	//값들을 호출하기 위한....델리게이트
	delegate void operationDelegate();



	public class CardWinnerCheck
	{
		string [] computerCard;
		string [] userCard;

		
		//승자를 세팅하는 멤버 변수
		// 0은 무승부
		//1은 컴퓨터
		//2은 유저
		private int winnerCheck=-1;

		public int WinnerProperty
		{
			get
			{
				return this.winnerCheck;

			}
		}
		//boolean 변수
		private bool checkMethod=true;

	
		//생성자
		public CardWinnerCheck()
		{
			this.computerCard=new string[2];
			this.userCard=new string[2];
		}


		/// <summary>
		/// 결과를 판단하는 메소드
		/// 각각의 string은 '/'의 파싱문자에 의해 첫번쨰 카드와 두번째 카드로 나눈다.
		/// </summary>
		/// <param name="str1">컴퓨터의 카드</param>
		/// <param name="str2">User의 카드</param>
		public void checkMatch(string str1,string str2)
		{
			this.computerCard=str1.Split('/');
			this.userCard=str2.Split('/');
		}


		/// <summary>
		/// 광떙을 판별하는 메소드  d1,d3,d8 이 한곳에 모이면 광떙
		/// </summary>
		public void searchForLightEqual()
		{
			string temp1,temp2;

			//첫메소드는 true이므로 바로 들어온다.
			if(this.checkMethod)
			{
				for(int i=0;i<computerCard.Length-1;i++)
				{
					//컴퓨터 패
					temp1=computerCard[i].Trim().ToUpper();
					//사람패
					temp2=userCard[i].Trim().ToUpper();


					//컴퓨터 광떙조건..D
					if(temp1.Equals("D1") || temp1.Equals("D3") || temp1.Equals("D8"))
					{
						for(int j=0;j<computerCard.Length-1;j++)
						{
							temp1=computerCard[j].Trim().ToUpper();

							if(i!=j)
							{
								if(temp1.Equals("D1") || temp1.Equals("D3") || temp1.Equals("D8"))
								{
									if(!this.anotherCardThePerfect(true))
									{
										//장떙이가 없다면 컴퓨터승
										this.winnerCheck=1;
										this.checkMethod=false;
									}
									else
									{
										//장떙이면 사람승
										this.winnerCheck=2;
										this.checkMethod=false;
									}

								}
							}
						}
					}

					//User의 조건
				
					if(temp2.Equals("D1") || temp2.Equals("D3") || temp2.Equals("D8"))
					{
						for(int k=0;k<computerCard.Length-1;k++)
						{
							temp2=userCard[k].Trim().ToUpper();

							if(i!=k)
							{
								if(temp2.Equals("D1") || temp2.Equals("D3") || temp2.Equals("D8"))
								{
									if(!this.anotherCardThePerfect(false))//장떙이가 있다면
									{
										this.winnerCheck=2;
										this.checkMethod=false;
									}
									else
									{
										this.winnerCheck=1;
										this.checkMethod=false;
									}
								}
							}
						}
					}

				}


			}
		}
		

		//장땡이 있는가를 확인하는 메소드
		private bool anotherCardThePerfect(bool isCheck)
		{
			//isCheck가 true이면 컴퓨터가 보낸 데이타.
			//isCheck가 false이면 사용자가 보낸 데이타 ..컴퓨터꺼만 체크
			string temp=null;
			int jangTotal=0;

			if(isCheck)
			{
				for(int i=0;i<this.userCard.Length-1;i++)
				{
					temp=this.userCard[i].Substring(1,2).Trim().ToString();

					jangTotal+=int.Parse(temp);
				}


				if(jangTotal==20)
					return true;
			}
			else
			{
				for(int i=0;i<this.computerCard.Length-1;i++)
				{
					temp=this.computerCard[i].Substring(1,2).Trim().ToString();

					jangTotal+=int.Parse(temp);
				}


				if(jangTotal==20)
					return true;
			}

			return false;
		}




		//떼이를 체크하는 메소드
		public void eachdoubleCheck()
		{
			string temp=null;
			string temp2=null;
			int tempDoubleValue=0;
			int tempDoubleValue2=0;
			
			if(this.checkMethod)
			{
				for(int i=0;i<this.computerCard.Length-1;i++)
				{
					temp=this.computerCard[i].Substring(1,2).Trim().ToString();
					temp2=this.userCard[i].Substring(1,2).Trim().ToString();


					for(int j=0;j<this.computerCard.Length-1;j++)
					{
						if(i!=j && (this.computerCard[j].Substring(1,2).Trim().ToString()==temp))
						{
							//컴퓨터의 경우 뗴이가 있다면
							tempDoubleValue=int.Parse( this.computerCard[j].Substring(1,2).Trim().ToString());
						}

						if(i!=j && (this.userCard[j].Substring(1,2).Trim().ToString()==temp2))
						{
							//사용자의 경우 떼이가 있다면
							tempDoubleValue2=int.Parse(this.userCard[j].Substring(1,2).Trim().ToString());
						}
					
					}

				}

				//떼이값을 비교하는 루틴

				//둘다....떼이가 있다면..
				if(tempDoubleValue!=0 && tempDoubleValue2!=0)
				{
					//떼이크기를 비교하는 메소드 호출
					int t=this.valueCheck(tempDoubleValue,tempDoubleValue2);

					//메소드로 부터 리턴 되온 변수t
					if(t==2)
					{
						this.winnerCheck=2;
						this.checkMethod=false;
					}
					else if(t==1)
					{
						this.winnerCheck=1;
						this.checkMethod=false;
					}
					else
					{
						this.winnerCheck=0;
						this.checkMethod=false;
					}
				}
				else if(tempDoubleValue!=0 && tempDoubleValue2==0)
				{
					this.winnerCheck=1;
					this.checkMethod=false;
				}
				else if(tempDoubleValue==0 && tempDoubleValue2!=0)
				{
					this.checkMethod=false;
					this.winnerCheck=2;
				}
			}
		}



		//값들을 비교하는 메소드
		private int valueCheck(int com1,int user1)
		{
			if(com1>user1)
				return 1;	//컴퓨터
			else if(com1==user1)
				return 0;	//무승부
			else 
				return 2;		//유저
				
		}


		//장떙도..떼이도 아닌 일반경우를 확인하는 메소드...
		public void eachSingleCheck()
		{

			//참이면
			if(this.checkMethod)
			{
				int tempCom=0;
				int tempUser=0;

				
				//중복일때 검사하는 변수
				int jungBok=1;
				int jungBok2=1;

				for(int i=0;i<this.userCard.Length-1;i++)
				{
					string t=this.computerCard[i].Substring(1,2).Trim().ToString();
					string t2=this.userCard[i].Substring(1,2).Trim().ToString();
					
					tempCom+=int.Parse(t);
					tempUser+=int.Parse(t2);

					//중복일때만 쓸거야.
					jungBok*=int.Parse(t);
					jungBok2*=int.Parse(t2);
				}

				tempCom=tempCom%10;
				tempUser=tempUser%10;
                
				int winnevalue=this.valueCheck(tempCom,tempUser);

				if(winnevalue==0)
				{
					//무승부일경우..곱하기해서
					int gobWinner=this.valueCheck(jungBok,jungBok2);

								if(gobWinner ==0)
									this.winnerCheck=0;
								else if(gobWinner==1)
									this.winnerCheck=1;	//컴퓨터
								else 
									this.winnerCheck=2;	//사람
				
				}
				else if(winnevalue==1)
					this.winnerCheck=1;		//컴퓨터
				else
					this.winnerCheck=2;	//사람

			}
			

		}


		




	}
}
