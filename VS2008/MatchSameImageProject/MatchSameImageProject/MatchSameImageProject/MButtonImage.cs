using System;
using System.Drawing;
namespace MatchSameImageProject
{
	public class MButtonImage
	{
		public  static Image TheImage(int num)
		{
			//string currentDirectory=Environment.CurrentDirectory;
			string tmp=@"\image\s"+num+".gif";
			//tmp=@"..\"+currentDirectory+tmp;
			tmp=@"..\.."+tmp;
			return Image.FromFile(tmp,true);
		}//
		public  static Image TheImage(string num)
		{
			//string currentDirectory=Environment.CurrentDirectory;
			string tmp=@"\image\"+num;
			//tmp=@"..\"+currentDirectory+tmp;
			tmp=@"..\.."+tmp;
			return Image.FromFile(tmp,true);
		}//

		//Ä«µåÀÇ µÞ¸éÀ» º¸³»ÁÜ
		public static  Image TheBackImage()
		{
			//string currentDirectory=Environment.CurrentDirectory;
			string tmp=@"\image\s12.gif";
			//tmp=@"..\"+currentDirectory+tmp;
			tmp=@"..\.."+tmp;
			
			return Image.FromFile(tmp,true);
		}
		public static string TheDefault()
		{
			string currentDirectory=Environment.CurrentDirectory;
			return currentDirectory;
		}
	}
}
