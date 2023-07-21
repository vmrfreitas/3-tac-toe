using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardComputerMoveCalc : ComputerMoveCalculator
{
    private PossibleMovesCalculator _possibleMovesCalculator;
    
    public HardComputerMoveCalc(PossibleMovesCalculator possibleMovesCalculator) {
        _possibleMovesCalculator = possibleMovesCalculator;
    }

    public Vector2 calculate() {
        return new Vector2();
    }
}
