using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTurnValidationRule : GameUpdateValidationRule
{
    public bool isValid() {
        return !GameState.playerTurn;
    }
}
