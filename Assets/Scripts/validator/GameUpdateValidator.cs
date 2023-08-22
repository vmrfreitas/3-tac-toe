using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUpdateValidator
{
    private List<GameUpdateValidationRule> _gameUpdateValidationRules;

    public GameUpdateValidator(List<GameUpdateValidationRule> gameUpdateValidationRules)
    {
        _gameUpdateValidationRules = gameUpdateValidationRules;
    }


    public bool validate()
    {
        foreach (var rule in _gameUpdateValidationRules) {
            if (!rule.isValid()) {
                return false;
            }
        }
        return true;
    }
}
