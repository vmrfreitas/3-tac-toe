using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerValidationRule : GameUpdateValidationRule
{
    public bool isValid() {
        return GameOptions.SinglePlayer;
    }
}
