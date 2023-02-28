using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = transform.GetComponentInParent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        int tileValue = gameController.globalGameState.gameMatrix[tileCoord.x, tileCoord.y];
        if(tileValue == 1){
            spriteRenderer.sprite = gameController.xSprite;
        } else if(tileValue == -1){
            spriteRenderer.sprite = gameController.oSprite;
        }
    }

    void OnMouseOver() {
        if(gameController.playerTurn){
            var gameState = gameController.globalGameState;
            if(gameState.gameMatrix[tileCoord.x, tileCoord.y]==0 && !gameState.gameOver){
                if(Input.GetMouseButtonDown(0)){
                    gameState.gameMatrix[tileCoord.x, tileCoord.y] = 1;
                    gameController.updateGameState(gameState, tileCoord.x, tileCoord.y);
                    gameController.checkGameState(gameState, true);
                    gameController.playerTurn = false;
                }
            }
        }
    }
}


