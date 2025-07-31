using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerTrigger playerTrigger;
    Rigidbody rb;
    void Awake()
    {
        playerTrigger = transform.Find("PlayerTrigger").GetComponent<PlayerTrigger>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta == 0) return;
        if (playerTrigger.isAcceptInput)
        {
            Roll(scrollDelta);
        }
    }

    void Roll(float scroll)
    {
        Debug.Log("HIT!");
        Destroy(playerTrigger.Target);
        playerTrigger.Target = null;
        playerTrigger.isAcceptInput = false;
        rb.AddForce(Vector3.up * 100);
    }
   
}
