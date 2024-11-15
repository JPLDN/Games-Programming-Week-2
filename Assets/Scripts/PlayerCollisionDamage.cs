using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour
{
    public Health healthSystem;

    public float collisionDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        if (healthSystem == null)
        {
            healthSystem = FindObjectOfType<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            healthSystem.TakeDamage(collisionDamage);
        }

    }
}
