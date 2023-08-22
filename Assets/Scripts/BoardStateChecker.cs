using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface BoardStateChecker
{
    public int check(BoardState boardState, bool forReal);
}
