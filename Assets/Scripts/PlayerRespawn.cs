using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public float threshold; // Threshold us defined as Y-Value of Transform.

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > threshold)
        {
            transform.position = new Vector3();
        }


    }
}
