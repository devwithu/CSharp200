using System;
namespace Com.JungBo.Logic{
    public class AntQuiz{
    //�� �տ� ���ڿ� ���� ���ڰ� ���������� �� �� �����°�
        public int Many(char[] cc) { 
            int count=1;
            for (int i = 1; i < cc.Length; i++){
                if (cc[0] == cc[i]){
                    count++;
                }
                else {
                    break;
                }
            }
            return count;
        }//
        //1121-> �Ǿհ� ���� ���� ���� ���--> "11"
        public string PreString(string nstr) {
            string ns = string.Empty;
            ns = nstr.Substring(0,this.Many(nstr.ToCharArray()));
            return ns;
        }//
        //1121-->NextString(2)  --> "21"
        public string NextString(string nstr){
            string ns = string.Empty;
            ns = nstr.Substring(this.Many(nstr.ToCharArray()));
            return ns;
        }//
        //1121  ==> 12 ,���� ���� ���(1�� 2��)
        public string MakeAnt(string nstr) {
            int count = this.Many(nstr.ToCharArray());
            string ns = nstr[0].ToString() + count.ToString();
            return ns;
        }//
        //1121  --> 122111, ���� �������� �����
        public string Make(string nstr){
            string ns = string.Empty;
            string temp=nstr;
            for (int i = 0; i<temp.Length;   ) {
                
                ns += MakeAnt(nstr);
                i += Many(nstr.ToCharArray());
                nstr = this.NextString(nstr);

            }

            return ns;
        }//
        //4��: 11->12->1121->122111 4��, ���� ��ŭ ���̱�
        public void AntStair(int stairs) {
            string start = "11";
            Console.WriteLine("{0}", start);
            for (int i = 1; i <stairs; i++)
            {
                Console.WriteLine("{0}", start = Make(start));
            }
        }//
    }
}
