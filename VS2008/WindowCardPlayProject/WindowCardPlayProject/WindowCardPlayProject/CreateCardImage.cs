using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowCardPlayProject
{
	/// <summary>
	/// 파일 이름을 받아서...이미지를 리턴한다
	/// 
	/// </summary>
	public class CreateCardImage
	{

		public CreateCardImage()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}

		
		/// <summary>
		/// 폼에서 넘어온 문자로 이미지를 찾아 리턴한다.
		/// </summary>
		/// <param name="str">이미지 이름</param>
		public Image bringTheImage(string str)
		{
			//string currentDirectory=Environment.CurrentDirectory;
			string tmp="../../Image/"+str.ToLower().Trim()+".bmp";
			//tmp=currentDirectory+tmp;
			
			
			return Image.FromFile(tmp,true);
		}


		//카드의 뒷면을 보내줌
		public Image bringTheBackImage()
		{
			//string currentDirectory=Environment.CurrentDirectory;
			string tmp="../../Image/bb.bmp";
			//tmp=currentDirectory+tmp;
			
			return Image.FromFile(tmp,true);
		}
	}
}