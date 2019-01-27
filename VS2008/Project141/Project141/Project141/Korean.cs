using System;
using System.Text;//Encoding
namespace Com.JungBo.Logic{
 public class Korean{
    //한국어를 int[]로 바꾼다.
    public static int[] ToBits(string kor) {
        Encoding unicode = Encoding.Unicode;
        //한글->byte
        byte[] unicodeBytes = unicode.GetBytes(kor);
        int[] bits = new int[unicodeBytes.Length];
        for (int i = 0; i < unicodeBytes.Length; i++){
            bits[i]=(int)unicodeBytes[i];
        }
        return bits;
    }
     //int[]을 한국어로 바꾼다.
    public static string ToKorea(int[] kor) {
        Encoding unicode = Encoding.Unicode;
        byte[] unibyte=new byte[kor.Length];
        //int->byte
        for (int i = 0; i < unibyte.Length; i++){
            unibyte[i] = (byte)kor[i];
        }
        //한글로 바꾸기 위해 필요한 byte구하기
        char[] uniChars = new 
    char[unicode.GetCharCount(unibyte, 0, unibyte.Length)];
        //byte->한글
    unicode.GetChars(unibyte, 0, unibyte.Length, uniChars, 0);
        //char[]을 문자열로
    return new string(uniChars);
    }
 }
}
