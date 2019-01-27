using System;
using System.IO;
namespace Com.JungBo.Infor {
    public class DirectoryWorking {
        public void Make(string fdir, string todir){
            if (!Directory.Exists(fdir) || Directory.Exists(todir)){
                Console.WriteLine(
"옮길 디렉토리가 없거나 옮겨질 디렉토리가 이미 존재합니다.");
                return;
            }
            //디렉토리를 새로 만들고
            //파일을 옮기고 원래 파일을 삭제
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
Console.WriteLine("작성일 : {0}", Directory.GetCreationTime(sdir));
Console.WriteLine("최근사용일 : {0}", Directory.GetLastAccessTime(sdir));
Console.WriteLine("최근변경일 : {0}", Directory.GetLastWriteTime(sdir));
        }
    }
}
