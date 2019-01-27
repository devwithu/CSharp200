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

// (Card) BlackJack 에 대한 인덱서
public Card this[int index]{
    get {
        if (userList.Count > index && 0 <= index){
            return userList[index];
        }
        else{
            throw new Exception("범위를 벗어났습니다.");
        }
    }
}// indexer

//Plat BlackJack
public void Play(){
    //카드 만들기
    queue.MakeCards();
    userList.Clear();    //사용자 카드 모두 제거
    dealerList.Clear();  // 딜러 카드 모두 제거
    // 1. 사용자가 카드를 받는다.
    MakeUserOne();
    // 2. 딜러가 카드를 받는다.
    MakeDealerOne();
    // 3. 사용자가 카드를 받는다.
    MakeUserOne();
    // 4. 정보를 출력한다.
    PrintUsers();
    PrintUserSum();
    PrintDealers();            
    // 4. 게임을 지속 여부를 입력받는다.
    KeepGoing();

}//Init

// 게임의 지속 여부
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
        // Yes 이면 계속
        KeepGoing();
    }
    else{
        // 게임 종료시
        // 딜러의 카드를 userList.Count - 1 만큼, 카드를 받아서 
        // 합을 구하고 비교한 후 승리자를 출력한다.
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
        // 누가 이겼을까요?
        if (userSum == dealerSum)
            Console.WriteLine("Result: Draw...");
        else if (userSum > dealerSum)
            Console.WriteLine("Result: User Win!!!");
        else
            Console.WriteLine("Result: Dealer Win!!!");
    }
}     
// 사용자 카드를 하나 만든다.
public void MakeUserOne(){
    MakeOne(userList);
    UserSum();
}

// 딜러 카드를 하나 만든다.
public void MakeDealerOne(){
    MakeOne(dealerList);
    DealerSum();
}
// 카드 한장을 만든다.
public void MakeOne(List<Card> list){
    list.Add(queue.NextCard());
}// Make        

// 사용자의 합을 출력한다.
public void PrintUserSum(){
    Console.Write("\tUserSum: {0}\r\n", userSum);
}
// Dealer 합을 출력한다.
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
    // aCount 체크
    for (int i = 0; i < cv.ACount; i++){
        string msg = "\r\n----- Which value??? 1 or 11???" +
            " \r\nPress a number what you want. -----";
        Console.WriteLine(msg);
        int whichOne = int.Parse(Console.ReadLine().Trim());
        tmpSum += whichOne;
    }
    return tmpSum;
}
// 사용자 카드를 출력한다.
public void PrintUsers(){
    Console.Write("User Cards: ");
    Print(userList);
}
// 딜러 카드를 출력한다.
public void PrintDealers(){
    Console.Write("Dealer Cards: ");
    Print(dealerList);
}
// 출력용
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
