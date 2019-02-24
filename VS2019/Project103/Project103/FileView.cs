using System;
using System.IO;//File, FileInfo
using System.Text;//Encoding
namespace Com.JungBo.Infor {
    public class FileView {
        public void ViewFile(string fname) {
            if (!File.Exists(fname)) {
                Console.WriteLine("�������� �ʴ� �����Դϴ�.");
                return;
            }
            Console.WriteLine("�Ӽ� : {0}", File.GetAttributes(fname));
            Console.WriteLine("�ۼ��� : {0}", File.GetCreationTime(fname));
            Console.WriteLine("�ֱٻ���� : {0}", File.GetLastAccessTime(fname));
            Console.WriteLine("�ֱٺ����� : {0}", File.GetLastWriteTime(fname));
            
        }
        public void ViewFiles(string dir){
            DirectoryInfo dinfo = new DirectoryInfo(dir);
            FileInfo[] finfos= dinfo.GetFiles();
            foreach (FileInfo finfo in finfos){
                ViewFile(finfo);
            }
        }

        public void ViewFile(FileInfo finfo){

            Console.WriteLine("�Ӽ� : {0}", finfo.Attributes);
            Console.WriteLine("��ο��̸� : {0}B", finfo.FullName);
            Console.WriteLine("�ۼ��� : {0}", finfo.CreationTime);
            Console.WriteLine("�ֱٻ���� : {0}", finfo.LastAccessTime);
            Console.WriteLine("��ü��� : {0}", finfo.DirectoryName);
            Console.WriteLine("�ֱٺ����� : {0}", finfo.LastWriteTime);
            Console.WriteLine("����ũ�� : {0}B", finfo.Length);
            Console.WriteLine("Ȯ���� : {0}B", finfo.Extension);
        }
        //���� 81
        public void FileReads(string fname){
            if (!File.Exists(fname)){
                Console.WriteLine("{0}�� �����ϴ�.", fname);
                return;  //FileReads������
            }
            FileStream fs = null;
            StreamReader sr = null;
            try{
                fs = File.OpenRead(fname);
                //fs = File.Open(fname,FileMode.Open);
                //fs = new FileStream(fname, FileMode.Open);
                //fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, Encoding.Default);
                string message = string.Empty;
                while ((message = sr.ReadLine()) != null){
                    Console.WriteLine(message);
                }
            }
            catch (IOException ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                sr.Close();
                fs.Close();
            }
        }//FileReads
        //���� 82
        public void FileWrites(string fname){
            using (FileStream fs =
                //File.OpenWrite(fname)){
                File.Open(fname,FileMode.Create)){//����ų� �����
                using (StreamWriter sw =
                    new StreamWriter(fs, Encoding.Default)){
                    string message = string.Empty;
                    while ((message = Console.ReadLine()) != null){
                        sw.WriteLine(message);
                        sw.Flush();
                    }
                }
            }
        }//
    }
}
