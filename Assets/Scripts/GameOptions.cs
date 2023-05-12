using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static bool singlePlayer;
    public static GameType gameType;
}

public enum GameType{
    TicTacToe,
    TickOatTwo,
    WildTicTacToe
}
