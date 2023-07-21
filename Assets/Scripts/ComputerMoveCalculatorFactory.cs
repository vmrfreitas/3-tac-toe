using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerMoveCalculatorFactory
{
    public ComputerMoveCalculator make(){

        return new HardComputerMoveCalc(new DefaultMovesCalculator());
    }
}
