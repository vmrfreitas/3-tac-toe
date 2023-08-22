using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultMovesCalculator : PossibleMovesCalculator
{
    public List<Vector2> calculate(int[,] boardMatrix) {
        List<Vector2> moves = new();
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(boardMatrix[i,j]==0){
                    moves.Add(new Vector2(i,j));
                }
            }
        }
        return moves;
    }
}
