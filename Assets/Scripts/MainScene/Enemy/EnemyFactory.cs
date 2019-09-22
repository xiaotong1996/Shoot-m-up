using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory instance;

    public static EnemyFactory Instance { get => instance;private set => instance = value; }

    public GameObject enemyPrefab;

    private Stack<GameObject> enemies = new Stack<GameObject>();

    private void Awake()
    {
        Debug.Assert(EnemyFactory.Instance == null);
        EnemyFactory.Instance = this;
    }

    public GameObject GetEnemy()
    {
        GameObject enemy;
        if (enemies.Count > 0)
        {
            enemy = enemies.Pop();
        }
        else
        {
            enemy= (GameObject)Instantiate(enemyPrefab);
        }
        enemy.SetActive(false);
        return enemy;
    }

    public void PutBackEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemies.Push(enemy);
    }

    public void Release(GameObject enemy)
    {
        Destroy(enemy);
    }
}
