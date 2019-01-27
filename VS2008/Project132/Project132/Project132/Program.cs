using System;
using Com.Jungbo.Logic;
namespace EratoscheApp
{
    public class EratoscheMain
    {
        public static void Main(string[] args)
        {
            //2~ 2^6 (64)까지의 소수
            EratosTenesChe eratos = new EratosTenesChe(3);
            eratos.ReMake();
            eratos.PrintErotos();
        }
    }
}
