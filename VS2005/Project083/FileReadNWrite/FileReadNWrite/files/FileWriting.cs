using System;
using System.Text;//Encoding
using System.IO;//FileStream, StreamWriter
namespace Com.JungBo.IO{
    public class FileWriting{
        public void FileReads(string fname){
            if (!File.Exists(fname)){
                Console.WriteLine("{0}이 없습니다.", fname);
                return;  //FileReads끝내기
            }
            using (FileStream fs =
                new FileStream(fname, FileMode.Open, FileAccess.Read)){
                using (StreamReader sr =
                    new StreamReader(fs, Encoding.Default)){
                    string message = string.Empty;
                    while ((message = sr.ReadLine()) != null){
                        Console.WriteLine(message);
                    }
                }
            }
        }//FileReads2
        public void FileWrites(string fname){
            using(FileStream fs =
                //새로 만들기(FileMode.CreateNew), 
                //있으면 내용를 지우기(FileMode.Truncate)
                new FileStream(fname, FileMode.Create)){
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
