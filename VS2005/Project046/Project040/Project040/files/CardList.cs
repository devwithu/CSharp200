using System;
using System.Collections;   //ArrayList ������ using
namespace Com.JungBo.Logic{
  public class CardList{
    // ī�� ���� (�� > �� > �� > ��)
    public  string[] DECK ={ "S","D","H","C"};
    public  string[] SUIT 
 ={ "A","2","3","4","5","6","7","8","9","T","J","Q","K" };

    //�߿��� ������ ���
    ArrayList list = new ArrayList(10);//Capacity 10
    public void MakeCard() {
        list.Clear();//list ����
        foreach (string deck in DECK){
            foreach (string suit in SUIT){
                //SA,S2, S3, .... ����
                //list�� ä���
                list.Add(string.Concat(deck,suit));
            }
        }
    }//
    //12���� ��� 12���� 4��
    public void PrintCard() {
        //list�� �ִ� string ���� Count
        for (int i = 0; i < list.Count; i++){
            //list�ȿ� ���� object�� ���θ��
            //�׷��Ƿ� ĳ���� �ʿ� as
            string cards = list[i] as string;
            Console.Write("{0}  ",cards);
            if((i+1)%SUIT.Length==0){//12����
                Console.WriteLine();
            }
        }
    }
    //list �յڷ� �ٲٱ�
    public void ReverseCard() {
        list.Reverse();
    }
    public string[]  ToArray(){
        //ArrayList ������Ʈ�� object[]�� 
        object[] objs = list.ToArray();
        //�迭�� ũ�� objs.Length
        string [] strs=new string[objs.Length];
        //ArrayList ������� string���� ĳ����
        for (int i = 0; i < objs.Length; i++){
            strs[i] = objs[i] as string;
        }
        return strs;
    }
    public int IndexOf(string str) {
        return list.IndexOf(str);
    }
    public void Sort(){
        //���ĺ�-���ڷ� ����
        list.Sort();
    }
  }//class
}//namespace
