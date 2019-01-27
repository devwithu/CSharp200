using System;
using System.IO;//DriveInfo
namespace Com.JungBo.Infor {
    public class DirectoryView {

        public void ViewDetailDirectory(string st){
            DirectoryInfo direcs = new DirectoryInfo(st);
            DirectoryInfo[] dirinfos = direcs.GetDirectories();
            Console.WriteLine("Directory in my " + st);
            foreach (DirectoryInfo dir in dirinfos){
                Console.WriteLine("-----------------");
                ViewDirecInfors(dir);
            }
        }
        private void ViewDirecInfors(DirectoryInfo dir) {
            if (dir == null || !dir.Exists) { return; }
            Console.WriteLine("�̸� : {0}", dir.Name);
            Console.WriteLine("�Ӽ� : {0}", dir.Attributes);
            Console.WriteLine("���̸� : {0}", dir.FullName);
            Console.WriteLine("�ۼ��� : {0}", dir.CreationTime);
            Console.WriteLine("�ֱٻ���� : {0}", dir.LastAccessTime);
            Console.WriteLine("�ֱٺ����� : {0}", dir.LastWriteTime);
            Console.WriteLine("�ٷ������ : {0}", dir.Parent);
            Console.WriteLine("��Ʈ : {0}", dir.Root);
            Console.WriteLine("Ȯ���� : {0}", dir.Extension);
            //switch(dir.Attributes){
            //    case FileAttributes.Hidden:
            //        ...
            //        break;
            //    ...
            //    default:
            //        ...
            //        break;
            //}
        }
       
    }
}
