using System;
namespace Com.JungBo.Logic{
    public class JuminNumCheck{

        public void NumCount(string jumins, out int count) {
            int num = 0;
            for (int i = 0; i < jumins.Length; i++){
                char c = jumins[i]; //'1' string get indexer
                if (char.IsDigit(c)){
                    num++;
                }
            }
            count = num;
        }
        //123456-1234567-> 1234561234567
        public void ToInt2(string jumins){
            int count;
            int jucount = 0;
            NumCount(jumins,out count);//count 구하기
            char[] jumin = new char[count];
            char[] cc = jumins.ToCharArray();//'1','2','3'
            for (int i = 0; i < cc.Length; i++){
                 if (char.IsDigit(cc[i])){
                   jumin[jucount++] = cc[i]; 
                }
            }
            string ss = new string(jumin);//char배열을 string으로
            Console.WriteLine(ss);
        }//
        //123456-1234567-> 1234561234567
        public void ToInt3(string jumins){
            string ss = string.Empty;
            char[] cc = jumins.ToCharArray();//'1','2','3'
            for (int i = 0; i < cc.Length; i++){
                if (char.IsDigit(cc[i]))
                {
                    ss += cc[i];
                    //ss = string.Concat(ss, cc[i]);
                }
            }
            Console.WriteLine(ss);
        }//
    }//class
}//
