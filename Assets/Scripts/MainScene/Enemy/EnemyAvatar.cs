using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Die()
    {
        EventManager.RaiseOnEnemyDeath();
        EnemyFactory.Instance.PutBackEnemy(gameObject);
        //Destroy(gameObject);
    }

    void OnBecameInVisible()
    {
        //Debug.Log("Enemy has been destroyed");
        //Destroy(gameObject);
        EnemyFactory.Instance.PutBackEnemy(gameObject);

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Border")
    //    {
    //        EnemyFactory.Instance.PutBackEnemy(gameObject);
    //    }
    //}
}
