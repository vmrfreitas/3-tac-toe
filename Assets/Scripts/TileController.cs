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
        int[,] gameMatrix = gameController.globalGameState.gameMatrix;
        if(gameMatrix[tileCoord.x, tileCoord.y]==1){
            spriteRenderer.sprite = gameController.xSprite;
        } else if(gameMatrix[tileCoord.x, tileCoord.y]==-1){
            spriteRenderer.sprite = gameController.oSprite;
        } else if(gameMatrix[tileCoord.x, tileCoord.y]==0){
            spriteRenderer.sprite = null;
        }
    }

    void OnMouseOver() {
        var gameState = gameController.globalGameState;
        if(gameState.gameMatrix[tileCoord.x, tileCoord.y]==0 && !gameState.gameOver){
            if(Input.GetMouseButtonDown(0)){
                if(gameController.playerTurn){
                    gameState.gameMatrix[tileCoord.x, tileCoord.y] = 1;
                    gameController.updateGameState(gameState, tileCoord.x, tileCoord.y);
                    gameController.checkGameState(gameState, true);
                    gameController.playerTurn = false;
                
                    if(!gameState.gameOver){
                        Vector2 aiMove = gameController.makeAIPlay();
                        gameState.gameMatrix[(int)aiMove.x, (int)aiMove.y] = -1;
                        gameController.updateGameState(gameState, (int)aiMove.x, (int)aiMove.y);
                        gameController.checkGameState(gameState, true);
                        gameController.playerTurn = true;
                    }
                }
            }
        }
    }
}


