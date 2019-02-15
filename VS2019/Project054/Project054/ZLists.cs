using System;
using System.Collections;//ArrayList
namespace Com.JungBo.Maths
{
    //indexer
    public class ZLists
    {

        private ArrayList list = new ArrayList();
        //list안에 것 모두 제거
        public ZLists()
        {
            list.Clear();
        }
        //list에 복소수 z 추가하기
        public void Add(Z z)
        {
            list.Add(z);
        }
        //list에 있는 복소수 z 제거
        public void Remove(Z z)
        {
            list.Remove(z);
        }
        //list의 index번째 삭제
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
        //인덱서
        public Z this[int index]
        {
            //get 인덱서
            get
            {
                return list[index] as Z;
            }
            //set 인덱서
            set
            {
                this.Add(value);
            }
        }
        //list에 z와 동일한 것이 있는가?
        public bool Contains(Z z)
        {
            return list.Contains(z);
        }
        //list에 있는 복소수 출력
        public void PrintZList()
        {
            foreach (Z zvar in list)
            {
                Console.WriteLine(zvar);
            }
        }
        //list에 있는 복소수 개수
        public int Count
        {
            get { return list.Count; }
        }
    }
}
