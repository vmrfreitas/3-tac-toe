using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardComputerMoveCalc : ComputerMoveCalculator
{
    private PossibleMovesCalculator _possibleMovesCalculator;
    private BoardStateChecker _boardStateChecker;
    private int repetitions = 0;
    
    public HardComputerMoveCalc(PossibleMovesCalculator possibleMovesCalculator, BoardStateChecker boardStateChecker) {
        _possibleMovesCalculator = possibleMovesCalculator;
        _boardStateChecker = boardStateChecker;
    }

    public (Vector2, int) calculate(BoardState boardState) {
        BoardState localBoardState = boardState.clone();
        repetitions = 0;
        (var uselessValue, var aiMove) = minValue(localBoardState);
        //Debug.Log("Number of repetitions: " + repetitions);
        return aiMove;
    }

    private (int, (Vector2, int)) minValue(BoardState boardState){
        repetitions++;
        boardState.playerTurn = true;
        int utilityValue = _boardStateChecker.check(boardState, false); 
        boardState.playerTurn = false;
        if(boardState.gameOver){
            return (utilityValue, (new Vector2(), 0));
        }

        (Vector2, int) returnMove = new();
        int value = int.MaxValue;
        var possibleMoves = _possibleMovesCalculator.calculate(boardState, true);
        foreach((Vector2, int) move in possibleMoves){
            var newBoardState = boardState.clone();
            newBoardState.previousOtherPlayerPlay.Set((int)move.Item1.x, (int)move.Item1.y);
            makeMoveInGame(newBoardState, move);
            (int value2, (Vector2, int) move2) = maxValue(newBoardState);
            if(value2 == -1 || repetitions >= 4000){ // pruning
                return (value2, move);
            }
            if(value2<value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }

    private (int, (Vector2, int)) maxValue(BoardState boardState){
        repetitions++;
        boardState.playerTurn = false;
        int utilityValue = _boardStateChecker.check(boardState, false); 
        boardState.playerTurn = true;
        if(boardState.gameOver){
            return (utilityValue, (new Vector2(), 0));
        }
        (Vector2, int) returnMove = new();
        int value = int.MinValue;
        var possibleMoves = _possibleMovesCalculator.calculate(boardState, false);
       foreach((Vector2, int) move in possibleMoves){
            var newBoardState = boardState.clone();
            newBoardState.previousPlayerPlay.Set((int)move.Item1.x, (int)move.Item1.y);
            makeMoveInGame(newBoardState, move);
            (int value2, (Vector2, int) move2) = minValue(newBoardState);
            if(value2 == 1 || repetitions >= 4000){ // pruning
                return (value2, move);
            }
            if(value2>value){
                value = value2;
                returnMove = move;
            }
        }
        return (value, returnMove);
    }

    private void makeMoveInGame(BoardState boardState, (Vector2, int) move){
        var previousBoardState = boardState.clone();
        boardState.BoardMatrix[(int)move.Item1.x, (int)move.Item1.y] = move.Item2;
        BoardStateUpdater.update(boardState, previousBoardState, (int)move.Item1.x, (int)move.Item1.y);
    }
}
