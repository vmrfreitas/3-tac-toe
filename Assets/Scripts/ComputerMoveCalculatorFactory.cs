using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class ComputerMoveCalculatorFactory
{
    public ComputerMoveCalculator make(){
        return GameState.gameType switch
        { // TODO: movesCalc needs to receive stateChecker as argument and added here
            GameType.TicTacToe => new HardComputerMoveCalc(new DefaultMovesCalculator()),
            GameType.WildTicTacToe => new HardComputerMoveCalc(new WildMovesCalculator()),
            GameType.TickOatTwo => new HardComputerMoveCalc(new TickOatMovesCalculator()),
            _ => new HardComputerMoveCalc(new DefaultMovesCalculator()),
        };
    }
}
