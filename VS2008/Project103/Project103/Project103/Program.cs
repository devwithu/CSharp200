﻿using System;
using System.IO;
using Com.JungBo.Infor;
namespace Project103{
    public class Program{
        public static void Main(string[] args){
            FileView fview = new FileView();
            //0) c:에 있는 파일들 보기
            fview.ViewFiles("c:\\");// 파일 보이기
            try{
                //1) hellos 디렉토리를 먼저 만들 것.
                //먼저 쓰고, 파일저장 Ctrl+C
                //fview.FileWrites("C:\\hellos\\aa.txt"); //입력하고 저장
                //2) 복사하기- 먼저 1)에 주석달 것. 
                //bb.txt가 있으면 엎어씀
                //File.Copy("C:\\hellos\\aa.txt", "C:\\hello3\\bb.txt", true);
                //bb.txt가 있으면 예외발생
                //File.Copy("C:\\hellos\\aa.txt", "C:\\hello3\\bb.txt");//false
                //3) 1) 2) 주석달것. 
                //파일 삭제
                //File.Delete("C:\\hello3\\bb.txt");
                //파일옮기기 -옮긴 후 bb.txt 삭제
                //File.Move("C:\\hellos\\aa.txt", "C:\\hello3\\bb.txt");
                //4) 파일읽기
                //파일 읽기
                //fview.FileReads("C:\\hello3\\bb.txt");
            }
            catch (Exception ee){

                Console.WriteLine(ee.ToString());
            }
        }
    }
}
