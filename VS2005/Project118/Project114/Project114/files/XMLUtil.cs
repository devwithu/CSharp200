using System;
using System.Text;//StringBuilder
namespace Com.JungBo.Fund {
//컨텐트의 엔터티
public class XMLUtil {
    //5개의 엔터티로 변환
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
