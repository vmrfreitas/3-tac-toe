using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameOrchestrator gameOrchestrator;
    public AnimationDrawer animationDrawer;

    // Start is called before the first frame update
    void Start()
    {
        gameOrchestrator = transform.GetComponentInParent<GameOrchestrator>();
        //var go1 = new GameObject { name = "Circle" };
        //go1.DrawCircle(1, .02f);
        //var what = transform.GetComponent<hasDrawing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.sprite == null){
            int tileValue = gameOrchestrator.getTileValue(tileCoord);
            if(tileValue == 1){
                StartCoroutine(animationDrawer.drawMove("x")); // will vary
                //spriteRenderer.sprite = gameOrchestrator.xSprite;
            } else if(tileValue == -1){
                StartCoroutine(animationDrawer.drawMove("o"));
                //spriteRenderer.sprite = gameOrchestrator.oSprite;
            }
        }

        if(false && spriteRenderer.sprite == null){
            int tileValue = gameOrchestrator.globalGameState.gameMatrix[tileCoord.x, tileCoord.y];
            if(tileValue == 1){
                StartCoroutine(animationDrawer.drawMove("x")); // will vary
                //spriteRenderer.sprite = gameOrchestrator.xSprite;
            } else if(tileValue == -1){
                StartCoroutine(animationDrawer.drawMove("o"));
                //spriteRenderer.sprite = gameOrchestrator.oSprite;
            }
        }
    }

    void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){
            if(GameState.playerTurn){
                gameOrchestrator.updateTileMove(tileCoord);
            }

            
            if(false && gameOrchestrator.playerTurn){
                var gameState = gameOrchestrator.globalGameState;
                if(gameState.gameMatrix[tileCoord.x, tileCoord.y]==0 && !gameState.gameOver){ // will vary
                
                        gameState.gameMatrix[tileCoord.x, tileCoord.y] = 1;
                        gameOrchestrator.updateGameState(gameState, tileCoord.x, tileCoord.y);
                        gameOrchestrator.checkGameState(gameState, true);
                        gameOrchestrator.playerTurn = false;
                        gameOrchestrator.animationPlaying = true;
                    
                }
            }
        }
    }
}


