using System;
using System.Collections.Generic;
using System.Collections;
namespace Com.JungBo.Logic{
  public class BlackJack{
List<Card> userList = new List<Card>();
List<Card> dealerList = new List<Card>();
private int userSum;
private int dealerSum;
private CardQueue queue = new CardQueue();
public BlackJack(){}

// (Card) BlackJack �� ���� �ε���
public Card this[int index]{
    get {
        if (userList.Count > index && 0 <= index){
            return userList[index];
        }
        else{
            throw new Exception("������ ������ϴ�.");
        }
    }
}// indexer

//Plat BlackJack
public void Play(){
    //ī�� �����
    queue.MakeCards();
    userList.Clear();    //����� ī�� ��� ����
    dealerList.Clear();  // ���� ī�� ��� ����
    // 1. ����ڰ� ī�带 �޴´�.
    MakeUserOne();
    // 2. ������ ī�带 �޴´�.
    MakeDealerOne();
    // 3. ����ڰ� ī�带 �޴´�.
    MakeUserOne();
    // 4. ������ ����Ѵ�.
    PrintUsers();
    PrintUserSum();
    PrintDealers();            
    // 4. ������ ���� ���θ� �Է¹޴´�.
    KeepGoing();

}//Init

// ������ ���� ����
private void KeepGoing(){
    string str = "----- Keep going??? Yes or"+
        "No.\r\nPress y or n, please. -----";
    Console.WriteLine("\r\n{0}",str);
    string keepGoingStr = Console.ReadLine().Trim();
    if (keepGoingStr == "y" || keepGoingStr == "Y"){
        MakeUserOne();
        PrintUsers();
        PrintUserSum();
        if (userSum > 21){
            Console.WriteLine("Game Over: User Lose!!!");
            Environment.Exit(0);
        }
        // Yes �̸� ���
        KeepGoing();
    }
    else{
        // ���� �����
        // ������ ī�带 userList.Count - 1 ��ŭ, ī�带 �޾Ƽ� 
        // ���� ���ϰ� ���� �� �¸��ڸ� ����Ѵ�.
        for (int i = 0; i <= userList.Count - dealerList.Count; i++){
            MakeDealerOne();
            if (dealerSum > 21){
                PrintDealers();
                PrintDealerSum();
                Console.WriteLine("Game Over: Dealer Lose!!!");                        
                Environment.Exit(0);
            }
        }
        Console.WriteLine("\r\nWho is going to win???");
        PrintUsers();
        PrintUserSum();
        PrintDealers();
        PrintDealerSum();         
        // ���� �̰������?
        if (userSum == dealerSum)
            Console.WriteLine("Result: Draw...");
        else if (userSum > dealerSum)
            Console.WriteLine("Result: User Win!!!");
        else
            Console.WriteLine("Result: Dealer Win!!!");
    }
}     
// ����� ī�带 �ϳ� �����.
public void MakeUserOne(){
    MakeOne(userList);
    UserSum();
}

// ���� ī�带 �ϳ� �����.
public void MakeDealerOne(){
    MakeOne(dealerList);
    DealerSum();
}
// ī�� ������ �����.
public void MakeOne(List<Card> list){
    list.Add(queue.NextCard());
}// Make        

// ������� ���� ����Ѵ�.
public void PrintUserSum(){
    Console.Write("\tUserSum: {0}\r\n", userSum);
}
// Dealer ���� ����Ѵ�.
public void PrintDealerSum(){
    Console.Write("\tDealerSum: {0}\r\n", dealerSum);
}
public void UserSum(){
    userSum = SumValue(userList);
}
public void DealerSum(){
    dealerSum = SumValue(dealerList);
}
public int SumValue(List<Card> list){
    CardValue cv = null;
    int tmpSum = 0;
    foreach (Card c in list){
        cv = new CardValue(c);
        tmpSum += cv.CardVal;                
    }
    // aCount üũ
    for (int i = 0; i < cv.ACount; i++){
        string msg = "\r\n----- Which value??? 1 or 11???" +
            " \r\nPress a number what you want. -----";
        Console.WriteLine(msg);
        int whichOne = int.Parse(Console.ReadLine().Trim());
        tmpSum += whichOne;
    }
    return tmpSum;
}
// ����� ī�带 ����Ѵ�.
public void PrintUsers(){
    Console.Write("User Cards: ");
    Print(userList);
}
// ���� ī�带 ����Ѵ�.
public void PrintDealers(){
    Console.Write("Dealer Cards: ");
    Print(dealerList);
}
// ��¿�
public void Print(List<Card> list){
    int i = 0;
    foreach (Card c in list){
        i++;
        Console.Write(c);
        if (i % 10 == 0){
            Console.WriteLine();
        }
    }
}//Print
  }//class
}//namespace
