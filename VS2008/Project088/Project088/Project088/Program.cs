using System;
using System.Collections;  //반드시 using한다.
namespace Com.JungBo.Basic
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            Hashtable table = new Hashtable();
            Queue que = new Queue();
            Stack stack = new Stack();
            //청소
            list.Clear(); table.Clear(); que.Clear(); stack.Clear();
            for (int i = 0; i < 26; i++)
            {
                list.Add(((char)(i + 'A')) + "");
                table.Add(i, ((char)(i + 'A')) + "");//키가 0~25
                que.Enqueue(((char)(i + 'A')) + "");
                stack.Push(((char)(i + 'A')) + "");

            }
            Print(list); Console.Write("엘리먼트 개수: {0}\n", list.Count);
            Print(que); Console.Write("엘리먼트 개수: {0}\n", que.Count);
            Print(stack); Console.Write("엘리먼트 개수: {0}\n", stack.Count);

            //인덱서를 이용하기
            string msg1 = list[5] as string; //인덱스 5
            Console.Write("{0}  엘리먼트 개수: {1}\n", msg1, list.Count);
            string msg4 = table[5] as string;  //키 5
            Console.Write("{0}  엘리먼트 개수: {1}\n", msg4, table.Count);

            //인덱스를 사용못함 다음, 다음~~~만 사용
            string msg2 = que.Dequeue() as string;
            Console.Write("{0}  엘리먼트 개수: {1}\n", msg2, que.Count);
            string msg3 = stack.Pop() as string;
            Console.Write("{0}  엘리먼트 개수: {1}\n", msg3, stack.Count);
        }

        public static void Print(ICollection colect)
        {
            foreach (string str in colect)
            {
                Console.Write("{0} ", str);
            }
            Console.WriteLine();
        }//
    }
}
