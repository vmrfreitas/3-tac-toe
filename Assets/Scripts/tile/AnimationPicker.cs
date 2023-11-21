using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AnimationPicker
{
    public static string pick(int tileValue, int previousTileValue){
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
                } else if(previousTileValue == 10){
                    return "plus_hor_drawing";
                } else if(previousTileValue == 1){
                    return "plus_ver_drawing";
                }
                break;
        }
        return "";
    }
}
