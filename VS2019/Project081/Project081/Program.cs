using System;
using Com.JungBo.IO;

namespace Com.JungBo.Basic
{
    //델리게이트 선언
    public delegate void Attack();
    public delegate void DoIt(String str);

    public class Zilot
    {

        public static void Main(string[] args)
        {

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