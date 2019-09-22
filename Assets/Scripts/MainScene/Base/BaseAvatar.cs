using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed=5f;// gameObject's move speed;

    [SerializeField]
    private float health = 5f;

    [SerializeField]
    private float maxHealth = 5f;

    

    public float MaxSpeed
    {
        get
        {
            return this.maxSpeed;
        }
        private set
        {
            this.maxSpeed = value;
        }
    }

    public float Health { get => health; set => health = value; }

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    public virtual void TakeDamage(float damage)
    {
        
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
