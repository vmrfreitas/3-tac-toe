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
    private int[] stateCheckValues = new int[8];

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
        for(int i=0; i<8; i++){
            if(stateCheckValues[i]==3){
                return 1;
            } else if(stateCheckValues[i]==-3){
                return -1;
            }
        }
        return 0;
    }

    public void updateGameStatus(){
        int stateCheckIndex = 0;
        int newTileValue = 0;
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                newTileValue += gameState[i,j];
                
            }
            if(stateCheckValues[stateCheckIndex] != newTileValue){
                stateCheckValues[stateCheckIndex] = newTileValue;
            }
            newTileValue = 0;
            stateCheckIndex++;
        }
        
        for(int j=0; j<3; j++){
            for(int i=0; i<3; i++){
                newTileValue += gameState[i,j];
            }
            if(stateCheckValues[stateCheckIndex] != newTileValue){
                stateCheckValues[stateCheckIndex] = newTileValue;
            }
            newTileValue = 0;
            stateCheckIndex++;
        }

        for(int i=0; i<3; i++){
            newTileValue += gameState[i,i];
            if(stateCheckValues[stateCheckIndex] != newTileValue){
                stateCheckValues[stateCheckIndex] = newTileValue;
            }
        }
        stateCheckIndex++;
        newTileValue = 0;
        for(int i=0; i<3; i++){
            newTileValue += gameState[i, 2-i];
            if(stateCheckValues[stateCheckIndex] != newTileValue){
                stateCheckValues[stateCheckIndex] = newTileValue;
            }
        }

    }
}
