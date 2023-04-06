using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    public static int playerNumber = 0;
    public static GameType gameType;
}

public enum GameType{
    TicTacToe,
    TickOatTwo,
    WildTicTacToe
}
