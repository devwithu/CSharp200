using System;
namespace Com.JungBo.Logic{
 public class Recursion{
    //팩토리얼
    public static double Fact(double n){
        if (n == 1.0 || n == 0.0){
            return 1.0;
        }
        else{
            return n * Fact(n - 1);
        }
    }//
    //피보나치수열
    public static double Pivo(double n) {
        if (n == 1.0 || n == 2.0){
            return 1.0;
        }
        else {
            return Pivo(n - 1) + Pivo(n - 2);
        }
    }//
    public static double Golden(double n) {
        return Pivo(n) / Pivo(n+1);
    }
    public static void ShowFact(){
        for (int i = 1; i <= 20; i++){
         Console.WriteLine("{0,30:F}",Fact(i));
        }
    }//
    //ShowPivo
    public static void ShowPivo(){
        for (int i = 3; i < 40; i++){
            Console.WriteLine(Pivo(i));
        }
    }//
    //ShowGolden
    public static void ShowGolden() {
        for (int i = 3; i < 40; i++){
            Console.WriteLine(Golden(i));
        }
    }//
    //nPr=(n - r + 1) x nPr_1
    public static int Permutation(int n, int r){
        if (r == 0){
            return 1;
        }
        else{
            return (n - r + 1)*Permutation(n, r - 1);
        }
    }//Permutation

    //nCr=(n - r + 1)/r x nCr_1
     public static int Combinatiion(int n, int r){
        if (r == 0){
            return 1;
        }
        else{
            return (n - r + 1) * Combinatiion(n, r - 1) / r;
        }
    }//Permutation
 }
}
