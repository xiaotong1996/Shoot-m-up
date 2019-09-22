using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : BaseAvatar
{
    private Dodge dodge;

    private void Start()
    {
        dodge = GetComponent<Dodge>();
    }

    public override void TakeDamage(float damage)
    {
        if(!dodge.IsCalled)
        {
            Health -= damage;
        }
        
        if (Health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        EventManager.RaiseOnPlayerDeath();
        Destroy(gameObject);
    }
}
