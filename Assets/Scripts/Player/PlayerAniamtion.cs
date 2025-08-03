using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private float animationDuration = 0.3f;
    private float resetDuration = 0.3f;
    private float ResetTimer = 0;
    private float AnimationTimer = 0;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (ResetTimer <= 0) return;
        ResetTimer -= Time.deltaTime;
        AnimationTimer -= Time.deltaTime;

        if (ResetTimer <= 0) Reset();
    }
    public void Jump(AttackType attackType)
    {
        if (AnimationTimer > 0) return;
        switch (attackType)
        {
            case AttackType.Front:
                animator.SetTrigger("Forward");
                break;
            case AttackType.Back:
                animator.SetTrigger("Back");
                break;
            case AttackType.Right:
                animator.SetTrigger("Right");
                break;
            case AttackType.Left:
                animator.SetTrigger("Left");
                break;
            default:
                break;
        }
        ResetTimer = animationDuration +resetDuration;

    }
    public void StartNewAnimation()
    {
        if (ResetTimer > 0) return;
        ResetTimer = animationDuration + resetDuration;
        AnimationTimer = animationDuration;
    }

    void Reset()
    {
        animator.SetTrigger("Reset");
    }
}