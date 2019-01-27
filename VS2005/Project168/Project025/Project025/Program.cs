using System;
namespace Com.JungBo.Logics{
    public class Program{
        public static void Main(string[] args){
            BitOperator bitopp = new BitOperator();
            int ten = 123;
            bitopp.MakeTo2(ten);
            bitopp.Show2();
            bitopp.MakeTo8(ten);
            bitopp.Show8();
            bitopp.MakeTo16(ten);
            bitopp.Show16();
        }
    }
}
