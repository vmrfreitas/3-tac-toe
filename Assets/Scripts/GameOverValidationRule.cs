using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverValidationRule : GameUpdateValidationRule
{
    public bool isValid() {
        return true;
    }
}
