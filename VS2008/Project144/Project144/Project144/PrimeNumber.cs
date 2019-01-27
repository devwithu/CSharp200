using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic {
    public class PrimeNumber
    {
        public static bool IsPrime(int n)
        {
            bool isP = true;
            for (int i = 2; i <= (int)(Math.Sqrt(n)); i++)
            {
                if (n % i == 0)
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }//
        public static void PrintPrime(int n)
        {
            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {//IsPrime(i)==true 동일
                    Console.Write("{0}\t", i);
                    count++; //count=count+1과 동일
                }
            }
            Console.WriteLine();
            Console.WriteLine("2부터 {0}까지 약수: {1}개",
                n, count);
        }
	    
        //각 자리수의 합 123-> 6
        public static int SumOfNum(int num)
        {
            char[] cn = num.ToString().ToCharArray();
		    int total=0;
		    for(int i=0;i<cn.Length;i++){
			    total+=(cn[i]-'0');
		    }
		    return total;
	    }//
        //소인수분해
        public static void PrintOfDivision(int num)
        {
		    int i=2;
		    while(num!=1){
    			
			    if(num%i==0){
				    if(num/i==1){
					    Console.WriteLine("{0}",i);
    					
				    }else{
					    Console.Write("{0} X ",i);
				    }
				    num/=i;
			    }else{
				    i++;	
			    }
		    }
	    }//
        public static void PrintOfDivisions(int startNum, int endNum)
        {
            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write("{0}= ", i); PrintOfDivision(i);

            }
        }
        //소인수 분해 후 각자리수합 -> 2*17 -> 2+1+7
        public static int SumOfDivision(int num)
        {
		    int i=2;
		    int total=0;
		    while(num!=1){
			    if(num%i==0){
				    total+=SumOfNum(i);
				    num/=i;
			    }else{
				    i++;	
			    }
		    }
		    return total;
	    }//
        //스미스 수
        public static  void PrintOfSmith(int startNum, int endNum)
        {
		    for(int i=startNum;i<=endNum;i++){
                if (!IsPrime(i) && (SumOfNum(i) == SumOfDivision(i)))
                {
				    Console.Write("{0}= ",i);PrintOfDivision(i);
			    }
		    }
	    }
       
 /*메르센 소수
 3, 7, 31, 127, 8191, 131071, 524287,2147483647
 */
        public static  void PrintMersenne()
        {
	        int i=2;
	        int j=1;
	        int merse=1;
            while (merse<int.MaxValue){
		        merse=(int)Math.Pow(2,i)-1;

                Console.Write("{0}:\t ", i);
                if (IsPrime(merse))
                {
                    Console.WriteLine(
                    "{0}번째 메르센 소수 : 2^{1}-1={2}", j, i, merse);
                    j++;
                }
                else
                {
                    Console.Write("{0}= ", merse);
                    PrintOfDivision(merse);
                }
                i++;
	        }
        }//


        public static void PrintTwinPrime(int startNum, int endNum)
        {
		    for(int i=startNum;i<=endNum;i++){
                if (IsPrime(i) &&IsPrime(i + 2))
                {
                    Console.WriteLine("({0},{1})",i,(i+2));
			    }
		    }
	    }
        public static void PrintCousinPrime(int startNum, int endNum)
        {
		    for(int i=startNum;i<=endNum;i++){
                if (IsPrime(i) && IsPrime(i + 4))
                {
				    Console.WriteLine("({0},{1})",i,(i+4));
			    }
		    }
	    }
        public static void PrintSexyPrime(int startNum, int endNum)
        {//or Six Prime
		    for(int i=startNum;i<=endNum;i++){
                if (IsPrime(i) && IsPrime(i + 6))
                {
				    Console.WriteLine("({0},{1})",i,(i+6));
			    }
		    }
	    }
        public static void PrintThrimePrime(int startNum, int endNum)
        {//or Three Six Prime
		    for(int i=startNum;i<=endNum;i++){
                if (IsPrime(i) && IsPrime(i + 6) && IsPrime(i + 12))
                {
                    Console.WriteLine("({0},{1},{2})", i, (i + 6), (i + 12));
			    }
		    }
	    }

       
    }
}
