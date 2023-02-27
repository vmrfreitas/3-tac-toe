using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

public class GameController : MonoBehaviour
{
    public GameObject game;
    public Sprite xSprite;
    public Sprite oSprite;
    public bool playerTurn;
    public GameState globalGameState = new GameState();
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        globalGameState.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public (int, GameState) checkGameState(GameState gameState, bool forReal){
        for(int i=0; i<3; i++){
            if(gameState.lineSums[i]==3 || gameState.columnSums[i]==3){
                if(forReal){
                    Debug.Log("player won");
                }
                gameState.gameOver = true;
                return (1, gameState);
            } else if(gameState.lineSums[i]==-3 || gameState.columnSums[i]==-3){
                if(forReal){
                    Debug.Log("computer won");
                }
                gameState.gameOver = true;
                return (-1, gameState);
            }
        }
        if(gameState.diagonalSums[0] == 3 || gameState.diagonalSums[1] == 3){
            if(forReal){
                Debug.Log("player won");
            }
            gameState.gameOver = true;
            return (1, gameState);
        }else if(gameState.diagonalSums[0]==-3 || gameState.diagonalSums[1]==-3){
            if(forReal){
                Debug.Log("computer won");
            }
            gameState.gameOver = true;
            return (-1, gameState);
        }

        bool tie = true;
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(gameState.gameMatrix[i,j]==0){
                    tie = false; 
                }
            }
        }
        if (tie){
            if(forReal){
                Debug.Log("its a tie!");
            }
            gameState.gameOver = true;
            return (0, gameState);
        }
        return (0, gameState);
    }

    public GameState updateGameState(GameState gameState, int x, int y){
        gameState.lineSums[x] = 0;
        for(int i=0; i<3; i++){
            gameState.lineSums[x] += gameState.gameMatrix[x, i];
        }

        gameState.columnSums[y] = 0;
        for(int i=0; i<3; i++){
            gameState.columnSums[y] += gameState.gameMatrix[i, y];
        }

        if (x==y || x==(2-y)){
            gameState.diagonalSums[0] = 0;
            for(int i=0; i<3; i++){
                gameState.diagonalSums[0] += gameState.gameMatrix[i, i];
            }

            gameState.diagonalSums[1] = 0;
            for(int i=0; i<3; i++){
                gameState.diagonalSums[1] += gameState.gameMatrix[i, 2-i];
            }
        }
        return gameState;
    }

    public Vector2 makeAIPlay(){
        //int [,] oldGameState = (int[,])gameState.Clone();
        GameState localGameState = globalGameState.clone();
        //localGameState.columnSums[0] = 100;
        (var uselessValue, var minReturn) = minValue(localGameState);
        //gameState = oldGameState;
        //for(int i=0; i<3; i++){
        //    this.updateGameState(i,0);
        //}
        //for(int i=0; i<3; i++){
        //    this.updateGameState(0,i);
        //}
        //gameOver = false;
        return minReturn;
    }

    private (int, Vector2) maxValue(GameState gameState){
        int utilityValue;
        (utilityValue, gameState) = this.checkGameState(gameState, false); 
        if(gameState.gameOver){
            //gameOver = false;
            return (utilityValue, new Vector2());
        }
        Vector2 returnMove = new Vector2();
        int value = int.MinValue;
        var possibleMoves = this.possibleMoves(gameState.gameMatrix);
        foreach(Vector2 move in possibleMoves){
            gameState = this.makeMoveInGame(gameState, move, 1);
            (int value2, Vector2 move2) = minValue(gameState.clone());
            if(value2>value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }

    private (int, Vector2) minValue(GameState gameState){
        int utilityValue;
        (utilityValue, gameState) = this.checkGameState(gameState, false); 
        if(gameState.gameOver){
            //gameOver = false;
            return (utilityValue, new Vector2());
        }

        Vector2 returnMove = new Vector2();
        int value = int.MaxValue;
        var possibleMoves = this.possibleMoves(gameState.gameMatrix);
        foreach(Vector2 move in possibleMoves){
            gameState = this.makeMoveInGame(gameState, move, -1);
            (int value2, Vector2 move2) = maxValue(gameState.clone());
            if(value2<value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }


    private List<Vector2> possibleMoves(int[,] gameMatrix){
        List<Vector2> moves = new List<Vector2>();
        for(int i=0; i<3; i++){
            for(int j=0; j<3; j++){
                if(gameMatrix[i,j]==0){
                    moves.Add(new Vector2(i,j));
                }
            }
        }
        return moves;
    }

    private GameState makeMoveInGame(GameState gameState, Vector2 move, int moveValue){
        gameState.gameMatrix[(int)move.x, (int)move.y] = moveValue;
        gameState = this.updateGameState(gameState, (int)move.x, (int)move.y);
        return gameState;
    }

    public class GameState {
		public int[,] gameMatrix;
        public int[] lineSums;
        public int[] columnSums;
        public int[] diagonalSums;
        public bool gameOver;

		public GameState() {
			gameMatrix = new int[3, 3];
			lineSums = new int[3];
            columnSums = new int[3];
            diagonalSums = new int[2];
            gameOver = false;
		}

        public GameState clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<GameState>(serialized);
        }
	}
}
 