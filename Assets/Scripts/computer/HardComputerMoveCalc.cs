using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardComputerMoveCalc : ComputerMoveCalculator
{
    private PossibleMovesCalculator _possibleMovesCalculator;
    private BoardStateChecker _boardStateChecker;
    
    public HardComputerMoveCalc(PossibleMovesCalculator possibleMovesCalculator, BoardStateChecker boardStateChecker) {
        _possibleMovesCalculator = possibleMovesCalculator;
        _boardStateChecker = boardStateChecker;
    }

    public (Vector2, int) calculate(BoardState boardState) {
        BoardState localBoardState = boardState.clone();
        (var uselessValue, var aiMove) = minValue(localBoardState);
        return aiMove;
    }

    private (int, (Vector2, int)) minValue(BoardState boardState){
        int utilityValue = _boardStateChecker.check(boardState, false);  // the stateChecker will need playerTurn for the wildtictactoe to work
        if(boardState.gameOver){
            return (utilityValue, (new Vector2(), 0));
        }

        (Vector2, int) returnMove = new();
        int value = int.MaxValue;
        var possibleMoves = _possibleMovesCalculator.calculate(boardState.BoardMatrix, true);
        foreach((Vector2, int) move in possibleMoves){
            var newBoardState = boardState.clone();
            makeMoveInGame(newBoardState, move);
            (int value2, (Vector2, int) move2) = maxValue(newBoardState);
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

    private (int, (Vector2, int)) maxValue(BoardState boardState){
        int utilityValue = _boardStateChecker.check(boardState, false); 
        if(boardState.gameOver){
            return (utilityValue, (new Vector2(), 0));
        }
        (Vector2, int) returnMove = new();
        int value = int.MinValue;
        var possibleMoves = _possibleMovesCalculator.calculate(boardState.BoardMatrix, false);
       foreach((Vector2, int) move in possibleMoves){
            var newBoardState = boardState.clone();
            makeMoveInGame(newBoardState, move);
            (int value2, (Vector2, int) move2) = minValue(newBoardState);
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

    private void makeMoveInGame(BoardState boardState, (Vector2, int) move){
        boardState.BoardMatrix[(int)move.Item1.x, (int)move.Item1.y] += move.Item2;
        BoardStateUpdater.update(boardState, (int)move.Item1.x, (int)move.Item1.y);
    }
}
