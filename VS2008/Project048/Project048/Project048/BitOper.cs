using System;
using System.Collections;   //ArrayList ������ using
namespace Com.JungBo.Logic{
    //boxing unboxing
    public class BitOper{
        public const int MASK02 = 1;
        private ArrayList twoList = new ArrayList();

        //10������ 2������ ������ȯ
        public  void TenToBinary(int n){
            twoList.Clear();
            for (int i = 0; i < 32; i++){
                //twoList[i]=n& MASK02�� �ٲٱ�
                //�������� ���̱� add�� ���ʿ� ���̱�
                twoList.Insert(0, n& MASK02); //�ڽ�
                n >>= 1;//����Ʈ������ ����,��� ����
            }
        }//
        //overloading
        public string TenToBinary(){

            string str=string.Empty;
            int count = twoList.IndexOf(1);
            //Console.WriteLine(count);
            //����0, -0�� count->-1
            if (count > 0){
                twoList.RemoveRange(0, count);//0���� count���� ����
            }
            for (int i = 0; i < twoList.Count; i++){
                str += (int)twoList[i];//��ڽ�
            }
            return str;
            //
        }//
    }//class
}
