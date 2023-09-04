using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameOrchestrator gameController;
    public AnimationDrawer animationDrawer;

    // Start is called before the first frame update
    void Start()
    {
        gameController = transform.GetComponentInParent<GameOrchestrator>();
        //var go1 = new GameObject { name = "Circle" };
        //go1.DrawCircle(1, .02f);
        //var what = transform.GetComponent<hasDrawing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(false && spriteRenderer.sprite == null){
            int tileValue = gameController.getTileValue(tileCoord);
            if(tileValue == 1){
                StartCoroutine(animationDrawer.drawMove("x")); // will vary
                //spriteRenderer.sprite = gameController.xSprite;
            } else if(tileValue == -1){
                StartCoroutine(animationDrawer.drawMove("o"));
                //spriteRenderer.sprite = gameController.oSprite;
            }
        }

        if(spriteRenderer.sprite == null){
            int tileValue = gameController.globalGameState.gameMatrix[tileCoord.x, tileCoord.y];
            if(tileValue == 1){
                StartCoroutine(animationDrawer.drawMove("x")); // will vary
                //spriteRenderer.sprite = gameController.xSprite;
            } else if(tileValue == -1){
                StartCoroutine(animationDrawer.drawMove("o"));
                //spriteRenderer.sprite = gameController.oSprite;
            }
        }
    }

    void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){
            if(false && GameState.playerTurn){
                gameController.updateTileMove(tileCoord);
            }
            if(gameController.playerTurn){
                var gameState = gameController.globalGameState;
                if(gameState.gameMatrix[tileCoord.x, tileCoord.y]==0 && !gameState.gameOver){ // will vary
                
                        gameState.gameMatrix[tileCoord.x, tileCoord.y] = 1;
                        gameController.updateGameState(gameState, tileCoord.x, tileCoord.y);
                        gameController.checkGameState(gameState, true);
                        gameController.playerTurn = false;
                        gameController.animationPlaying = true;
                    
                }
            }
        }
    }
}

