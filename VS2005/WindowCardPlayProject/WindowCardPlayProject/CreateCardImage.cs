using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowCardPlayProject
{
	/// <summary>
	/// ���� �̸��� �޾Ƽ�...�̹����� �����Ѵ�
	/// 
	/// </summary>
	public class CreateCardImage
	{

		public CreateCardImage()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
		}

		
		/// <summary>
		/// ������ �Ѿ�� ���ڷ� �̹����� ã�� �����Ѵ�.
		/// </summary>
		/// <param name="str">�̹��� �̸�</param>
		public Image bringTheImage(string str)
		{
			string currentDirectory=Environment.CurrentDirectory;
			string tmp="\\Image\\"+str.ToLower().Trim()+".bmp";
			tmp=currentDirectory+tmp;
			
			
			return Image.FromFile(tmp,true);
		}


		//ī���� �޸��� ������
		public Image bringTheBackImage()
		{
			string currentDirectory=Environment.CurrentDirectory;
			string tmp="\\Image\\bb.bmp";
			tmp=currentDirectory+tmp;
			
			return Image.FromFile(tmp,true);
		}
	}
}