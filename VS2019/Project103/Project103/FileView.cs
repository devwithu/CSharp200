using System;
using System.IO;//File, FileInfo
using System.Text;//Encoding
namespace Com.JungBo.Infor {
    public class FileView {
        public void ViewFile(string fname) {
            if (!File.Exists(fname)) {
                Console.WriteLine("존재하지 않는 파일입니다.");
                return;
            }
            Console.WriteLine("속성 : {0}", File.GetAttributes(fname));
            Console.WriteLine("작성일 : {0}", File.GetCreationTime(fname));
            Console.WriteLine("최근사용일 : {0}", File.GetLastAccessTime(fname));
            Console.WriteLine("최근변경일 : {0}", File.GetLastWriteTime(fname));
            
        }
        public void ViewFiles(string dir){
            DirectoryInfo dinfo = new DirectoryInfo(dir);
            FileInfo[] finfos= dinfo.GetFiles();
            foreach (FileInfo finfo in finfos){
                ViewFile(finfo);
            }
        }

        public void ViewFile(FileInfo finfo){

            Console.WriteLine("속성 : {0}", finfo.Attributes);
            Console.WriteLine("경로와이름 : {0}B", finfo.FullName);
            Console.WriteLine("작성일 : {0}", finfo.CreationTime);
            Console.WriteLine("최근사용일 : {0}", finfo.LastAccessTime);
            Console.WriteLine("전체경로 : {0}", finfo.DirectoryName);
            Console.WriteLine("최근변경일 : {0}", finfo.LastWriteTime);
            Console.WriteLine("파일크기 : {0}B", finfo.Length);
            Console.WriteLine("확장자 : {0}B", finfo.Extension);
        }
        //섹션 81
        public void FileReads(string fname){
            if (!File.Exists(fname)){
                Console.WriteLine("{0}이 없습니다.", fname);
                return;  //FileReads끝내기
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
        //섹션 82
        public void FileWrites(string fname){
            using (FileStream fs =
                //File.OpenWrite(fname)){
                File.Open(fname,FileMode.Create)){//만들거나 덮어쓰기
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
