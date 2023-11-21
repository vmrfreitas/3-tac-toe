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
