using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    //public float Damage = 10f;
    //public Vector2 Speed;
    //public float Cooldown;

    //public GameObject bulletPrefab;
    public Transform shotPos;

    public void Fire()
    {
        //GameObject.Instantiate(bulletPrefab,shotPos.position,Quaternion.identity);
        GameObject bullet=BulletFactory.Instance.TakeBullet(BulletTypeEnum.PlayerButtlet);
        bullet.GetComponent<Transform>().position = shotPos.position;
        bullet.SetActive(true);
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
