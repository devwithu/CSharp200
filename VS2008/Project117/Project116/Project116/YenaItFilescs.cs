using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Com.JungBo.Kisa{
 public class YenaItFiles{
     //��ǰ�������ڿ��� �����Ѵ�.
     List<string> list = new List<string>(10);

     public List<string> ProductList{
         get { return list; }
     }
     
    public YenaItFiles() {
        list.Clear();//��� ���� �����
    }
    //���Ͽ��� �� �پ� �о ����Ʈ�� �����Ѵ�.
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
    //�� �� ����
    public void FileWrites(string fname, string message){
        using (FileStream fs =
            //���� �����(FileMode.CreateNew), 
            //������ ���븦 �����(FileMode.Truncate)
            new FileStream(fname, FileMode.Create)){
            using (StreamWriter sw =
                  new StreamWriter(fs, Encoding.Default)){
                      sw.WriteLine(message);
                      sw.Flush();
            }
        }
    }//
     //����Ʈ�� �ִ� ���� �� �پ� ���Ͽ� �����Ѵ�.
    public void FileWrites(string fname, List<Product> list){
        using (FileStream fs =
            //���� �����(FileMode.CreateNew), 
            //������ ���븦 �����(FileMode.Truncate)
            new FileStream(fname, FileMode.Create)){
            using (StreamWriter sw =
                  new StreamWriter(fs, Encoding.Default)){
                foreach (Product message in list){
                    //���ڿ��� �ٲ㼭 ���
                    sw.WriteLine(message.ToString());
                    sw.Flush();
                }
            }
        }
    }//
     //����Ʈ ���� ���
    public void Print() {
        foreach (string var in list) {
            Console.WriteLine(var);
        }
    }
 }
}
