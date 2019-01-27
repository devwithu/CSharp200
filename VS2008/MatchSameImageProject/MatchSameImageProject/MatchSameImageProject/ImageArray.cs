using System;

namespace MatchSameImageProject
{
	
	/// 
	/// </summary>
	public class ImageArray
	{
		
		int []  sinx ;
		int a;
		public ImageArray(int a)
		{
			this.a = a;
			sinx = new int[a];
			setimageArry();
		}
		public void setimageArry()
		{
			int temp=0;
			int setcount = 0;
			bool nextnum=true;
            Random rd = new Random();
			for(int i=0; i< a; i++)
			{				
				nextnum=true;
				while(nextnum)
				{
					temp = rd.Next(a/2);
					for(int j=0;j<i;j++)
					{
						if(sinx[j] == temp)
						{
							setcount++;
						}
					}
					if (setcount < 2)
					{
						sinx[i] = temp;
						nextnum = false;
						setcount = 0;
					}
					else
					{
						setcount = 0;
					}
				}
			}
			
		}
		public int[] Getindex()
		{
			return sinx;
		}
	}
}
