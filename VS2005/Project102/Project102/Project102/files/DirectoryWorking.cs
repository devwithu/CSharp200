using System;
using System.IO;
namespace Com.JungBo.Infor {
    public class DirectoryWorking {
        public void Make(string fdir, string todir){
            if (!Directory.Exists(fdir) || Directory.Exists(todir)){
                Console.WriteLine(
"�ű� ���丮�� ���ų� �Ű��� ���丮�� �̹� �����մϴ�.");
                return;
            }
            //���丮�� ���� �����
            //������ �ű�� ���� ������ ����
            Directory.Move(fdir,todir);
            string[]mofiles=Directory.GetFiles(todir);
            foreach (string mofile in mofiles){
                Console.WriteLine(mofile);
            }
        }
        public void ViewDirectories(string st){
            string[] direcs = Directory.GetDirectories(st);
            Console.WriteLine("Directories in {0} ", st);
            foreach (string dir in direcs){
                ViewDirecInfors(dir);
            }
        }
        private void ViewDirecInfors(string sdir){
if (!Directory.Exists(sdir) ) { return; }
Console.WriteLine("�ۼ��� : {0}", Directory.GetCreationTime(sdir));
Console.WriteLine("�ֱٻ���� : {0}", Directory.GetLastAccessTime(sdir));
Console.WriteLine("�ֱٺ����� : {0}", Directory.GetLastWriteTime(sdir));
        }
    }
}
