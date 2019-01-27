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
        //������ �迭�� �����ִ� �޼��� 
        public int[] Ball()
        {
            return ball;
        }
        //{4,6,1,8,7,9} ���� ����  5���ϸ� false
        //6�� ���ϸ� true 
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
        //���ϴ� ���� �迭 ����� 
        private void Make()
        {
            int count = 0;
            while (true)
            {
                int b = (r.Next(num2) );
                // Math.random()  0<=n<1 �Ǽ�
                if (!IsSame(ball, b))
                {
                    ball[count++] = b;
                }
                if (count == num2) { break; }
            }
        }
        //���ο� �迭 ����� 
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
        //�迭 �ʱ�ȭ 
        public void Inits(int[] input, int inNum)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = inNum;
            }
        }

    }

}
