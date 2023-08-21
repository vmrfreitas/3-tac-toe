using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class ComputerMoveCalculatorFactory
{
    public ComputerMoveCalculator make(){
        switch(GameState.gameType){ // TODO: movesCalc needs to receive stateChecker as argument and added here
            case GameType.TicTacToe:
                return new HardComputerMoveCalc(new DefaultMovesCalculator());
                break;
            case GameType.WildTicTacToe:
                return new HardComputerMoveCalc(new WildMovesCalculator());
                break;
            case GameType.TickOatTwo:
                return new HardComputerMoveCalc(new TickOatMovesCalculator());
                break;
            default:
                return new HardComputerMoveCalc(new DefaultMovesCalculator());
        }       
    }
}
