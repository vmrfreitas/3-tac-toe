using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultBoardStateChecker : BoardStateChecker
{
    public int check(BoardState boardState, bool forReal) {
        if(boardState.TurnNum<5){
            return 0;
        }

        if(boardState.DiagonalSums[0] == 3 || boardState.DiagonalSums[1] == 3){
            if(forReal){
                Debug.Log("player won");
            }
            boardState.gameOver = true;
            return 1;
        }else if(boardState.DiagonalSums[0]==-3 || boardState.DiagonalSums[1]==-3){
            if(forReal){
                Debug.Log("computer won");
            }
            boardState.gameOver = true;
            return -1;
        }

        for(int i=0; i<3; i++){
            if(boardState.LineSums[i]==3 || boardState.ColumnSums[i]==3){
                if(forReal){
                    Debug.Log("player won");
                }
                boardState.gameOver = true;
                return 1;
            } else if(boardState.LineSums[i]==-3 || boardState.ColumnSums[i]==-3){
                if(forReal){
                    Debug.Log("computer won");
                }
                boardState.gameOver = true;
                return -1;
            }
        }
        
        if (boardState.TurnNum == 9){
            if(forReal){
                Debug.Log("its a tie!");
            }
            boardState.gameOver = true;
            return 0;
        }
        return 0;
    }
}
