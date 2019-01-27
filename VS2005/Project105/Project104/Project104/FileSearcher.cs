using System;
using System.IO;
namespace Com.JungBo.Infor{
    public class FileSearcher{
        public void InforView(string fname)  {
            //���� ���丮�� �������丮
            string[] dirs = Directory.GetDirectories(fname);

            foreach (string dir in dirs){
                DirectoryInfo direcs = new DirectoryInfo(dir);
                //���丮 ����
                Console.WriteLine("------------------------------");
                Console.WriteLine("�̸� : {0}", direcs.Name);
                Console.WriteLine("�Ӽ� : {0}", direcs.Attributes);
                Console.WriteLine("���̸� : {0}", direcs.FullName);
                //Console.WriteLine("�ۼ��� : {0}", direcs.CreationTime);
                //���̻� ���� ���丮�� ���� ������
                if (!Directory.Exists(dir)){
                    return;//�� - ������ ������ ��õǾ�� �Ѵ�.
                }
                else {   //���� ���� ���丮�� ��� �����ش�.
                    //���� ���丮�� �ִٸ� �ڽ��� ȣ�� -���
                    InforView(dir);
                }
            }
        }
    }//class
}
