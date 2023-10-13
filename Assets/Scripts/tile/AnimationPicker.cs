using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AnimationPicker
{
    public static string pick(int tileValue){
        switch(GameOptions.GameType){
            case GameType.WildTicTacToe:
            case GameType.TicTacToe:
                if(tileValue == 1){
                    return "x_drawing";
                } else if(tileValue == -1){
                    return "o_drawing";
                }
                break;
            case GameType.TickOatTwo:
                if(tileValue == 1){
                    return "vertical_line_drawing";
                } else if(tileValue == 10){
                    return "horizontal_line_drawing";
                } else if(tileValue == 11){
                    return "plus_drawing";
                }
                break;
        }
        return "";
    }
}
