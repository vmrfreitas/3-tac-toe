using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLeft : MonoBehaviour
{
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
        if(Input.GetMouseButtonDown(0)){
            gameController.gameState[0,0] = 1;
            spriteRenderer.sprite = gameController.xSprite;
        }
    }
}
