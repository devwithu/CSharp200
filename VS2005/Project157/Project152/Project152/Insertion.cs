using System;
namespace Com.JungBo.Sorts{
 public class Insertion{
    public static void InsertSort(int[] a){
        for (int i = 0; i < a.Length; i++){
            int temp = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > temp){
                a[j + 1] = a[j];
                j--;
            }
            a[j + 1] = temp;
            SortUtil.Print(a);
        }
    }//
    public static void InsertSort<T>(T[] a)
                                 where T : IComparable{
        for (int i = 0; i < a.Length; i++){
            T temp = a[i];
            int j = i - 1;
            while (j >= 0 && a[j].CompareTo(temp) > 0){
                a[j + 1] = a[j];
                j--;
            }   
            a[j + 1] = temp;
            SortUtil.Print<T>(a);
        }
    }//
 }//Insertion
}
