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
    public bool animationPlaying;
    public GameState globalGameState = new GameState();
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!animationPlaying){
            if(!playerTurn){
                if(!globalGameState.gameOver){
                    Vector2 aiMove = getAiMove();
                    globalGameState.gameMatrix[(int)aiMove.x, (int)aiMove.y] = -1;
                    updateGameState(globalGameState, (int)aiMove.x, (int)aiMove.y);
                    checkGameState(globalGameState, true);
                    playerTurn = true;
                    animationPlaying = true;
                }
            }
        }
    }

    public int checkGameState(GameState gameState, bool forReal){
        if(gameState.turnNum<5){
            return 0;
        }

        if(gameState.diagonalSums[0] == 3 || gameState.diagonalSums[1] == 3){
            if(forReal){
                Debug.Log("player won");
            }
            gameState.gameOver = true;
            return 1;
        }else if(gameState.diagonalSums[0]==-3 || gameState.diagonalSums[1]==-3){
            if(forReal){
                Debug.Log("computer won");
            }
            gameState.gameOver = true;
            return -1;
        }

        for(int i=0; i<3; i++){
            if(gameState.lineSums[i]==3 || gameState.columnSums[i]==3){
                if(forReal){
                    Debug.Log("player won");
                }
                gameState.gameOver = true;
                return 1;
            } else if(gameState.lineSums[i]==-3 || gameState.columnSums[i]==-3){
                if(forReal){
                    Debug.Log("computer won");
                }
                gameState.gameOver = true;
                return -1;
            }
        }
        
        if (gameState.turnNum == 9){
            if(forReal){
                Debug.Log("its a tie!");
            }
            gameState.gameOver = true;
            return 0;
        }
        return 0;
    }

    public void updateGameState(GameState gameState, int x, int y){
        gameState.turnNum++;
        gameState.lineSums[x] += gameState.gameMatrix[x, y];
        gameState.columnSums[y] += gameState.gameMatrix[x, y];
        if (x==y){
            gameState.diagonalSums[0] += gameState.gameMatrix[x, y];
        }
        if(x==(2-y)){
            gameState.diagonalSums[1] += gameState.gameMatrix[x, y];
        }
    }

    public Vector2 getAiMove(){
        GameState localGameState = globalGameState.clone();
        (var uselessValue, var aiMove) = minValue(localGameState);
        return aiMove;
    }

    private (int, Vector2) maxValue(GameState gameState){
        int utilityValue = this.checkGameState(gameState, false); 
        if(gameState.gameOver){
            return (utilityValue, new Vector2());
        }
        Vector2 returnMove = new Vector2();
        int value = int.MinValue;
        var possibleMoves = this.possibleMoves(gameState.gameMatrix);
        foreach(Vector2 move in possibleMoves){
            var newGameState = gameState.clone();
            this.makeMoveInGame(newGameState, move, 1);
            (int value2, Vector2 move2) = minValue(newGameState);
            if(value2 == 1){ // pruning
                return (value2, move);
            }
            if(value2>value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }

    private (int, Vector2) minValue(GameState gameState){
        int utilityValue = this.checkGameState(gameState, false); 
        if(gameState.gameOver){
            return (utilityValue, new Vector2());
        }

        Vector2 returnMove = new Vector2();
        int value = int.MaxValue;
        var possibleMoves = this.possibleMoves(gameState.gameMatrix);
        foreach(Vector2 move in possibleMoves){
            var newGameState = gameState.clone();
            this.makeMoveInGame(newGameState, move, -1);
            (int value2, Vector2 move2) = maxValue(newGameState);
            if(value2 == -1){ // pruning
                return (value2, move);
            }
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

    private void makeMoveInGame(GameState gameState, Vector2 move, int moveValue){
        gameState.gameMatrix[(int)move.x, (int)move.y] = moveValue;
        this.updateGameState(gameState, (int)move.x, (int)move.y);
    }

    public class GameState {
		public int[,] gameMatrix;
        public int[] lineSums;
        public int[] columnSums;
        public int[] diagonalSums;
        public int turnNum;
        public bool gameOver;

		public GameState() {
			gameMatrix = new int[3, 3];
			lineSums = new int[3];
            columnSums = new int[3];
            diagonalSums = new int[2];
            turnNum = 0;
            gameOver = false;
		}

        public GameState clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<GameState>(serialized);
        }
	}
}
 