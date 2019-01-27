using System;
namespace Com.JungBo.Basic{
    public class Program{
        //as
        public static void Main(string[] args){
            string ss = "Hello! My name is Su-mi";
            object obj = ss;//프로모션
            //as는 타입이 틀리면 null이 됨
            string tt = obj as string;//참조타입만 캐스팅
            Console.WriteLine(tt);
            //아래 소스와 동일
            if(obj is string){//인스턴스의 타입
                string ts = (string)obj;//캐스팅
                Console.WriteLine(ts);
            }
            object obj1 = 23;
            //int s = obj1 as int; //언박싱은 as 사용불가
            int s = (int)obj1;  //언박싱은 캐스팅함
            Console.WriteLine(s);
        }
    }
}
