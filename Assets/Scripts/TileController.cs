using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameController gameController;
    public AnimationController animationController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = transform.GetComponentInParent<GameController>();
        //var go1 = new GameObject { name = "Circle" };
        //go1.DrawCircle(1, .02f);
        //var what = transform.GetComponent<hasDrawing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteRenderer.sprite == null){
            int tileValue = gameController.globalGameState.gameMatrix[tileCoord.x, tileCoord.y];
            if(tileValue == 1){
                StartCoroutine(animationController.drawMove("x"));
                //spriteRenderer.sprite = gameController.xSprite;
            } else if(tileValue == -1){
                StartCoroutine(animationController.drawMove("o"));
                //spriteRenderer.sprite = gameController.oSprite;
            }
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
                    gameController.animationPlaying = true;
                }
            }
        }
    }
}


