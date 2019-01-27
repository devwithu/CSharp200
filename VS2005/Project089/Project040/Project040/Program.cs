using System;
using Com.JungBo.Logic;
namespace Com.JungBo.Basic{
    public class Program{
        public static void Main(string[] args){
            //���� Ű���� ����(��)
            string[,] dickey ={{"go","����, (���Ϸ�) ����"},
        {"eat","�Դ�, �ı��ϴ�"},{"kill","���̴�"}};
            AlphaDictionary adic = new AlphaDictionary();
            //������ ����ܾ� �����ϱ�
            adic.Add(dickey[0, 0], dickey[0, 1]);
            adic.Add(dickey[1, 0], dickey[1, 1]);
            adic.Add(dickey[2, 0], dickey[2, 1]);
            //�ε��� adic[i]���
            Console.WriteLine(adic["go"]);  //Ű����  go
            string mean = adic["kill"];//Ű����  kill
            Console.WriteLine(mean);

            string[] keys = adic.Keys();//��� Ű�� ������
            foreach (string key in keys){
                Console.WriteLine("{0} : {1}",key, adic[key]);
            }
        }
    }
}
