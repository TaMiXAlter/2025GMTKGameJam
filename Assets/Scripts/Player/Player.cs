using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    static private Player instance;
    PlayerTrigger playerTrigger;
    public PlayerAnimation playerAnimation;
    private JumpRope jumpRope;
    static public Player Get()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
        playerTrigger = transform.Find("PlayerTrigger").GetComponent<PlayerTrigger>();
        playerAnimation = transform.Find("PlayerAnimation").GetComponent<PlayerAnimation>();
        jumpRope = transform.Find("JumpRope").GetComponent<JumpRope>();
    }
    void Update()
    {
        AttackType attack = AttackType.Miss;
        CheckScroll(ref attack);
        CheckClick(ref attack);
        
        if (attack == AttackType.Miss) return;
        playerAnimation.Jump(attack);
        jumpRope.Jump(attack);

        if (playerTrigger.isAcceptInput && playerTrigger.Target != null)
        {
            playerTrigger.Target.OnHit(attack);

            playerTrigger.Target = null;
            playerTrigger.isAcceptInput = false;
        }
    }

    void CheckScroll(ref AttackType attack)
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta == 0) return;
        if (scrollDelta > 0) attack = AttackType.Front;
        if (scrollDelta < 0) attack = AttackType.Back;
    }

    void CheckClick(ref AttackType attack)
    {
        if (Input.GetMouseButtonDown(0))
            attack = AttackType.Left;

        if (Input.GetMouseButtonDown(1))
            attack = AttackType.Right;
    }
   
}
