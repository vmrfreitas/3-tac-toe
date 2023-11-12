using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickOatMovesCalculator : PossibleMovesCalculator
{
    public List<(Vector2, int)> calculate(BoardState boardState, bool isMin) {
        List<(Vector2, int)> moves = new();
        int moveValue;
        if(isMin){
            moveValue = 10;
            for(int i=0; i<3; i++){
                for(int j=0; j<3; j++){
                    if(boardState.BoardMatrix[i,j]==1 && !isItPreviousTile(boardState, new Vector2Int(i,j), isMin)){
                        moves.Add((new Vector2(i,j), 11));
                    } else if(boardState.BoardMatrix[i,j]==0){
                        moves.Add((new Vector2(i,j), moveValue));
                    }
                }
            }
        } else {
            moveValue = 1;
            for(int i=0; i<3; i++){
                for(int j=0; j<3; j++){
                    if(boardState.BoardMatrix[i,j]==10 && !isItPreviousTile(boardState, new Vector2Int(i,j), isMin)){
                        moves.Add((new Vector2(i,j), 11));
                    } else if(boardState.BoardMatrix[i,j]==0){
                        moves.Add((new Vector2(i,j), moveValue));
                    }
                }
            }
        }
        return moves;
    }

    private bool isItPreviousTile(BoardState boardState, Vector2Int tileCoord, bool isMin){
        if(isMin){
            if(tileCoord.x == boardState.previousPlayerPlay.x && tileCoord.y == boardState.previousPlayerPlay.y){
                return true;
            } else {
                return false;
            }
        } else {
            if(tileCoord.x == boardState.previousOtherPlayerPlay.x && tileCoord.y == boardState.previousOtherPlayerPlay.y){
                return true;
            } else {
                return false;
            }
        }
    }
}
