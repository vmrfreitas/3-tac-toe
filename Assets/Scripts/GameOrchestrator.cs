using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

public class GameOrchestrator : MonoBehaviour
{
    private ComputerMoveCalculatorFactory computerMoveCalculatorFactory;
    private ComputerMoveCalculator computerMoveCalculator;
    private GameUpdateValidator gameUpdateValidator;
    private BoardStateChecker boardStateChecker;
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
            Debug.Log("validated\n");
            (Vector2, int) computerMove = computerMoveCalculator.calculate(boardState);
            //Debug.Log(computerMove);
            checkAndUpdateStateAndOptions(true, (int)computerMove.Item1.x, (int)computerMove.Item1.y, computerMove.Item2);
        }
    }

    public void updateTileMove(Vector2Int tileCoord, int moveValue, bool playerTurn){
        if(!GameOptions.GameOver){
            checkAndUpdateStateAndOptions(playerTurn, tileCoord.x, tileCoord.y, moveValue);
        }
    }

    private void checkAndUpdateStateAndOptions(bool playerTurn, int x, int y, int moveValue){
        previousBoardMatrix = (int[,])boardState.BoardMatrix.Clone();
        boardState.BoardMatrix[x, y] += moveValue;
        BoardStateUpdater.update(boardState, x, y);
        boardStateChecker.check(boardState, true);
        GameOptions.PlayerTurn = playerTurn;
        boardState.playerTurn = playerTurn;
        GameOptions.AnimationPlaying = true;
    }

    public (int, int) getTileValues(Vector2Int tileCoord) {
        return (boardState.BoardMatrix[tileCoord.x, tileCoord.y], previousBoardMatrix[tileCoord.x, tileCoord.y]);
    } 
}
 