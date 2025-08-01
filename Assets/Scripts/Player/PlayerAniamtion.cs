using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Jump(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Front:
                animator.SetBool("Forward", true);
                break;
            case AttackType.Back:
                animator.SetBool("Back", true);
                break;
            default:
                break;
        }

    }
    public void ResetForward()
    {
        animator.SetBool("Forward", false);
    }
    
    public void ResetBack()
    {
        animator.SetBool("Back", false);
    }
}