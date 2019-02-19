using System;
using Com.JungBo.Logic;

namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //사전 키값과 설명(값)
            string[,] dickey ={{"go","가다, (…하러) 가다"},
        {"eat","먹다, 파괴하다"},{"kill","죽이다"}};
            AlphaDictionary adic = new AlphaDictionary();
            //사전에 영어단어 대입하기
            adic.Add(dickey[0, 0], dickey[0, 1]);
            adic.Add(dickey[1, 0], dickey[1, 1]);
            adic.Add(dickey[2, 0], dickey[2, 1]);
            //인덱서 adic[i]사용
            Console.WriteLine(adic["go"]);  //키값이  go
            string mean = adic["kill"];//키값이  kill
            Console.WriteLine(mean);

            string[] keys = adic.Keys();//모든 키값 얻어오기
            foreach (string key in keys)
            {
                Console.WriteLine("{0} : {1}", key, adic[key]);
            }
        }
    }
}