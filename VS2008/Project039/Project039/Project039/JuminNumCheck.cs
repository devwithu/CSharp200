using System;
namespace Com.JungBo.Logic{
    //char<->int Çüº¯È¯
    public class JuminNumCheck{
        //"123456-1234567"-> {1,2,3,4,5,6,1,2,3,4,5,6,7}
        public int[] ToInt(string jumins){
            int[] jumin = new int[jumins.Length - 1];
            string jju = jumins.Replace("-", "");
            char[] cc = jju.ToCharArray();//'1','2','3'
            for (int i = 0; i < cc.Length; i++){
                //jumin[i] = cc[i] - '0';// '7'-'0'=>7 //55-48
                //jumin[i] = (int)Char.GetNumericValue(cc[i]);
                //jumin[i] = int.Parse(cc[i].ToString());
                //jumin[i] = Convert.ToInt32(cc[i]+"");
                jumin[i] = Int32.Parse(cc[i].ToString());
            }
            return jumin;
        }//
    }//class
}//
