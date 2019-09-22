using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public interface IBullet
//{
//    GameObject GetBullet();
//}

//public class PlayerBullet : IBullet
//{
//    public GameObject GetBullet()
//    {
//        return 
//    }
//}

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory instance;

    private static readonly object locker = new object();

    public GameObject playerBulletPrefab;
    public GameObject enemyBulletPrefab;

    private Stack<GameObject> playerBullets = new Stack<GameObject>();
    private Stack<GameObject> enemyBullets = new Stack<GameObject>();

    public static BulletFactory Instance { get => instance; private set => instance = value; }

    private BulletFactory()
    {

    }

    private void Awake()
    {
        //Debug.Assert(BulletFactory.Instance == null);
        if (Instance == null)
        {
            lock (locker)
            {
                if (Instance == null)
                {
                    BulletFactory.Instance = this;
                }
            }
        }
    }

    //public static BulletFactory GetInstance()
    //{
    //    if(instance == null)
    //    {
    //        lock (locker)
    //        {
    //            if (instance == null)
    //            {
    //                BulletFactory.instance = this;
    //            }
    //        }
    //    }
    //    return instance;
    //}

    public GameObject GetBullet(BulletTypeEnum bulletType)
    {
        GameObject bullet;
        switch (bulletType)
        {
            case BulletTypeEnum.PlayerButtlet:
                bullet = (GameObject)Instantiate(playerBulletPrefab);
                bullet.SetActive(false);
                break;
            case BulletTypeEnum.EnemyBullet:
                bullet = (GameObject)Instantiate(enemyBulletPrefab);
                bullet.SetActive(false);
                break;
            default:
                bullet = null;
                break;
        }
        return bullet;
    }

    public void Release(GameObject bullet)
    {
        Destroy(bullet);
    }



    //private bool checkPlayerBullets()
    //{

    //    for(GameObject bullet in playerBullets)
    //    {
    //        if()
    //    }
    //}

    public GameObject TakeBullet(BulletTypeEnum bulletType)
    {
        GameObject bullet;
        switch (bulletType)
        {
            case BulletTypeEnum.PlayerButtlet:
                if (playerBullets.Count > 0)
                {
                    bullet = playerBullets.Pop();
                }
                else
                {
                    bullet = GetBullet(BulletTypeEnum.PlayerButtlet);
                }
                break;
            case BulletTypeEnum.EnemyBullet:
                if (enemyBullets.Count > 0)
                {
                    bullet = enemyBullets.Pop();
                }
                else
                {
                    bullet = GetBullet(BulletTypeEnum.EnemyBullet);
                }
                break;
            default:
                bullet = null;
                break;
        }
        //bullet.SetActive(true);
        return bullet;
    }

    public void PutBackBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        switch (bullet.GetComponent<Bullet>().BulletType)
        {
            case BulletTypeEnum.PlayerButtlet:
                playerBullets.Push(bullet);       
                break;
            case BulletTypeEnum.EnemyBullet:
                enemyBullets.Push(bullet);
                break;
            default:
                break;
        }
    }
}
