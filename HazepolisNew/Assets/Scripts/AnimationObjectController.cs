using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObjectController : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo animatorStateInfo;
    bool isReadyToExit;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!isReadyToExit && animatorStateInfo.normalizedTime < 0.5f)
        {
            isReadyToExit = true;
        }
        if(isReadyToExit && animatorStateInfo.normalizedTime > 0.5f)
        {
            isReadyToExit = false;
            if (animatorStateInfo.IsTag("Finish"))
            {
                Debug.Log("TEst");
            }
        }
    }
}
