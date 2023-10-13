using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class ComputerMoveCalculatorFactory
{
    public (ComputerMoveCalculator, BoardStateChecker) make(){
        BoardStateChecker defaultBoardStateChecker = new DefaultBoardStateChecker();
        BoardStateChecker wildBoardStateChecker = new WildBoardStateChecker();
        BoardStateChecker tickOatBoardStateChecker = new TickOatBoardStateChecker();

        return GameOptions.GameType switch
        {
            GameType.TicTacToe => (new HardComputerMoveCalc(new DefaultMovesCalculator(), defaultBoardStateChecker), defaultBoardStateChecker),
            GameType.WildTicTacToe => (new HardComputerMoveCalc(new WildMovesCalculator(), wildBoardStateChecker), wildBoardStateChecker),
            GameType.TickOatTwo => (new HardComputerMoveCalc(new TickOatMovesCalculator(), tickOatBoardStateChecker), tickOatBoardStateChecker),
            _ => (new HardComputerMoveCalc(new DefaultMovesCalculator(), defaultBoardStateChecker), defaultBoardStateChecker),
        };
    }
}
