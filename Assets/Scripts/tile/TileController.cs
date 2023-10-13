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
    }

    void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){
            if(GameOptions.PlayerTurn){
                gameOrchestrator.updateTileMove(tileCoord);
            }
        }
    }
}


