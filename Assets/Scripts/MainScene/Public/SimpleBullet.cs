using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{

    protected override void Init()
    {
        if (gameObject.tag == "EnemyShot")
        {
            Speed = Vector2.left;
            BulletType = BulletTypeEnum.EnemyBullet;
        }
        else if(gameObject.tag=="PlayerShot")
        {
            Speed = Vector2.right;
            BulletType = BulletTypeEnum.PlayerButtlet;
        }
        Damage = 1f; 
        Position = transform.position;
    }

    protected override void UpdatePosition()
    {
        //transform.position = transform.position + new Vector3(Speed.x * MaxSpeed * Time.delataTime, Speed.y * MaxSpeed * Time.delataTime, 0);
        transform.Translate(new Vector3(Speed.x , Speed.y , 0) * MaxSpeed * Time.deltaTime);

    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}
