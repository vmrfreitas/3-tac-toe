using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WildMovesCalculator : PossibleMovesCalculator
{
    public List<(Vector2, int)> calculate(BoardState boardState, bool isMin) {
        List<(Vector2, int)> moves = new();
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(boardState.BoardMatrix[i,j]==0){
                    moves.Add((new Vector2(i,j), 1));
                    moves.Add((new Vector2(i,j), -1));
                }
            }
        }
        return moves;
    }
}
