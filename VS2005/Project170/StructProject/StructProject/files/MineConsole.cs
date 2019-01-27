using System;
namespace Com.JungBo.Games{
    public class MineConsole{
        Block[,] board;
        Position[] pos;
        int boardsize = 20;
        int mine = 20;
        public MineConsole() { InitMine();  }

        // 보드를 초기화 한다.
        private void InitMine(){
            board = new Block[boardsize, boardsize];// 블록
            pos = new Position[mine];  // 지뢰 위치 저장
            for (int i = 0; i < boardsize; i++){
                for (int j = 0; j < boardsize; j++){
                    board[i, j].bState = BombState.EMPTY;
                    board[i, j].oState = OpenState.CLOSE;
                    board[i, j].down = false;
                }
            }
            SetMine(); // 지뢰 셋팅
            CalMine();  // 보드 계산
        }
        // 지뢰를 랜덤으로 설치한다.
        private void SetMine() {
            Random r = new Random();
            int count = 0;
            int row = 0;
            int col = 0;

            while (true){
                if (count == mine) break;
                row = r.Next(boardsize);
                col = r.Next(boardsize);
                if (board[row, col].bState != BombState.BOMB){
                    pos[count].row = row;
                    pos[count].col = col;
                    count++;
                    board[row, col].bState = BombState.BOMB;
                }
            }
        }
        // 지뢰 주변의 숫자 계산
        private void CalMine(){
            for (int t = 0; t < mine; t++){
                int x = pos[t].row;
                int y = pos[t].col;
                for (int i = x - 1; i <= x + 1; i++){
                  for (int j = y - 1; j <= y + 1; j++){
                      //자신이 폭탄이 아니고 경계밖에 있지 않다면
                      if (i >= 0 && j >= 0 && i <= (boardsize - 1) &&
                         j <= (boardsize - 1) &&
                         board[i, j].bState != BombState.BOMB)
                         board[i, j].bState++;
                  }
                }
            }
        }
        //폭탄을 설치하고, 주변의 폭탄 계산하고
        public void Make(){
            SetMine();
            CalMine();
        }
        //지뢰게임 화면에 보이기
        public void Print() {
            for (int i = 0; i < boardsize; i++){
                for (int j = 0; j < boardsize; j++){
                    //2자로 출력 enum을 int로 변환해서
                    Console.Write("{0,2} ",(int)(board[i,j].bState));
                }
                Console.WriteLine();
            }
        }

    }

}
