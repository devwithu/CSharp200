using System;
using System.Collections.Generic;
using System.Text;

namespace Com.JungBo.Logic{
public class Card{
    private string cardValue; //ī�尪�� ����
    public Card(string msg) {
        List<string> decklist = new List<string>(CardDictionary.DECK);
        List<string> suitlist = new List<string>(CardDictionary.SUIT);
        //H8���� H�� decklist�� �ִ°�, 8�� suitlist�� �ִ°� Ȯ��
        if (decklist.Contains(msg[0].ToString()) &&
            suitlist.Contains(msg[1].ToString()))
        {
            this.cardValue = msg;
        }
        else {
            throw new Exception("ī�尡 �������� �Ƚ��ϴ�.");
        }
    }
    public string CardValue{
        get { return cardValue; }
    }
    //string�� Card Ÿ������ �Ͻ��� ����ȯ
    public static implicit operator Card(string msg){
        return new Card(msg);
    }
    //Card Ÿ���� string Ÿ������ ����� ����ȯ
    public static explicit operator string(Card yc){
        return yc.CardValue;
    }
    public override string ToString(){
        return string.Format("[{0}] ", cardValue);
    }
}
}
