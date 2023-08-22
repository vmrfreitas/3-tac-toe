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

    public Vector2 calculate(BoardState boardState) {
        BoardState localBoardState = boardState.clone();
        (var uselessValue, var aiMove) = minValue(localBoardState);
        return aiMove;
    }

    private (int, Vector2) minValue(BoardState boardState){
        int utilityValue = _boardStateChecker.check(boardState, false); 
        if(boardState.gameOver){
            return (utilityValue, new Vector2());
        }

        Vector2 returnMove = new Vector2();
        int value = int.MaxValue;
        var possibleMoves = this.possibleMoves(boardState.BoardMatrix);
        foreach(Vector2 move in possibleMoves){
            var newBoardState = boardState.clone();
            this.makeMoveInGame(newBoardState, move, -1);
            (int value2, Vector2 move2) = maxValue(newBoardState);
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

    private (int, Vector2) maxValue(BoardState boardState){
        int utilityValue = _boardStateChecker.check(boardState, false); 
        if(boardState.gameOver){
            return (utilityValue, new Vector2());
        }
        Vector2 returnMove = new Vector2();
        int value = int.MinValue;
        var possibleMoves = this.possibleMoves(boardState.BoardMatrix);
        foreach(Vector2 move in possibleMoves){
            var newBoardState = boardState.clone();
            this.makeMoveInGame(newBoardState, move, 1);
            (int value2, Vector2 move2) = minValue(newBoardState);
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

    private void makeMoveInGame(BoardState boardState, Vector2 move, int moveValue){
        boardState.BoardMatrix[(int)move.x, (int)move.y] = moveValue;
        BoardStateUpdater.update(boardState, (int)move.x, (int)move.y);
    }
}
