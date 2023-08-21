using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WildMovesCalculator : PossibleMovesCalculator
{
    public List<Vector2> calculate() {
        /*
        List<Vector2> moves = new List<Vector2>();
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(gameMatrix[i,j]==0){
                    moves.Add(new Vector2(i,j));
                }
            }
        }
        return moves;*/
        return new List<Vector2>();
    }
}
