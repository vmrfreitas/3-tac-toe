using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI turnText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOptions.GameOver){
            if(GameOptions.SinglePlayer){
                switch(GameOptions.whoWon){
                    case 0:
                        turnText.text = "Player wins :)";
                        break;
                    case 1:
                        turnText.text = "Computer wins";
                        break;
                    case 2:
                        turnText.text = "Game tied";
                        break;
                }
            } else {
                switch(GameOptions.whoWon){
                    case 0:
                        turnText.text = "Player 1 wins";
                        break;
                    case 1:
                        turnText.text = "Player 2 wins";
                        break;
                    case 2:
                        turnText.text = "Game tied";
                        break;
                }
            }
        } else{
            if(GameOptions.SinglePlayer){
                if(GameOptions.PlayerTurn){
                    turnText.text = "Player turn";
                } else { 
                    turnText.text = "Computer turn";
                }
            } else {
                if(GameOptions.PlayerTurn){
                    turnText.text = "Player 1 turn";
                } else {
                    turnText.text = "Player 2 turn";
                }
            }
        }
    }
}
