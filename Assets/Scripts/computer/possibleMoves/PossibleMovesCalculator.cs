using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface PossibleMovesCalculator
{
    public List<(Vector2, int)> calculate(BoardState boardState, bool isMin);
}
