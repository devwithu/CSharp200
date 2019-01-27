using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace FileReadNWrite
{
    class Class1
    {
        public void FileReads3(string fname)
        {
            if (!File.Exists(fname))
            {
                Console.WriteLine("{0}�� �������� �ʽ��ϴ�.", fname);
                return;  //FileReads������
            }
            using (FileStream fs =
                new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                byte[] bs = new byte[1024];
                int readb = -1;
                Encoding e = Encoding.GetEncoding(0);
                while ((readb = fs.Read(bs, 0, bs.Length)) > 0)
                {
                    string message = e.GetString(bs);
                    Console.WriteLine(message.Trim());
                    Array.Clear(bs, 0, bs.Length);//bs�� ������ �����
                }
            }
        }//FileReads2
    }
}
