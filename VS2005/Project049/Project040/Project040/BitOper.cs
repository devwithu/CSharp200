using System;
using System.Collections.Generic;//List<int>
namespace Com.JungBo.Logic{
    //지네릭(제네릭)
    public class BitOper{

        public const int MASK02 = 1;
        private List<int> twoList = new List<int>();

        //10진수를 2진수로 진수변환
        public  void TenToBinary(int n){
            twoList.Clear();
            for (int i = 0; i < 32; i++){
                //twoList[i]=n& MASK02는 바꾸기
                //앞쪽으로 붙이기 add는 뒤쪽에 붙이기
                twoList.Insert(0, n& MASK02);
                n >>= 1;//쉬프트연산은 음수,양수 무관
            }
        }//
        //overloading
        public string TenToBinary(){

            string str=string.Empty;
            int count = twoList.IndexOf(1);
            //숫자0, -0은 count->-1
            if (count > 0){
                twoList.RemoveRange(0, count);//0부터 count개를 제거
            }
            for (int i = 0; i < twoList.Count; i++){
                str +=twoList[i];//(int)가 필요없다.
            }
            return str;
            //
        }//
    }//class
}
