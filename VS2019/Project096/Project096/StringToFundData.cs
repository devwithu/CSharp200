using System;
namespace Com.JungBo.Logic {
    public class StringToFundData {
        //펀드 일일정보
string[] fundM ={
"CJ,65300,-2000",   "CJ인터넷,16200,-100", "CJ홈쇼핑,63500,-1400",
"GS,43000,-2600", "GS건설,114500,-4000", "KCC,426000,-12500",
"KT,45000,0", "KT&G,89500,-600","KTF,27700,350",
"LG,73600,-1100","LG디스플레이,40800,-900","LG생활건강,218000,3500"};

    //관심주식
   string[] kosdaq ={"삼성전자","신한지주","POSCO",
                    "현대차","한국전력","KTF",
                    "KT","NHN","하이닉스","SK"};

    //관심주식을 찾아서 출력
    public void FundDataForMarathone(){
        char[] splits={','};
        foreach (string fundStr in fundM){
            foreach (string sdaq in kosdaq){
                //,를 기준으로 나눔
                //"CJ,65300,-2000"-> "CJ", "65300" , "-2000"
                string[] qnames = fundStr.Split(splits);
                //관심주식을 펀드 일일정보에서 찾는다. 
                if ((fundStr.Substring(0, qnames[0].Length))
                                      .CompareTo(sdaq) == 0){
                    Console.WriteLine(fundStr);
                }
            }
        }
    }//FundDataForMarathone
    //범위내 관심주식 찾기
    public void FundData(string groupFName, string groupLName){
        foreach (string fundStr in fundM){
            //사전식 비교 A, B~Z, a,b, 0~9 순으로 작아짐
            //'A'-'a'는 양수, 'KT'-'KKR'은 양수 'KK'-'KKR' 음수
            if (fundStr.CompareTo(groupFName)>0 
                && fundStr.CompareTo(groupLName)<0){
                Console.WriteLine(fundStr);
            }
        }
    }//FundData
  }//class
}//namespace
