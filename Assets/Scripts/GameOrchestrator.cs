using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using UnityEditor.Rendering;

public class GameOrchestrator : MonoBehaviour
{
    private ComputerMoveCalculatorFactory computerMoveCalculatorFactory;
    private ComputerMoveCalculator computerMoveCalculator;
    private GameUpdateValidator gameUpdateValidator;
    private BoardStateChecker boardStateChecker;
    public Choice choice;
    public GameObject game;
    public Sprite xSprite;
    public Sprite oSprite;
    public bool playerTurn;
    public bool animationPlaying;
    private BoardState boardState = new();
    private int[,] previousBoardMatrix;
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        // ideally this would go in a GameOrchestratorAssembler to separate the creation responsability from the orchestration
        // but I'm not really sure how unity would deal with assembling a MonoBehaviour class outside of the scene
        if(GameOptions.GameType == GameType.WildTicTacToe){
            choice.transform.gameObject.SetActive(true);
        }
        previousBoardMatrix = new int[3, 3];
        computerMoveCalculatorFactory = new ComputerMoveCalculatorFactory();
        (computerMoveCalculator, boardStateChecker) = computerMoveCalculatorFactory.make();
        gameUpdateValidator = new GameUpdateValidator(new List<GameUpdateValidationRule> {
            new GameOverValidationRule(),
            new PlayerTurnValidationRule(),
            new AnimationPlayingValidationRule(),
            new SinglePlayerValidationRule()
         });
        boardState.playerTurn = true;
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameUpdateValidator.validate()){
            //Debug.Log("validated\n");
            (Vector2, int) computerMove = computerMoveCalculator.calculate(boardState);
            checkAndUpdateStateAndOptions(false, (int)computerMove.Item1.x, (int)computerMove.Item1.y, computerMove.Item2);
        }
    }

    public void updateTileMove(Vector2Int tileCoord, int moveValue, bool playerTurn){
       
        if(!GameOptions.GameOver){
            checkAndUpdateStateAndOptions(playerTurn, tileCoord.x, tileCoord.y, moveValue);
        }
    }

    public bool isItPreviousTile(Vector2Int tileCoord){
        if(GameOptions.PlayerTurn){
            if(tileCoord.x == boardState.previousOtherPlayerPlay.x && tileCoord.y == boardState.previousOtherPlayerPlay.y){
                return true;
            } else {
                return false;
            }
        } else {
            if(tileCoord.x == boardState.previousPlayerPlay.x && tileCoord.y == boardState.previousPlayerPlay.y){
                return true;
            } else {
                return false;
            }
        }
    }

    public bool isItPlayerPreviousTile(Vector2Int tileCoord){
       if(tileCoord.x == boardState.previousPlayerPlay.x && tileCoord.y == boardState.previousPlayerPlay.y){
                return true;
            } else {
                return false;
            }
    }

    public bool isItOtherPlayerPreviousTile(Vector2Int tileCoord){
        if(tileCoord.x == boardState.previousOtherPlayerPlay.x && tileCoord.y == boardState.previousOtherPlayerPlay.y){
                return true;
            } else {
                return false;
            }
    }

    private void checkAndUpdateStateAndOptions(bool playerTurn, int x, int y, int moveValue){
        if(playerTurn){
            boardState.previousPlayerPlay.Set(x,y);
        } else {
            boardState.previousOtherPlayerPlay.Set(x,y);
        }
        
        var previousBoardState = boardState.clone();
        boardState.playerTurn = playerTurn;
        previousBoardMatrix = (int[,])boardState.BoardMatrix.Clone();
        boardState.BoardMatrix[x, y] = moveValue;
        BoardStateUpdater.update(boardState, previousBoardState, x, y);
        //Debug.Log("we updated the tile to = " + boardState.BoardMatrix[x, y] + "; coordinates are = " + x + ", " + y 
        //+", now is it player's turn? " + boardState.playerTurn + ", and the middle column sum is: " + boardState.ColumnSums[1]);
        boardStateChecker.check(boardState, true);
        GameOptions.AnimationPlaying = true;
        GameOptions.changedTileCoord = new Vector2Int(x, y);
        GameOptions.tileValueChanged = true;
        GameOptions.PlayerTurn = !playerTurn;
        boardState.playerTurn = !playerTurn;
    }

    public (int, int) getTileValues(Vector2Int tileCoord) {
        return (boardState.BoardMatrix[tileCoord.x, tileCoord.y], previousBoardMatrix[tileCoord.x, tileCoord.y]);
    } 
}
 