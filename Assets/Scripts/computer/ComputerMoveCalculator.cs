using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ComputerMoveCalculator
{
    public (Vector2, int) calculate(BoardState boardState);
}
