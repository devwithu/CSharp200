using System;
using System.Collections;  //�ݵ�� using�Ѵ�.
namespace Com.JungBo.Basic{
 public class Program{
  public static void Main(string[] args){

    ArrayList list = new ArrayList();
    Hashtable table = new Hashtable();
    Queue que = new Queue();
    Stack stack = new Stack();
    //û��
    list.Clear();table.Clear(); que.Clear();  stack.Clear();
    for (int i = 0; i < 26; i++){
        list.Add(((char)(i+'A'))+"");
        table.Add(i, ((char)(i + 'A')) + "");//Ű�� 0~25
        que.Enqueue(((char)(i + 'A')) + "");
        stack.Push(((char)(i + 'A')) + "");
        
    }
    Print(list); Console.Write("������Ʈ ����: {0}\n",list.Count);
    Print(que); Console.Write("������Ʈ ����: {0}\n", que.Count);
    Print(stack); Console.Write("������Ʈ ����: {0}\n", stack.Count);

    //�ε����� �̿��ϱ�
    string msg1 = list[5] as string; //�ε��� 5
    Console.Write("{0}  ������Ʈ ����: {1}\n",msg1, list.Count);
    string msg4 = table[5] as string;  //Ű 5
    Console.Write("{0}  ������Ʈ ����: {1}\n", msg4, table.Count);

    //�ε����� ������ ����, ����~~~�� ���
    string msg2 = que.Dequeue() as string;
    Console.Write("{0}  ������Ʈ ����: {1}\n", msg2, que.Count);
    string msg3 = stack.Pop() as string;
    Console.Write("{0}  ������Ʈ ����: {1}\n", msg3, stack.Count);
    }

    public static void Print(ICollection colect) {
    foreach (string str in colect){
        Console.Write("{0} ", str);
    }
    Console.WriteLine();
  }//
 }
}
