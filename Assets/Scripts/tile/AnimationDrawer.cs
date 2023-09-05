using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDrawer : MonoBehaviour
{
    public Animator animator;
    private GameOrchestrator gameController;
    // Start is called before the first frame update
    void Start()
    {        
        //animator.Play("static_x");
        gameController = transform.GetComponentInParent<GameOrchestrator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animationStopped(){
        if(GameOptions.AnimationPlaying){
            GameOptions.AnimationPlaying = false;
        }

        if(false && gameController.animationPlaying){
            gameController.animationPlaying = false;
        }
    }

    public IEnumerator drawMove(string move){
        animator.Play(move + "_drawing");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f );
       // while(!animator.GetCurrentAnimatorStateInfo(0).IsName(move + "_drawing"));
    }
}
