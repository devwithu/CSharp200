using System;
using System.Text;//StringBuilder
namespace Com.JungBo.Fund {
//����Ʈ�� ����Ƽ
public class XMLUtil {
    //5���� ����Ƽ�� ��ȯ
    public static string ToEntity(string strs) {
        StringBuilder sb = new StringBuilder(strs);
        sb.Replace("&", "&amp;");
        sb.Replace(">", "&gt;");
        sb.Replace("<", "&lt;");
        sb.Replace("\"", "&quot;");
        sb.Replace("\'", "&apos;");
        return sb.ToString();
    }
    public static string[] ToFund(string fundstr) {
        char[] deli ={ ','};
        return fundstr.Split(deli);
    }
}//
}
