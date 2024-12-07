using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.0095f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health < 0f)
        {
            health = 0f;
            Die();
        }   
    }

    private void Die()
    {
        Debug.Log("You Died!");
    }
}
