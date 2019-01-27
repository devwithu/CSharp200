using System;
namespace Com.JungBo.Logic{
    public class MagicFactory{
        public static IMagic Factory(int n) {
            AbstractMagic magic = null;
            if(n==1 || n==2 ){
                string s = string.Format(
                 "{0}X{0} 마방진은 존재하지 않습니다.",n);
                throw new NotMatchMagicException(s);
            }
            else if(n%2==1){
                magic = new OddMagicSquare(n);
            }
            else if (n % 4 == 0){
                magic = new FourMagicSquare(n);
            }
            else if (n % 4 == 2){
                magic = new SixMagicSquare(n);
            }
            return magic;
        }//Factory
    }
}
