using System;
using System.Collections;//ArrayList
namespace Com.JungBo.Maths{
    //indexer
    public class ZLists{

        private ArrayList list = new ArrayList();
        //list�ȿ� �� ��� ����
        public ZLists() {
            list.Clear();
        }
        //list�� ���Ҽ� z �߰��ϱ�
        public void Add(Z z) {
            list.Add(z);
        }
        //list�� �ִ� ���Ҽ� z ����
        public void Remove(Z z) {
            list.Remove(z);
        }
        //list�� index��° ����
        public void RemoveAt(int index) {
            list.RemoveAt(index);
        }
        //�ε���
        public Z this[int index] {
            //get �ε���
            get {
                return list[index] as Z;
            }
            //set �ε���
            set {
                this.Add(value);   
            }
        }
        //list�� z�� ������ ���� �ִ°�?
        public bool Contains(Z z) {
            return list.Contains(z);
        }
        //list�� �ִ� ���Ҽ� ���
        public void PrintZList() {
            foreach (Z zvar in list){
                Console.WriteLine(zvar);
            }
        }
        //list�� �ִ� ���Ҽ� ����
        public int Count {
            get { return list.Count; }
        }
    }
}
