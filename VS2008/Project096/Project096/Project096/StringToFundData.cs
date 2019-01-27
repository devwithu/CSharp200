using System;
namespace Com.JungBo.Logic {
    public class StringToFundData {
        //�ݵ� ��������
string[] fundM ={
"CJ,65300,-2000",   "CJ���ͳ�,16200,-100", "CJȨ����,63500,-1400",
"GS,43000,-2600", "GS�Ǽ�,114500,-4000", "KCC,426000,-12500",
"KT,45000,0", "KT&G,89500,-600","KTF,27700,350",
"LG,73600,-1100","LG���÷���,40800,-900","LG��Ȱ�ǰ�,218000,3500"};

    //�����ֽ�
   string[] kosdaq ={"�Ｚ����","��������","POSCO",
                    "������","�ѱ�����","KTF",
                    "KT","NHN","���̴н�","SK"};

    //�����ֽ��� ã�Ƽ� ���
    public void FundDataForMarathone(){
        char[] splits={','};
        foreach (string fundStr in fundM){
            foreach (string sdaq in kosdaq){
                //,�� �������� ����
                //"CJ,65300,-2000"-> "CJ", "65300" , "-2000"
                string[] qnames = fundStr.Split(splits);
                //�����ֽ��� �ݵ� ������������ ã�´�. 
                if ((fundStr.Substring(0, qnames[0].Length))
                                      .CompareTo(sdaq) == 0){
                    Console.WriteLine(fundStr);
                }
            }
        }
    }//FundDataForMarathone
    //������ �����ֽ� ã��
    public void FundData(string groupFName, string groupLName){
        foreach (string fundStr in fundM){
            //������ �� A, B~Z, a,b, 0~9 ������ �۾���
            //'A'-'a'�� ���, 'KT'-'KKR'�� ��� 'KK'-'KKR' ����
            if (fundStr.CompareTo(groupFName)>0 
                && fundStr.CompareTo(groupLName)<0){
                Console.WriteLine(fundStr);
            }
        }
    }//FundData
  }//class
}//namespace
