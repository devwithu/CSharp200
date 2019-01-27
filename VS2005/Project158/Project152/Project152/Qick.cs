using System;
namespace Com.JungBo.Sorts{
 public class Quick{
  private static void QuickSort(int[] nums,int start,int end){
    int left = start;
    int right = end;
    int mid = nums[(start + end) / 2];
    do{
        
        //A
        while ((nums[left] < mid) && (left < end)){
            left++;
        }
        while ((mid < nums[right]) && (right > start)){
            right--;
        }
        Console.WriteLine("A:  {0}-{1}",left,right);
        //B
        if (left <= right){
            SortUtil.Swap(ref nums[left], ref nums[right]);
            SortUtil.Print(nums);
            left++;
            right--;
        }
        Console.WriteLine("B:  {0}-{1}", left, right);
    } while (left < right);
    //C
    if (start < right){
        QuickSort(nums, start, right);
    }
    //D
    if (left < end){
        QuickSort(nums, left, end);
    }
  }
  public static void QuickSort(int[] a){
    QuickSort(a, 0, a.Length - 1);
  }
  private static void QuickSort<T>(T[] nums, 
             int start, int end)  where T : IComparable{
     int left = start;
     int right = end;
     T mid = nums[(start + end) / 2];
     do{
         SortUtil.Print<T>(nums);
         while ((nums[left].CompareTo( mid)<0)&&(left<end)){
             left++;
         }
         while ((mid.CompareTo(nums[right]))<0&&(right>start)){
             right--;
         }
         if (left <= right){
             SortUtil.Swap(ref nums[left], ref nums[right]);
             left++;
             right--;
         }
     } while (left < right);
     if (start < right){
         QuickSort<T>(nums, start, right);
     }
     if (left < end){
         QuickSort<T>(nums, left, end);
     }
  }
  public static void QuickSort<T>(T[] a)
                            where T : IComparable{
     QuickSort<T>(a, 0, a.Length - 1);
  }
 }//Quick
}
