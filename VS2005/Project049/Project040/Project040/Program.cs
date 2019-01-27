using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int nums = -1028;
            
            BitOper bits = new BitOper();
            bits.TenToBinary(nums);
            string str=bits.TenToBinary();
            Console.WriteLine("{0}을 이진수로:{1}", nums, str);
        }
    }
}
