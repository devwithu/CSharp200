using System;
using System.Collections.Generic;
using System.Collections;
namespace Com.JungBo.Infor{
    public class FundInform {
        //�ݵ� ��������
        private string[] fundM ={
"CJ,65300,-2000",   "CJ���ͳ�,16200,-100", "CJȨ����,63500,-1400",
"GS,43000,-2600", "GS�Ǽ�,114500,-4000", "KCC,426000,-12500",
"KT,45000,0", "KT&G,89500,-600","KTF,27700,350",
"LG,73600,-1100","LG���÷���,40800,-900","LG��Ȱ�ǰ�,218000,3500",
"LG����,110500,500","LG�ڷ���,7630,110","LG�м�,26300,-450",
"LGȭ��,92200,-800","LIG���غ���,23050,50","LS,73300,2300",
"NHN,157500,-5100","POSCO,490000,-20000","S-Oil,62600,100",
"SK,116500,-1500","SK������,103500,-2500","SK�ڷ���,177000,-2500"
};
        public IEnumerable<string> GetAllFunds(){
            foreach (string fs in fundM){
                //���ʴ�� ����
                yield return fs;
            }
        }
        public void PrintFunds1(){
            foreach (string fs in GetAllFunds()){
                Console.WriteLine(fs);
            }
        }
        public void PrintFunds2(){
            IEnumerator<string> ie = GetAllFunds().GetEnumerator();
            while (ie.MoveNext()){
                Console.WriteLine(ie.Current);
            }
        }
        public void PrintFunds3(){
            IEnumerator ie = fundM.GetEnumerator();
            while (ie.MoveNext()){
                Console.WriteLine(ie.Current as string);
            }
        }
    }
}
