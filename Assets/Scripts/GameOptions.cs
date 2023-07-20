using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static bool SinglePlayer {get; set;} = true;
    public static GameType GameType {get; set;}
    public static bool GameOver {get; set;}
    public static bool PlayerTurn {get; set;}
    public static bool AnimationPlaying {get; set;}
}