using System;

namespace WindowCardPlayProject
{
	/// <summary>
	/// ī�带 ��ģ��.... �̱����� �Ǻ��ϴ� Ŭ����
	/// </summary>
	/// 

	//������ ȣ���ϱ� ����....��������Ʈ
	delegate void operationDelegate();



	public class CardWinnerCheck
	{
		string [] computerCard;
		string [] userCard;

		
		//���ڸ� �����ϴ� ��� ����
		// 0�� ���º�
		//1�� ��ǻ��
		//2�� ����
		private int winnerCheck=-1;

		public int WinnerProperty
		{
			get
			{
				return this.winnerCheck;

			}
		}
		//boolean ����
		private bool checkMethod=true;

	
		//������
		public CardWinnerCheck()
		{
			this.computerCard=new string[2];
			this.userCard=new string[2];
		}


		/// <summary>
		/// ����� �Ǵ��ϴ� �޼ҵ�
		/// ������ string�� '/'�� �Ľ̹��ڿ� ���� ù���� ī��� �ι�° ī��� ������.
		/// </summary>
		/// <param name="str1">��ǻ���� ī��</param>
		/// <param name="str2">User�� ī��</param>
		public void checkMatch(string str1,string str2)
		{
			this.computerCard=str1.Split('/');
			this.userCard=str2.Split('/');
		}


		/// <summary>
		/// ������ �Ǻ��ϴ� �޼ҵ�  d1,d3,d8 �� �Ѱ��� ���̸� ����
		/// </summary>
		public void searchForLightEqual()
		{
			string temp1,temp2;

			//ù�޼ҵ�� true�̹Ƿ� �ٷ� ���´�.
			if(this.checkMethod)
			{
				for(int i=0;i<computerCard.Length-1;i++)
				{
					//��ǻ�� ��
					temp1=computerCard[i].Trim().ToUpper();
					//�����
					temp2=userCard[i].Trim().ToUpper();


					//��ǻ�� ��������..D
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
										//�勯�̰� ���ٸ� ��ǻ�ͽ�
										this.winnerCheck=1;
										this.checkMethod=false;
									}
									else
									{
										//�勯�̸� �����
										this.winnerCheck=2;
										this.checkMethod=false;
									}

								}
							}
						}
					}

					//User�� ����
				
					if(temp2.Equals("D1") || temp2.Equals("D3") || temp2.Equals("D8"))
					{
						for(int k=0;k<computerCard.Length-1;k++)
						{
							temp2=userCard[k].Trim().ToUpper();

							if(i!=k)
							{
								if(temp2.Equals("D1") || temp2.Equals("D3") || temp2.Equals("D8"))
								{
									if(!this.anotherCardThePerfect(false))//�勯�̰� �ִٸ�
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
		

		//�嶯�� �ִ°��� Ȯ���ϴ� �޼ҵ�
		private bool anotherCardThePerfect(bool isCheck)
		{
			//isCheck�� true�̸� ��ǻ�Ͱ� ���� ����Ÿ.
			//isCheck�� false�̸� ����ڰ� ���� ����Ÿ ..��ǻ�Ͳ��� üũ
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




		//���̸� üũ�ϴ� �޼ҵ�
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
							//��ǻ���� ��� ���̰� �ִٸ�
							tempDoubleValue=int.Parse( this.computerCard[j].Substring(1,2).Trim().ToString());
						}

						if(i!=j && (this.userCard[j].Substring(1,2).Trim().ToString()==temp2))
						{
							//������� ��� ���̰� �ִٸ�
							tempDoubleValue2=int.Parse(this.userCard[j].Substring(1,2).Trim().ToString());
						}
					
					}

				}

				//���̰��� ���ϴ� ��ƾ

				//�Ѵ�....���̰� �ִٸ�..
				if(tempDoubleValue!=0 && tempDoubleValue2!=0)
				{
					//����ũ�⸦ ���ϴ� �޼ҵ� ȣ��
					int t=this.valueCheck(tempDoubleValue,tempDoubleValue2);

					//�޼ҵ�� ���� ���� �ǿ� ����t
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



		//������ ���ϴ� �޼ҵ�
		private int valueCheck(int com1,int user1)
		{
			if(com1>user1)
				return 1;	//��ǻ��
			else if(com1==user1)
				return 0;	//���º�
			else 
				return 2;		//����
				
		}


		//�勯��..���̵� �ƴ� �Ϲݰ�츦 Ȯ���ϴ� �޼ҵ�...
		public void eachSingleCheck()
		{

			//���̸�
			if(this.checkMethod)
			{
				int tempCom=0;
				int tempUser=0;

				
				//�ߺ��϶� �˻��ϴ� ����
				int jungBok=1;
				int jungBok2=1;

				for(int i=0;i<this.userCard.Length-1;i++)
				{
					string t=this.computerCard[i].Substring(1,2).Trim().ToString();
					string t2=this.userCard[i].Substring(1,2).Trim().ToString();
					
					tempCom+=int.Parse(t);
					tempUser+=int.Parse(t2);

					//�ߺ��϶��� ���ž�.
					jungBok*=int.Parse(t);
					jungBok2*=int.Parse(t2);
				}

				tempCom=tempCom%10;
				tempUser=tempUser%10;
                
				int winnevalue=this.valueCheck(tempCom,tempUser);

				if(winnevalue==0)
				{
					//���º��ϰ��..���ϱ��ؼ�
					int gobWinner=this.valueCheck(jungBok,jungBok2);

								if(gobWinner ==0)
									this.winnerCheck=0;
								else if(gobWinner==1)
									this.winnerCheck=1;	//��ǻ��
								else 
									this.winnerCheck=2;	//���
				
				}
				else if(winnevalue==1)
					this.winnerCheck=1;		//��ǻ��
				else
					this.winnerCheck=2;	//���

			}
			

		}


		




	}
}
