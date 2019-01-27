using System;

namespace SixTeenWindows
{
    public class Lotto
    {
        private int[] ball;
        private int num2;
        System.Random r;
        public Lotto(int num2)
        {

            this.num2 = num2;
            r = new Random();
            ball = new int[num2];
            Inits(ball, -1);
            Make();
        }
        //생성된 배열을 보여주는 메서드 
        public int[] Ball()
        {
            return ball;
        }
        //{4,6,1,8,7,9} 안의 수와  5비교하면 false
        //6과 비교하면 true 
        private bool IsSame(int[] a, int b)
        {
            bool isS = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b)
                {
                    isS = true;
                    break;
                }
            }
            return isS;
        }
        //원하는 수의 배열 만들기 
        private void Make()
        {
            int count = 0;
            while (true)
            {
                int b = (r.Next(num2) );
                // Math.random()  0<=n<1 실수
                if (!IsSame(ball, b))
                {
                    ball[count++] = b;
                }
                if (count == num2) { break; }
            }
        }
        //새로운 배열 만들기 
        public void Remake(int num2)
        {

            this.num2 = num2;
            ball = new int[num2];
            Inits(ball, -1);
            Make();
        }
        /*remake  overloading*/
        public void Remake()
        {
            Inits(ball, -1);
            Make();
        }
        //배열 초기화 
        public void Inits(int[] input, int inNum)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = inNum;
            }
        }

    }

}
