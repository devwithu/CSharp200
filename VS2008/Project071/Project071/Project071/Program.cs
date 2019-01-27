using System;
using Com.JungBo.Maths;
using Com.JungBo.Exc;    //UnFittalbeException
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Fraction fr1 = new Fraction(3, 6);
            Console.WriteLine(fr1);
            fr1.Bunja = 7;
            fr1.Bunmo = 9;
            Console.WriteLine(fr1);
            //복사생성자
            Fraction fr2 = new Fraction(fr1);
            Console.WriteLine(fr2);
            try
            {
                Fraction fr3 = new Fraction(4, 0);
                Console.WriteLine(fr3);
                //fr2.Bunmo = 0;
                Console.WriteLine(fr2);
            }
            catch (UnFittalbeException ee)
            {
                Console.WriteLine("1-{0}:", ee.Message);
                Console.WriteLine("2-{0}:", ee.Source);
                Console.WriteLine("3-{0}:", ee.StackTrace);
                Console.WriteLine("4-{0}:", ee.ToString());
                Console.WriteLine("5-{0}:", ee.InnerException);
                Console.WriteLine("6-{0}:", ee.HelpLink);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
    }
}
