using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy01 : MonoBehaviour
{
    public int maxHealth = 100;
    int currenthealth;
    public Animator Anim;
    void Start()
    {
        currenthealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");
    }
}
