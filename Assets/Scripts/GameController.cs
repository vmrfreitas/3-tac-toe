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
    private int[] lineSums = new int[3];
    private int[] columnSums = new int[3];
    private int[] diagonalSums = new int[2];
    public int[,] gameState = new int[3, 3];
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int checkGameState(){
        for(int i=0; i<3; i++){
            if(lineSums[i]==3 || columnSums[i]==3){
                return 1;
            } else if(lineSums[i]==-3 || columnSums[i]==-3){
                return -1;
            }
        }
        if(diagonalSums[0] == 3 || diagonalSums[1] == 3){
            return 1;
        }else if(diagonalSums[0]==-3 || diagonalSums[1]==-3){
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
}
