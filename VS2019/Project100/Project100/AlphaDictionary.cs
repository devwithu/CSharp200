using System;
using System.Collections;
namespace Com.JungBo.Logic{
public class AlphaDictionary{
    Hashtable table = new Hashtable(10);
    public AlphaDictionary() { 
        table.Clear(); //해쉬테이블 청소
    }
    public void Add(string key, string meaning) {
        table.Add(key, meaning);//추가하기
    }
    public void Delete(string key) {
        table.Remove(key);//지우기
    }
    public int Count() {
        return table.Count;// 해쉬테이블 엘리먼트 개수
    }
    public string[] Keys() {
        string[]keys=new string[table.Count];
        int i=0;
        //해쉬테이블의 키값들을 배열로
        foreach (string key in table.Keys){
            keys[i++] = key;
        }
        return keys;
    }
    public string this[string key] {
        get {
            //해쉬테이블에 키값이 있다면
            if (table.ContainsKey(key)){
            //if (table.Contains(key)){
                return table[key] as string;
            }
            else {
                throw new Exception(
                string.Format("{0}을 찾지못했습니다.",key));
            }
        }
    }
}
}
