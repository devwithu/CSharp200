using System;
using System.Collections;
namespace Com.JungBo.Logic{
public class AlphaDictionary{
    Hashtable table = new Hashtable(10);
    public AlphaDictionary() { 
        table.Clear(); //�ؽ����̺� û��
    }
    public void Add(string key, string meaning) {
        table.Add(key, meaning);//�߰��ϱ�
    }
    public void Delete(string key) {
        table.Remove(key);//�����
    }
    public int Count() {
        return table.Count;// �ؽ����̺� ������Ʈ ����
    }
    public string[] Keys() {
        string[]keys=new string[table.Count];
        int i=0;
        //�ؽ����̺��� Ű������ �迭��
        foreach (string key in table.Keys){
            keys[i++] = key;
        }
        return keys;
    }
    public string this[string key] {
        get {
            //�ؽ����̺� Ű���� �ִٸ�
            if (table.ContainsKey(key)){
            //if (table.Contains(key)){
                return table[key] as string;
            }
            else {
                throw new Exception(
                string.Format("{0}�� ã�����߽��ϴ�.",key));
            }
        }
    }
}
}
