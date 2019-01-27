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
            Console.WriteLine("이름 : {0}", dir.Name);
            Console.WriteLine("속성 : {0}", dir.Attributes);
            Console.WriteLine("상세이름 : {0}", dir.FullName);
            Console.WriteLine("작성일 : {0}", dir.CreationTime);
            Console.WriteLine("최근사용일 : {0}", dir.LastAccessTime);
            Console.WriteLine("최근변경일 : {0}", dir.LastWriteTime);
            Console.WriteLine("바로위경로 : {0}", dir.Parent);
            Console.WriteLine("루트 : {0}", dir.Root);
            Console.WriteLine("확장자 : {0}", dir.Extension);
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
