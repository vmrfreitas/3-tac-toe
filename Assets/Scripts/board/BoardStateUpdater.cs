using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class BoardStateUpdater
{
    public static void update(BoardState boardState, int x, int y){
        boardState.TurnNum++;
        boardState.LineSums[x] += boardState.BoardMatrix[x, y];
        boardState.ColumnSums[y] += boardState.BoardMatrix[x, y];
        if (x==y){
            boardState.DiagonalSums[0] += boardState.BoardMatrix[x, y];
        }
        if(x==(2-y)){
            boardState.DiagonalSums[1] += boardState.BoardMatrix[x, y];
        }
    }
}
