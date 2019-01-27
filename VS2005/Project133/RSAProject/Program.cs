using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            Lotto lotto = new Lotto(45, 6);
            lotto.Make();//처음 만들기
            lotto.Print();
            lotto.ReMake();//새로 만들기
            lotto.Print();
        }
    }
}
