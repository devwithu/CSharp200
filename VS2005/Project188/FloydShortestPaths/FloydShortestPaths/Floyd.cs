using System;
namespace Com.JungBo.Logic{
    public class Floyd{
        private int[,] data;
        private int[,] p;
        public string[] name;
        public Floyd(){
            Init();        
        }
        public void Init(){
            //p1~p5 ���, 1000 ����� ū ��
            data = new int[,] { { 0,2,3,1000,7},
                                {5,0,1000,1000,4 },
                                {2,1000,0,6,1000 }, 
                                {1000,1000,3,0,4}, 
                                {6,1,6,2,0 } };
            p = new int[data.GetLength(0), data.GetLength(0)];
            name=new string[]{"P1","P2","P3","P4","P5"};
        }
        //Floyd �˰����� �̿��Ͽ� �ִܰ���� 
        //���� �Բ� �ִܰ�θ� ���ϴ� �Լ�
        public void Distance(){
            for (int i = 0; i < data.GetLength(0); i++){
                for (int j = 0; j < data.GetLength(0); j++){
                    p[i, j] = -1;
                }
            }
            for (int k = 0; k < data.GetLength(0); k++) {
                for (int i = 0; i < data.GetLength(0); i++){
                    for (int j = 0; j < data.GetLength(0); j++){
                        if (data[i, j] > data[i, k] + data[k, j]){
                            p[i, j] = k;
                            data[i, j] = data[i, k] + data[k, j];
                        }
                    }
                }
            }
        }//
        //�ִܰ�� �߰� ������ ���,q�����,r������
        public void Path(int q, int r){
            if (p[q, r] != -1) {
                Path(q, p[q, r]);
                Console.Write("{0} -> ", name[p[q, r]]);
                Path(p[q, r], r);
            }
        }
        //��� ��θ� ��� ���ִ� �Լ�
        public void PrintPath(){
            int count = data.GetLength(0);
            for (int i = 0; i < count; i++){
                for (int j = 0; j < count; j++){
                    Console.Write("{0}\t", data[i,j]);
                }
                Console.WriteLine();
            }
        }//
    }//class Floyd
}//namespace
