
using UnityEngine;

public class Reset : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Get().playerAnimation.StartNewAnimation();
    }
}
