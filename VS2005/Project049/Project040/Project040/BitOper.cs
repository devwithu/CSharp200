using System;
using System.Collections.Generic;//List<int>
namespace Com.JungBo.Logic{
    //���׸�(���׸�)
    public class BitOper{

        public const int MASK02 = 1;
        private List<int> twoList = new List<int>();

        //10������ 2������ ������ȯ
        public  void TenToBinary(int n){
            twoList.Clear();
            for (int i = 0; i < 32; i++){
                //twoList[i]=n& MASK02�� �ٲٱ�
                //�������� ���̱� add�� ���ʿ� ���̱�
                twoList.Insert(0, n& MASK02);
                n >>= 1;//����Ʈ������ ����,��� ����
            }
        }//
        //overloading
        public string TenToBinary(){

            string str=string.Empty;
            int count = twoList.IndexOf(1);
            //����0, -0�� count->-1
            if (count > 0){
                twoList.RemoveRange(0, count);//0���� count���� ����
            }
            for (int i = 0; i < twoList.Count; i++){
                str +=twoList[i];//(int)�� �ʿ����.
            }
            return str;
            //
        }//
    }//class
}
