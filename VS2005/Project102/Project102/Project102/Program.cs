using System;
using System.IO;
using Com.JungBo.Infor;
namespace Project102 {
    public class Program {
        public static void Main(string[] args){

            DirectoryView dirview = new DirectoryView();
            dirview.ViewDetailDirectory("C:\\Program Files");
            //���ο� ���丮 �����
            Directory.CreateDirectory("c:\\hello3");
            //c:\\hellos�� ����� ���� �Ѱ� �̻��� ����.
            DirectoryWorking work = new DirectoryWorking();
            work.Make("c:\\hello", "c:\\hellos");
            work.ViewDirectories("c:\\bea");
            //���������
            //Directory.Delete("c:\\hellos");
        }
    }
}
