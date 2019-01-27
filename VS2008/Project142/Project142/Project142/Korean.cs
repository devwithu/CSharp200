using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic{
 public class Korean{
    //�ѱ�� int[]�� �ٲ۴�.
    public static int[] ToBits(string kor) {
        Encoding unicode = Encoding.Unicode;
        byte[] unicodeBytes = unicode.GetBytes(kor);
        int[] bits = new int[unicodeBytes.Length];
        for (int i = 0; i < unicodeBytes.Length; i++){
            bits[i]=(int)unicodeBytes[i];
        }
        return bits;
    }
     //int[]�� �ѱ���� �ٲ۴�.
    public static string ToKorea(int[] kor) {
        Encoding unicode = Encoding.Unicode;
        byte[] unibyte=new byte[kor.Length];
        for (int i = 0; i < unibyte.Length; i++){
            unibyte[i] = (byte)kor[i];
        }
        char[] uniChars = 
         new char[unicode.GetCharCount(unibyte, 0, unibyte.Length)];
        unicode.GetChars(unibyte, 0, unibyte.Length, uniChars, 0);
        string korstring = new string(uniChars);
        return korstring;
    }
 }
}
