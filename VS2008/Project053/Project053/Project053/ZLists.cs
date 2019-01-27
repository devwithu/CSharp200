using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;//ArrayList

namespace Com.JungBo.Maths{
    //indexer
    public class ZLists{

        private ArrayList list = new ArrayList();

        public ZLists() {
            list.Clear();//list�ȿ� �� ��� ����
        }

        public void Add(Z z) {
            list.Add(z);
        }

        public void Remove(Z z) {
            list.Remove(z);
        }
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

        public bool Contains(Z z) {
            return list.Contains(z);
        }

        public void PrintZList() {
            foreach (Z zvar in list){
                Console.WriteLine(zvar);
            }
        }

        public int Count {
            get { return list.Count; }
        }
    }
}
