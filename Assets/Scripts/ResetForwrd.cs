using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetForwrd : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Get().playerAnimation.ResetForward();
    }
}
