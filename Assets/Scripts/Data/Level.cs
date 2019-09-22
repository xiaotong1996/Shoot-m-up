using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("LevelDescription")]
[XmlType("LevelDescription")]
public struct LevelDescription
{
    [XmlAttribute]
    public string Name
    {
        get;
        set;
    }

    [XmlAttribute]
    public int Duration
    {
        get;
        set;
    }

    [XmlElement("EnemyDescription", typeof(EnemyDescription))]
    public List<EnemyDescription> Enemies
    {
        get;
        set;
    }
}

[XmlRoot("EnemyDescription")]
[XmlType("EnemyDescription")]
public struct EnemyDescription
{

    [XmlElement("SpawnDate", typeof(float))]
    public float EnemySpawnDate;

    [XmlElement("SpawnPosition", typeof(Vector2))]
    public Vector2 EnemySpawnPosition;

    [XmlElement("PrefabPath", typeof(string))]
    public string PrefabPath;

    //public bool isSpawn;

}

[System.Serializable]
public class Level 
{
    [SerializeField]
    public LevelDescription Definition;

    List<EnemyDescription> EnemiesNeedSpawn {
        get;
        set;
    }

    float StartTime
    {
        get;
        set;
    }

    

    public void Load(LevelDescription description)
    {
        EnemiesNeedSpawn = description.Enemies;
        StartTime = Time.time;
    }

    public void Execute()
    {
        List<EnemyDescription> enemiesTem = new List<EnemyDescription>();
        float timePassed = Time.time - this.StartTime;
        //Debug.Log(timePassedSinceBeginning);
        foreach (EnemyDescription enemy in EnemiesNeedSpawn)
        {
            
            if (timePassed >= enemy.EnemySpawnDate)
            {
                Spawn(enemy);
            }
            else
            {
                enemiesTem.Add(enemy);
                continue;
            }
        }
        EnemiesNeedSpawn = enemiesTem;
    }

    public void Spawn(EnemyDescription enemyDescription)
    {
        GameObject enemy = EnemyFactory.Instance.GetEnemy();
        // TODO
        // enemyDescription.PrefabPath not used, cause in EnemyFactory have only one type of enemy
        enemy.GetComponent<Transform>().position = enemyDescription.EnemySpawnPosition;
        enemy.SetActive(true);
    }

    public bool IsFinished(LevelDescription description)
    {
        float timePassed = Time.time - this.StartTime;
        if (timePassed >= description.Duration)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
