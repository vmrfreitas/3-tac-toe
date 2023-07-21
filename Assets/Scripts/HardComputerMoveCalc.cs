using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardComputerMoveCalc : ComputerMoveCalculator
{
    public PossibleMovesCalculator possibleMovesCalculator;
    
    public Vector2 calculate() {
        return new Vector2();
    }
}
