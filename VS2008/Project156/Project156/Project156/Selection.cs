using System;
namespace Com.JungBo.Sorts{
  public class Selection{
    public static  void SelectSort(int[] select){
        int count = select.Length;
        int min=0;//�ּҰ�
        int minindex=0;//�ּҰ� ��ġ
        SortUtil.Print(select);//���� ���� ����
        for (int i = 0; i < count - 1; i++){
                minindex = i;
                min = select[i];
            for (int j = i + 1; j < count; j++){
                if (min > select[j]){
                    min = select[j];//�ּҰ�
                    minindex = j;//�ּҰ� ��ġ
                }
            }
          //i��° ���� �ּҰ��� �����Ѵ�.
          SortUtil.Swap(ref select[i],ref select[minindex]);
          SortUtil.Print(select);
        }
    }
      public static void SelectSort<T>(T[] select) 
                                where T : IComparable{
        int count = select.Length;
        T min ;//�ּҰ�
        int minindex = 0;//�ּҰ� ��ġ
        SortUtil.Print(select);//���� ���� ����
        for (int i = 0; i < count - 1; i++){
            minindex = i;
            min = select[i];
            for (int j = i + 1; j < count; j++){
                if (min.CompareTo(select[j])>0){
                    min = select[j];//�ּҰ�
                    minindex = j;//�ּҰ� ��ġ
                }
            }
          //i��° ���� �ּҰ��� �����Ѵ�.
          SortUtil.Swap(ref select[i], ref select[minindex]);
          SortUtil.Print(select);
        }
    }
  }
}
