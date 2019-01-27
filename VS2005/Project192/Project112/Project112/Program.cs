using System;
using System.Collections.Generic;
using System.Text;
using Com.JungBo.Fund;
namespace Project112 {
    public class Program {
        public static void Main(string[] args){
            FunXmlTransform fxt = new FunXmlTransform();
            string xml = "../../fund.xml";
            string xsl = "../../fund.xslt";
            string html = "../../fund.html";
            fxt.TransToHtml(xml, xsl, html);
        }
    }
}
