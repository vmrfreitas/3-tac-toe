using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Vector2Int tileCoord;
    public SpriteRenderer spriteRenderer;
    private GameOrchestrator gameOrchestrator;
    public bool tileValueChanged = false;
    public AnimationDrawer animationDrawer;

    // Start is called before the first frame update
    void Start()
    {
        gameOrchestrator = transform.GetComponentInParent<GameOrchestrator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tileValueChanged){
            int tileValue, previousTileValue;
            (tileValue, previousTileValue) = gameOrchestrator.getTileValues(tileCoord);
            StartCoroutine(animationDrawer.drawMove(AnimationPicker.pick(tileValue, previousTileValue)));
            tileValueChanged = false;
        }
    }

    void OnMouseOver() {        
        if(Input.GetMouseButtonDown(0)){
            switch(GameOptions.GameType){
                case GameType.TicTacToe:
                    UpdateTicTacToe();
                    break;
                case GameType.WildTicTacToe:
                    break;
                case GameType.TickOatTwo:
                    UpdateTicOatTwo();
                    break;
            }
            if(GameOptions.GameType == GameType.TicTacToe){
                UpdateTicTacToe();
            }
        }
    }

    void UpdateTicOatTwo(){
        if(GameOptions.PlayerTurn){
            int tileValue, trashValue;
            (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
            if(tileValue == 0){
                gameOrchestrator.updateTileMove(tileCoord, 1, false);
                tileValueChanged = true;
            } else if(tileValue == 10){
                gameOrchestrator.updateTileMove(tileCoord, 11, false);
                tileValueChanged = true;
            }
        } else if(!GameOptions.SinglePlayer){
            int tileValue, trashValue;
            (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
            if(tileValue == 0){
                gameOrchestrator.updateTileMove(tileCoord, 10, true);
                tileValueChanged = true;
            } else if(tileValue == 1){
                gameOrchestrator.updateTileMove(tileCoord, 11, true);
                tileValueChanged = true;
            }
        }
    }

    void UpdateTicTacToe(){
        int tileValue, trashValue;
        (tileValue, trashValue) = gameOrchestrator.getTileValues(tileCoord);
        if(tileValue==0){
            if(GameOptions.PlayerTurn){
                gameOrchestrator.updateTileMove(tileCoord, 1, false);
                tileValueChanged = true;
            } else if(!GameOptions.SinglePlayer){
                gameOrchestrator.updateTileMove(tileCoord, -1, true);
                tileValueChanged = true;
            }
        }
    }
}


