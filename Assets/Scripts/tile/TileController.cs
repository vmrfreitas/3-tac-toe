using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameOrchestrator gameOrchestrator;
    public AnimationDrawer animationDrawer;
    private static Color32 weirdGreen = new Color32(166,182,133, 255);

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
            (tileValue, previousTileValue) = gameOrchestrator.getTileValues(tileCoord);
            StartCoroutine(animationDrawer.drawMove(AnimationPicker.pick(tileValue, previousTileValue)));
            GameOptions.tileValueChanged = false;
        }
        (tileValue, previousTileValue) = gameOrchestrator.getTileValues(tileCoord);
        if(GameOptions.GameType == GameType.TickOatTwo && (gameOrchestrator.isItPlayerPreviousTile(tileCoord) || gameOrchestrator.isItOtherPlayerPreviousTile(tileCoord)) &&  tileValue != 11){
                spriteRenderer.color = weirdGreen;
        }else{
                spriteRenderer.color = Color.white;
        }
    }

    void OnMouseOver() {        
        if(GameOptions.CanClick && !GameOptions.AnimationPlaying && Input.GetMouseButtonDown(0)){
            GameOptions.CanClick = false;
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
            GameOptions.CanClick = true;
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
                gameOrchestrator.updateTileMove(tileCoord, GameOptions.wildValue, true);
            } else if(!GameOptions.SinglePlayer){
                gameOrchestrator.updateTileMove(tileCoord, GameOptions.wildValue, false);
            }
        }
    }
}


