using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject game;
    public Sprite xSprite;
    public Sprite oSprite;
    public bool playerTurn;

    public int[,] gameState = new int[3, 3];
    int[] checkValues = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int checkGameState(){
        return 0;
    }
}
