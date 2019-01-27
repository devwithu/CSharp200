using System;
using System.Text;//Encoding
using System.IO;//FileStream, StreamReader
namespace Com.JungBo.IO{
    public class FileReading{
        public void FileReads(string fname){
            if(!File.Exists(fname)){
                Console.WriteLine("{0}이 없습니다.",fname);
                return;  //FileReads끝내기
            }
            FileStream fs = null;
            StreamReader sr = null;
            try{
                //fs = File.OpenRead(fname);
                //fs = new FileStream(fname, FileMode.Open);
                fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, Encoding.Default);
                string message = string.Empty;
                while ((message = sr.ReadLine()) != null) {
                    Console.WriteLine(message);
                }
            }
            catch (IOException ee){
                Console.WriteLine(ee.Message);
            }
            finally {
                sr.Close();
                fs.Close();
            }
        }//FileReads
        public void FileWrites(string fname){
            FileStream fs = null;
            StreamWriter sw = null;
            try{
                //fs = new FileStream(fname, FileMode.Create);
                fs = new FileStream(fname, FileMode.Create,FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.Default);
                string message = string.Empty;
                while ((message = Console.ReadLine()) != null){
                    sw.WriteLine(message);
                    sw.Flush();
                }
            }
            catch (IOException ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                sw.Close();
                fs.Close();
            }
        }//
    }
}
