using System;
namespace Com.JungBo.Logic {
    public class Program{
        public static void Main(string[] args){
            Lotto lotto = new Lotto(45, 6);
            lotto.Make();//ó�� �����
            lotto.Print();
            lotto.ReMake();//���� �����
            lotto.Print();
        }
    }
}
