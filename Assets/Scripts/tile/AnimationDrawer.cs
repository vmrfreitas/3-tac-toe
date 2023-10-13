using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDrawer : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animationStopped(){
        if(GameOptions.AnimationPlaying){
            GameOptions.AnimationPlaying = false;
        }
    }

    public IEnumerator drawMove(string move){
        animator.Play(move);
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f );
    }
}
