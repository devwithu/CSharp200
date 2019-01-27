using System;
namespace Com.JungBo.Exc{
    //사용자가 만든 예외
    public class UnFittalbeException:ApplicationException{
        public UnFittalbeException(string message)
        :base(message){ }

        public UnFittalbeException()
        :this("0이나 음수가 올수 없습니다."){ }
    }
}
