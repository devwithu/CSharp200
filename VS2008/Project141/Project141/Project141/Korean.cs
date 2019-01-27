using System;
using System.Text;//Encoding
namespace Com.JungBo.Logic{
 public class Korean{
    //�ѱ�� int[]�� �ٲ۴�.
    public static int[] ToBits(string kor) {
        Encoding unicode = Encoding.Unicode;
        //�ѱ�->byte
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
        //int->byte
        for (int i = 0; i < unibyte.Length; i++){
            unibyte[i] = (byte)kor[i];
        }
        //�ѱ۷� �ٲٱ� ���� �ʿ��� byte���ϱ�
        char[] uniChars = new 
    char[unicode.GetCharCount(unibyte, 0, unibyte.Length)];
        //byte->�ѱ�
    unicode.GetChars(unibyte, 0, unibyte.Length, uniChars, 0);
        //char[]�� ���ڿ���
    return new string(uniChars);
    }
 }
}
