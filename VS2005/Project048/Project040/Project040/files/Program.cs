using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            int nums = 123;//-123
            object on = nums;//�ڽ�
            int count = (int)on;//��ڽ�
            
            BitOper bits = new BitOper();
            bits.TenToBinary(nums);
            string str=bits.TenToBinary();
            Console.WriteLine("{0}�� ��������:{1}", nums, str);
            //Console.WriteLine("12345678901234567890123456789012");
            //Console.WriteLine("{0}", str);
        }
    }
}
