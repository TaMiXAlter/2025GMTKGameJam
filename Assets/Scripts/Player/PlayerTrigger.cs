using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    public Enemy Target;

    public bool isAcceptInput = false;
    void OnTriggerEnter(Collider other)
    {
        isAcceptInput = true;
        Target = other.gameObject.GetComponent<Enemy>();
    }
    void OnTriggerExit(Collider other)
    {
        isAcceptInput = false;
        Target = null;
    }
}
