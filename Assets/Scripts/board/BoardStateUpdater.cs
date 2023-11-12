using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class BoardStateUpdater
{
    public static void update(BoardState boardState, BoardState previousBoardState, int x, int y){ //confia, eu vo ter q mandar o previous e somar o matrix(atual) - matrix(previous)
        boardState.TurnNum++;
        var addValue = boardState.BoardMatrix[x, y] - previousBoardState.BoardMatrix[x,y];
        boardState.LineSums[x] += addValue;
        boardState.ColumnSums[y] += addValue;
        if (x==y){
            boardState.DiagonalSums[0] += addValue;
        }
        if(x==(2-y)){
            boardState.DiagonalSums[1] += addValue;
        }
    }
}
