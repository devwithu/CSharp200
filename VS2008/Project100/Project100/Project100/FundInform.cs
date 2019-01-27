using System;
using System.Collections.Generic;
using System.Collections;
namespace Com.JungBo.Infor{  //섹션 98 수정
    public class FundInform:ICloneable {
        //펀드 일일정보
        private string[] fundM ={
"CJ,65300,-2000",   "CJ인터넷,16200,-100", "CJ홈쇼핑,63500,-1400",
"GS,43000,-2600", "GS건설,114500,-4000", "KCC,426000,-12500",
"KT,45000,0", "KT&G,89500,-600","KTF,27700,350",
"LG,73600,-1100","LG디스플레이,40800,-900","LG생활건강,218000,3500",
"LG전자,110500,500","LG텔레콤,7630,110","LG패션,26300,-450",
"LG화학,92200,-800","LIG손해보험,23050,50","LS,73300,2300",
"NHN,157500,-5100","POSCO,490000,-20000","S-Oil,62600,100",
"SK,116500,-1500","SK에너지,103500,-2500","SK텔레콤,177000,-2500"
};
        public IEnumerable<string> GetAllFunds(){
            foreach (string fs in fundM){
                //차례대로 리턴
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
        public string[] GetAllFundString(){
            string[] ss = new string[fundM.Length];
            Array.Copy(fundM, ss, fundM.Length);
            return ss;
        }
        public object Clone(){
            return GetAllFundString();
        }
    }
}
