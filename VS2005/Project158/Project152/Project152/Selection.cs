using System;
namespace Com.JungBo.Sorts{
  public class Selection{
    public static  void SelectSort(int[] select){
        int count = select.Length;
        int min=0;//최소값
        int minindex=0;//최소값 위치
        SortUtil.Print(select);//정렬 과정 보기
        for (int i = 0; i < count - 1; i++){
                minindex = i;
                min = select[i];
            for (int j = i + 1; j < count; j++){
                if (min > select[j]){
                    min = select[j];//최소값
                    minindex = j;//최소값 위치
                }
            }
          //i번째 값을 최소값과 스왑한다.
          SortUtil.Swap(ref select[i],ref select[minindex]);
          SortUtil.Print(select);
        }
    }
      public static void SelectSort<T>(T[] select) 
                                where T : IComparable{
        int count = select.Length;
        T min ;//최소값
        int minindex = 0;//최소값 위치
        SortUtil.Print(select);//정렬 과정 보기
        for (int i = 0; i < count - 1; i++){
            minindex = i;
            min = select[i];
            for (int j = i + 1; j < count; j++){
                if (min.CompareTo(select[j])>0){
                    min = select[j];//최소값
                    minindex = j;//최소값 위치
                }
            }
          //i번째 값을 최소값과 스왑한다.
          SortUtil.Swap(ref select[i], ref select[minindex]);
          SortUtil.Print(select);
        }
    }
  }
}
