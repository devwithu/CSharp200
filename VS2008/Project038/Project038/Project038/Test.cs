using System;
namespace Com.JungBo.Basic {

    public class Test{
        public void Show() {
            string s = "Good Morning 효니";
            int[] cNum=new int[s.Length];
            for (int i = 0; i < s.Length; i++){
			 cNum[i]=char.ConvertToUtf32(s,i);
			}
            for (int i = 0; i < cNum.Length; i++)
            {
                Console.Write("{0} ", cNum[i]);
            }
            Console.WriteLine();
            string sss=char.ConvertFromUtf32(cNum[0]);
            Console.WriteLine(sss);
            Console.WriteLine(char.IsPunctuation('.'));//문장부호
            Console.WriteLine(char.IsPunctuation(','));
            Console.WriteLine(char.IsPunctuation('\''));
            Console.WriteLine(char.IsPunctuation(' '));
            Console.WriteLine(char.IsPunctuation('\"'));
            Console.WriteLine(char.IsSeparator('\r'));
            Console.WriteLine(char.IsNumber('4'));
            Console.WriteLine(char.IsDigit('9'));
            Console.WriteLine(char.IsWhiteSpace('\t'));
            //char.IsUpper
            //char.IsLetter
            //char.IsLower
            //char.IsNumber
            //char.IsDigit
            //char.IsLetterOrDigit
            //char.IsWhiteSpace
            //char.ToLower
            //char.ToUpper
            //char.ToString
        }
    }
}
