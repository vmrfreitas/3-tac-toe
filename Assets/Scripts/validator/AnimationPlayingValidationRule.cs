using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationPlayingValidationRule : GameUpdateValidationRule
{
    public bool isValid() {
        return !GameOptions.AnimationPlaying;
    }
}
