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
    }

    void OnMouseOver() {
        Sprite playSprite;
        int playValue;
        if(gameController.gameState[tileCoord.x, tileCoord.y]==0){
            if(Input.GetMouseButtonDown(0)){
                if(gameController.playerTurn){
                    playValue = 1;
                    playSprite = gameController.xSprite;
                    gameController.playerTurn = false;
                } else {
                    playValue = -1;
                    playSprite = gameController.oSprite;
                    gameController.playerTurn = true;
                }
                gameController.gameState[tileCoord.x, tileCoord.y] = playValue;
                spriteRenderer.sprite = playSprite;

                gameController.updateGameStatus(tileCoord.x, tileCoord.y);
                if (gameController.checkGameState() == 1){
                    Debug.Log("player won");
                } else if(gameController.checkGameState() == -1){
                    Debug.Log("computer won");
                }
            }
        }
    }
}


