using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Maths {
    public class Strings {
        public void StringM() {
            string s1 = " Good Morning. ";
            string s2 = s1.ToUpper();
            string s3 = s1.ToLower();
            string s4 = s1.PadLeft(20, '-');
            string s5 = s1.PadRight(20, '-');
            string s6 = s1.Remove(5);
            string s7 = s1.Remove(5, 8);
            string s8 = s1.Trim();
            string s9 = s1.TrimEnd();
            string s10 = s1.TrimStart();
            string s11 = s1.Replace('G', 'S');
            string s12 = s1.Substring(5);
            string s13 = s1.Substring(5, 8);
            string s14 = s1.Insert(2, "uu");
           
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine(s9);
            Console.WriteLine(s10);
            Console.WriteLine(s11);
            Console.WriteLine(s12);
            Console.WriteLine(s13);
            Console.WriteLine(s14);


            bool s15 = s1.Contains("o");
            int s16 = s1.IndexOf('o');  //"o"
            int s17 = s1.LastIndexOf("r");
            int s18 = s1.Length;
            Console.WriteLine(s15);
            Console.WriteLine(s16);
            Console.WriteLine(s17);
            Console.WriteLine(s18);
            char[] cc ={' '};
            string[] s19 = s1.Trim().Split(cc);
            
            for (int i = 0; i < s19.Length; i++)
            {
                Console.WriteLine("--"+s19[i]);
            }
            char[] c = s1.Trim().ToCharArray();
            string ss = new string(c);

        }



        public void Show() {
            string s1 = "Good";
            string s2 = string.Concat(s1," Morning");
            string s3 = string.Copy(s1);//s3=s1;
            string s4 = string.Format("{0,15}",s1);
            string s5 = string.Format("{0:C}",3308);
            string cc ="&";
            string[] keys ={ "name","age","addr"};
            string[] values ={ "hong", "14", "seoul" };
            string[] keyval = new string[3];
            string ss = "Hello.aspx?";
            for (int i = 0; i < 3; i++){
               // keyval[i] = keys[i] + "=" + values[i];
              keyval[i] = string.Concat(keys[i],"=",values[i]);
            }
            string sss = string.Join(cc,keyval);
            ss += sss;
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(ss); 
        }
    }
}
