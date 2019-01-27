using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic{
public class Card{
    private string cardValue; //카드값을 저장
    public Card(string msg) {
        List<string> decklist = new List<string>(CardDictionary.DECK);
        List<string> suitlist = new List<string>(CardDictionary.SUIT);
        //H8에서 H가 decklist에 있는가, 8이 suitlist에 있는가 확인
        if (decklist.Contains(msg[0].ToString()) &&
            suitlist.Contains(msg[1].ToString()))
        {
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
}
}
