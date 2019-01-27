using System;
using System.Collections.Generic;
namespace Com.JungBo.Logic{
public class Card{
    private string cardValue; //카드값을 저장
    public Card(string msg) {

List<string> decklist = new List<string>(CardDictionary.DECK);
List<string> suitlist = new List<string>(CardDictionary.SUIT);
        //H8에서 H가 decklist에 있는가, 8이 suitlist에 있는가 확인
        if (decklist.Contains(msg[0].ToString()) &&
            suitlist.Contains(msg[1].ToString())){
            this.cardValue = msg;
        }
        else {
            throw new Exception("카드가 존재하지 안습니다.");
        }
    }
    public string CardValue{
        get { return cardValue; }
    }
    //string을 Card 타입으로 암시적 형변환
    public static implicit operator Card(string msg){
        return new Card(msg);
    }
    //Card 타입을 string 타입으로 명시적 형변환
    public static explicit operator string(Card yc){
        return yc.CardValue;
    }
    public override string ToString(){
        return string.Format("[{0}] ", cardValue);
    }
    public override bool Equals(object obj){
        Card cc = obj as Card;

        if (cardValue.Equals(cc.CardValue)){
            return true;
        }
        else{
            // if 에서 리턴을 한다면, 
            //else 에서 무조건 리턴해야 한다.
            return false;
        }
    }//override Equals
    // Equals 의 overriding 하면, 
    //자식의 hashcode 도 같이 맞춰줘야 한다. [중요]
    public override int GetHashCode(){
        return cardValue.GetHashCode() + 37;
    }
}
}
