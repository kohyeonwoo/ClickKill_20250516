using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assistant : MonoBehaviour, IDamageable
{

    public float maxHealth;
    
    public float currentHealth;

    public float attackPoint;

    protected Animator anim;

    protected Rigidbody rigid;

    protected void Init()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    public void Damage(float TheDamage)
    {
        currentHealth -= TheDamage;

        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        this.gameObject.SetActive(true);
    }
}
