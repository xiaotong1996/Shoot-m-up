using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletTypeEnum
{
    PlayerButtlet,
    EnemyBullet
}

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10f;// gameObject's move speed;

    [SerializeField]
    private float damage;

    [SerializeField]
    private Vector2 speed;

    [SerializeField]
    private Vector2 position;

    private BulletTypeEnum bulletType;

    public float Damage { get => damage;  set => damage = value; }
    public Vector2 Speed { get => speed;  set => speed = value; }
    public Vector2 Position { get => position;  set => position = value; }
    public float MaxSpeed { get => maxSpeed;  set => maxSpeed = value; }
    public BulletTypeEnum BulletType { get => bulletType; set => bulletType = value; }

    protected virtual void Init()
    {

    }

    protected virtual void UpdatePosition()
    {
        transform.Translate(new Vector3(Speed.x, Speed.y, 0) * MaxSpeed * Time.deltaTime);
    }
    
    //NOT USEFUL!!!
    void OnBecameInVisible()
    {
        //Destroy(gameObject);
        BulletFactory.Instance.PutBackBullet(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" && BulletType == BulletTypeEnum.EnemyBullet)||(collision.tag == "Enemy" && BulletType == BulletTypeEnum.PlayerButtlet))
        {
            Debug.Log(collision.name + " be hit");
            BaseAvatar baseAvatar = collision.GetComponent<BaseAvatar>();
            baseAvatar.TakeDamage(Damage);
            //Destroy(gameObject);
            BulletFactory.Instance.PutBackBullet(gameObject);
        }


        //use this to replace OnBecameInVisible()
        if (collision.tag == "Border")
        {
            BulletFactory.Instance.PutBackBullet(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
