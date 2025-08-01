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
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta == 0) return;

        AttackType attack = AttackType.Miss;
        if (scrollDelta > 0) attack = AttackType.Front;
        if (scrollDelta < 0) attack = AttackType.Back;
        playerAnimation.Jump(attack);
        jumpRope.Jump(attack);
        
        if (playerTrigger.isAcceptInput && playerTrigger.Target != null)
        {
            playerTrigger.Target.OnHit(attack);

            playerTrigger.Target = null;
            playerTrigger.isAcceptInput = false;
        }
    }
   
}
