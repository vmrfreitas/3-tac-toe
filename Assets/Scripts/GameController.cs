using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject game;
    public Sprite xSprite;
    public Sprite oSprite;
    public bool playerTurn;
    public bool gameOver;
    private int[] lineSums = new int[3];
    private int[] columnSums = new int[3];
    private int[] diagonalSums = new int[2];
    public int[,] gameState = new int[3, 3];
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int checkGameState(bool forReal){
        for(int i=0; i<3; i++){
            if(lineSums[i]==3 || columnSums[i]==3){
                return 1;
            } else if(lineSums[i]==-3 || columnSums[i]==-3){
                return -1;
            }
        }
        if(diagonalSums[0] == 3 || diagonalSums[1] == 3){
            if(forReal){
                Debug.Log("player won");
                gameOver = true;
            }
            return 1;
        }else if(diagonalSums[0]==-3 || diagonalSums[1]==-3){
            if(forReal){
                Debug.Log("computer won");
                gameOver = true;
            }
            return -1;
        }
        return 0;
    }

    public void updateGameStatus(int x, int y){
        lineSums[x] = 0;
        for(int i=0; i<3; i++){
            lineSums[x] += gameState[x, i];
        }

        columnSums[y] = 0;
        for(int i=0; i<3; i++){
            columnSums[y] += gameState[i, y];
        }

        if (x==y || x==(2-y)){
            diagonalSums[0] = 0;
            for(int i=0; i<3; i++){
                diagonalSums[0] += gameState[i, i];
            }

            diagonalSums[1] = 0;
            for(int i=0; i<3; i++){
                diagonalSums[1] += gameState[i, 2-i];
            }
        } 
    }

    public Vector2 makeAIPlay(){

        int [,] oldGameState = (int[,])gameState.Clone();
        var minReturn = minValue();
        gameState = oldGameState;
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                this.updateGameStatus(i,j);
            }
        }
        return minReturn.Item2;
    }

    private (int, Vector2) maxValue(){
        var utilityValue = this.checkGameState(false); 
        if(utilityValue != 0){
            return (utilityValue, new Vector2());
        }
        Vector2 returnMove = new Vector2();
        int value = int.MinValue;
        var possibleMoves = this.possibleMoves();
        foreach(Vector2 move in possibleMoves){
            this.makeMoveInGame(move,1);
            (int value2, Vector2 move2) = minValue();
            if(value2>value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }

    private (int, Vector2) minValue(){
        var utilityValue = this.checkGameState(false); 
        if(utilityValue != 0){
            return (utilityValue, new Vector2());
        }

        Vector2 returnMove = new Vector2();
        int value = int.MaxValue;
        var possibleMoves = this.possibleMoves();
        foreach(Vector2 move in possibleMoves){
            this.makeMoveInGame(move,-1);
            (int value2, Vector2 move2) = maxValue();
            if(value2<value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }


    private List<Vector2> possibleMoves(){
        List<Vector2> moves = new List<Vector2>();
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(gameState[i,j]==0){
                    moves.Add(new Vector2(i,j));
                }
            }
        }
        return moves;
    }

    private int[,] makeMoveInGame(Vector2 move, int moveValue){
        gameState[(int)move.x, (int)move.y] = moveValue;
        this.updateGameStatus((int)move.x, (int)move.y);
        return gameState;
    }
}
