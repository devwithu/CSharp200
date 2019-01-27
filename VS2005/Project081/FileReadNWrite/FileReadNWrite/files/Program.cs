using System;
using Com.JungBo.IO;
namespace FileReadNWrite{
    public class Program{
        public static void Main(string[] args){

            FileReading fr = new FileReading();
            //fr.FileReads("../../FileReading.cs");
            //fr.FileWrites("../../bb.txt");
            fr.FileReads("../../bb.txt");
            //FileWriting fw = new FileWriting();
            //fr.FileReads("../../FileReading.cs");
            //fw.FileReads("../../bb.txt");
            //fw.FileWrites("../../bb.txt");
        }
    }
}
