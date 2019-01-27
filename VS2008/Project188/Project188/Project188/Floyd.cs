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
            //p1~p5 경로, 1000 충분히 큰 수
            data = new int[,] { { 0,2,3,1000,7},
                                {5,0,1000,1000,4 },
                                {2,1000,0,6,1000 }, 
                                {1000,1000,3,0,4}, 
                                {6,1,6,2,0 } };
            p = new int[data.GetLength(0), data.GetLength(0)];
            name=new string[]{"P1","P2","P3","P4","P5"};
        }
        //Floyd 알고리즘을 이용하여 최단경로의 
        //비용과 함께 최단경로를 구하는 함수
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
        //최단경로 중간 경유지 출력,q출발지,r도착지
        public void Path(int q, int r){
            if (p[q, r] != -1) {
                Path(q, p[q, r]);
                Console.Write("{0} -> ", name[p[q, r]]);
                Path(p[q, r], r);
            }
        }
        //모든 경로를 출력 해주는 함수
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
