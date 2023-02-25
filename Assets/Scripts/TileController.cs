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
        if(gameController.gameState[tileCoord.x, tileCoord.y]==1){
            spriteRenderer.sprite = gameController.xSprite;
        } else if(gameController.gameState[tileCoord.x, tileCoord.y]==-1){
            spriteRenderer.sprite = gameController.oSprite;
        } else if(gameController.gameState[tileCoord.x, tileCoord.y]==0){
            spriteRenderer.sprite = null;
        }
    }

    void OnMouseOver() {
        if(gameController.gameState[tileCoord.x, tileCoord.y]==0){
            if(Input.GetMouseButtonDown(0)){
                if(gameController.playerTurn){
                    gameController.gameState[tileCoord.x, tileCoord.y] = 1;
                    gameController.updateGameStatus(tileCoord.x, tileCoord.y);
                    gameController.checkGameState(true);
                    gameController.playerTurn = false;
                
                    if(!gameController.gameOver){
                        Vector2 aiMove = gameController.makeAIPlay();
                        gameController.gameState[(int)aiMove.x, (int)aiMove.y] = -1;
                        gameController.updateGameStatus((int)aiMove.x, (int)aiMove.y);
                        gameController.checkGameState(true);
                        gameController.playerTurn = true;
                    }
                }
            }
        }
    }
}


