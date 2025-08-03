using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaGround : MonoBehaviour
{

    // Update is called once per frame
    float timer=0;
    void Update()
    {
        timer += Time.deltaTime * 100;
        if (timer > 360) timer = 0;

        transform.rotation = Quaternion.Euler(-47, timer, 0);
    }
}
