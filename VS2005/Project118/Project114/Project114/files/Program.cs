using System;
using Com.JungBo.Fund;
namespace Project114 {
 public class Program {
    public static void Main(string[] args){
        //CSV  ->  XML�� ��ȯ�ϱ�
        string[] fundList ={
        "CJ,65400,-1100",
        "CJ���ͳ�,16200,200",
        "KT&G, 64800, -1800"};

        FundInformWrite fw=new FundInformWrite();
        //xml�� �ٲ㼭 ���
        string fundstring = fw.ToDataXML(fundList);
        Console.WriteLine(fundstring);
    }
 }
}