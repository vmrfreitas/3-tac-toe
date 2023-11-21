using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static bool SinglePlayer {get; set;} = true;
    public static GameType GameType {get; set;} = GameType.TickOatTwo;
    public static bool GameOver {get; set;} = false;
    public static bool PlayerTurn {get; set;} = true;
    public static bool AnimationPlaying {get; set;} = false;
    public static bool tileValueChanged = false;
    public static Vector2Int changedTileCoord = new Vector2Int(-1, -1);
    public static int wildValue = 1;
    public static int whoWon;
}