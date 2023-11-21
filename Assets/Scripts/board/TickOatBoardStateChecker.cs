using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickOatBoardStateChecker : BoardStateChecker
{
    public int check(BoardState boardState, bool forReal) {
        if(boardState.TurnNum<6){
            return 0;
        }

        if(boardState.DiagonalSums[0] == 33 || boardState.DiagonalSums[1] == 33){
            if(boardState.playerTurn){
                if(forReal){
                    GameOptions.whoWon = 0;
                    //Debug.Log("player won");
                    GameOptions.GameOver = true;
                }
                
                boardState.gameOver = true;
                return 1;
            } else {
                if(forReal){
                    GameOptions.whoWon = 1;
                    //Debug.Log("computer won");
                    GameOptions.GameOver = true;
                }
                boardState.gameOver = true;
                return -1;
            }
        }

        for(int i=0; i<3; i++){
            if(boardState.LineSums[i]==33 || boardState.ColumnSums[i]==33){
                if(boardState.playerTurn){
                    if(forReal){
                        GameOptions.whoWon = 0;
                        //Debug.Log("player won");
                        GameOptions.GameOver = true;
                    }
                    boardState.gameOver = true;
                    return 1;
                } else {
                    if(forReal){
                        GameOptions.whoWon = 1;
                        //Debug.Log("computer won");
                        GameOptions.GameOver = true;
                    }
                    boardState.gameOver = true;
                    return -1;
                }
            }
        }
        return 0;
    }
}
