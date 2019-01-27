using System;
namespace FundProject {
    public class FundData {
        private string fundName;
        private int fundPrice;
        private int prevPrice;//음수면 전날보다 내려감

        public string FundName{
            get { return fundName; }
            set { fundName = value; }
        }
        public int FundPrice{
            get { return fundPrice; }
            set { fundPrice = value; }
        }
        public int PrevPrice{
            get { return prevPrice; }
            set { prevPrice = value; }
        }

        public  FundData(string fundName, int fundPrice, int prevPrice){
            this.fundName = fundName;
            this.fundPrice = fundPrice;
            this.prevPrice = prevPrice;
        }

        public  FundData(string fundName, string sfundPrice, string sprevPrice){
            this.fundName = fundName;
            this.fundPrice = int.Parse(sfundPrice.Trim().Replace(",",""));
            this.prevPrice = int.Parse(sprevPrice.Trim().Replace(",", ""));
        }
        public override string ToString(){
            string s = string.Format("[{0}/{1}/{2}]"
                ,fundName,fundPrice,prevPrice);
            return s;
        }
    }
}
