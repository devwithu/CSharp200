using System;
namespace Com.JungBo.Exc{
    //����ڰ� ���� ����
    public class UnFittalbeException:ApplicationException{
        public UnFittalbeException(string message)
        :base(message){ }

        public UnFittalbeException()
        :this("0�̳� ������ �ü� �����ϴ�."){ }
    }
}
