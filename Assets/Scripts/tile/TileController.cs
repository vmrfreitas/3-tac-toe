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
        int tileValue, previousTileValue;
        if(GameOptions.tileValueChanged && tileCoord == GameOptions.changedTileCoord){
            //Debug.Log("it changed lol");
            (tileValue, previousTileValue) = gameOrchestrator.getTileValues(tileCoord);
            //Debug.Log("tileValue = " + tileValue + ", previusTileValue = " + previousTileValue + "; coordinates = " + tileCoord.x + ", " + tileCoord.y);
            StartCoroutine(animationDrawer.drawMove(AnimationPicker.pick(tileValue, previousTileValue)));
            GameOptions.tileValueChanged = false;
        }
        (tileValue, previousTileValue) = gameOrchestrator.getTileValues(tileCoord);
        if(GameOptions.GameType == GameType.TickOatTwo && (gameOrchestrator.isItPlayerPreviousTile(tileCoord) || gameOrchestrator.isItOtherPlayerPreviousTile(tileCoord)) &&  tileValue != 11){
                spriteRenderer.color = Color.red;
        }else{
                spriteRenderer.color = Color.white;
        }
    }

    void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){
            switch(GameOptions.GameType){
                case GameType.TicTacToe:
                    UpdateTicTacToe();
                    break;
                case GameType.WildTicTacToe:
                    UpdateWildTicTacToe();
                    break;
                case GameType.TickOatTwo:
                    UpdateTicOatTwo();
                    break;
            }
        }
    }

    void UpdateTicOatTwo(){
        if(GameOptions.PlayerTurn && !gameOrchestrator.isItPreviousTile(tileCoord)){
            int tileValue, trashValue;
            (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
            if(tileValue == 0){
                gameOrchestrator.updateTileMove(tileCoord, 1, true);
            } else if(tileValue == 10){
                gameOrchestrator.updateTileMove(tileCoord, 11, true);
            }
        } else if(!GameOptions.SinglePlayer && !gameOrchestrator.isItPreviousTile(tileCoord)){
            int tileValue, trashValue;
            (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
            if(tileValue == 0){
                gameOrchestrator.updateTileMove(tileCoord, 10, false);
            } else if(tileValue == 1){
                gameOrchestrator.updateTileMove(tileCoord, 11, false);
            }
        }
    }

    void UpdateTicTacToe(){
        int tileValue, trashValue;
        (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
        if(tileValue==0){
            if(GameOptions.PlayerTurn){
                //Debug.Log("we updatin");
                gameOrchestrator.updateTileMove(tileCoord, 1, true);
            } else if(!GameOptions.SinglePlayer){
                gameOrchestrator.updateTileMove(tileCoord, -1, false);
            }
        }
    }
    void UpdateWildTicTacToe(){
        int tileValue, trashValue;
        (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
        if(tileValue==0){
            if(GameOptions.PlayerTurn){
                //Debug.Log("we updatin");
                gameOrchestrator.updateTileMove(tileCoord, 1, true);
            } else if(!GameOptions.SinglePlayer){
                gameOrchestrator.updateTileMove(tileCoord, -1, false);
            }
        }
    }
}


