using System;
using System.IO;
using Com.JungBo.Infor;
namespace Project102 {
    public class Program {
        public static void Main(string[] args){

            DirectoryView dirview = new DirectoryView();
            dirview.ViewDetailDirectory("C:\\Program Files");
            //새로운 디렉토리 만들기
            Directory.CreateDirectory("c:\\hello3");
            //c:\\hellos를 만들고 파일 한개 이상을 넣자.
            DirectoryWorking work = new DirectoryWorking();
            work.Make("c:\\hello", "c:\\hellos");
            work.ViewDirectories("c:\\bea");
            //파일지우기
            //Directory.Delete("c:\\hellos");
        }
    }
}
