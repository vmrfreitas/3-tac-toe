using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TickOatMovesCalculator : PossibleMovesCalculator
{
    public List<(Vector2, int)> calculate(int[,] boardMatrix, bool isMin) {
        List<(Vector2, int)> moves = new();
        int moveValue;
        if(isMin){
            moveValue = 10;
            for(int i=0; i<3; i++){
                for(int j=0; j<3; j++){
                    if(boardMatrix[i,j]==1){
                        moves.Add((new Vector2(i,j), 11));
                    } else if(boardMatrix[i,j]==0){
                        moves.Add((new Vector2(i,j), moveValue));
                    }
                }
            }
        } else {
            moveValue = 1;
            for(int i=0; i<3; i++){
                for(int j=0; j<3; j++){
                    if(boardMatrix[i,j]==1){
                        moves.Add((new Vector2(i,j), 11));
                    } else if(boardMatrix[i,j]==0){
                        moves.Add((new Vector2(i,j), moveValue));
                    }
                }
            }
        }
        return moves;
    }
}
