using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotPos;

    private Cooldown cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = GetComponent<Cooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown.Ready())
        {
            //GameObject.Instantiate(bulletPrefab, shotPos.position, Quaternion.identity);
            GameObject bullet = BulletFactory.Instance.TakeBullet(BulletTypeEnum.EnemyBullet);
            bullet.GetComponent<Transform>().position = shotPos.position;
            bullet.SetActive(true);
            cooldown.Reset();
        }
    }
}
