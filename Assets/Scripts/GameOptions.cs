using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static bool SinglePlayer {get; set;} = false;
    public static GameType GameType {get; set;} = GameType.TickOatTwo;
    public static bool GameOver {get; set;} = false;
    public static bool PlayerTurn {get; set;} = true;
    public static bool AnimationPlaying {get; set;} = false;
}