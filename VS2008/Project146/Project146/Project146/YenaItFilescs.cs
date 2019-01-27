using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Com.JungBo.Kisa{
 public class YenaItFiles{
     //제품정보문자열을 저장한다.
     List<string> list = new List<string>(10);

     public List<string> ProductList{
         get { return list; }
     }
     
    public YenaItFiles() {
        list.Clear();//모든 내용 지우기
    }
    //파일에서 한 줄씩 읽어서 리스트에 저장한다.
    public void FileRead(string fname) {
      using(FileStream fs = new FileStream(fname,FileMode.Open)){
            using (StreamReader sr = 
                    new StreamReader(fs, Encoding.Default)) {
                        string message = string.Empty;
                while ((message = sr.ReadLine()) != null){
                    list.Add(message);
                }
                sr.Close();
            }
            fs.Close();
        }
    }
    //한 줄 저장
    public void FileWrites(string fname, string message){
        using (FileStream fs =
            //새로 만들기(FileMode.CreateNew), 
            //있으면 내용를 지우기(FileMode.Truncate)
            new FileStream(fname, FileMode.Create)){
            using (StreamWriter sw =
                  new StreamWriter(fs, Encoding.Default)){
                      sw.WriteLine(message);
                      sw.Flush();
            }
        }
    }//
     //리스트에 있는 것을 한 줄씩 파일에 저장한다.
    public void FileWrites(string fname, List<Product> list){
        using (FileStream fs =
            //새로 만들기(FileMode.CreateNew), 
            //있으면 내용를 지우기(FileMode.Truncate)
            new FileStream(fname, FileMode.Create)){
            using (StreamWriter sw =
                  new StreamWriter(fs, Encoding.Default)){
                foreach (Product message in list){
                    //문자열로 바꿔서 출력
                    sw.WriteLine(message.ToString());
                    sw.Flush();
                }
            }
        }
    }//
     //리스트 내용 출력
    public void Print() {
        foreach (string var in list) {
            Console.WriteLine(var);
        }
    }
 }
}
