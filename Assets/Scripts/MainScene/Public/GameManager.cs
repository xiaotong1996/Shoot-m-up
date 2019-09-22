using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    WIN,
    LOSS,
    RUNNING
}

public class GameManager : MonoBehaviour
{
    private List<LevelDescription> levelDescriptions;
    public LevelDescription Data;
    public Level CurrentLevel;
    private int levelDescriptionsIndex;

    [SerializeField]
    private TextAsset myXmlFileAsset;

    [SerializeField]
    private float enemySpawnSpeed = 5f;
    [SerializeField]
    private float enemySpawnNumber = 1f;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    private static GameManager instance;

    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float downBorder;

    private static readonly object locker = new object();

    private static int score = 0;
    private GameState gameState;

    public static int Score { get => score; set => score = value; }
    public static GameManager Instance { get => instance; private set => instance = value; }
    public float EnemySpawnSpeed { get => enemySpawnSpeed; set => enemySpawnSpeed = value; }
    public float EnemySpawnNumber { get => enemySpawnNumber; set => enemySpawnNumber = value; }
    public GameState GameState { get => gameState; set => gameState = value; }



    //private void OnEnable()
    //{
    //    EventManager.onPlayerDeathEvent += GameOver;
    //}

    //private void OnDisable()
    //{
    //    EventManager.onPlayerDeathEvent -= GameOver;
    //}

    private GameManager()
    {

    }

    //public static GameManager GetInstance()
    //{
    //    if (Instance == null)
    //    {
    //        lock (locker)
    //        {
    //            if (Instance == null)
    //            {
    //                Instance = new GameManager();
    //            }
    //        }
    //    }
    //    return Instance;
    //}

    private void GetBorders()
    {
        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));

        leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        rightBorder = cornerPos.x;
        topBorder = cornerPos.y;
        downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);

        //Debug.Log("leftBorder  :  " + leftBorder);
        //Debug.Log("rightBorder  :  " + rightBorder);
        //Debug.Log("topBorder  :  " + topBorder);
        //Debug.Log("downBorder  :  " + downBorder);
    }

    public void InitalPlayer()
    {
        GameObject.Instantiate(playerPrefab, new Vector3(leftBorder+0.2f*(rightBorder-leftBorder), transform.position.y, 0), Quaternion.identity);
    }

    public void InitalEnemies()
    {
        InvokeRepeating("CreateEnemy", EnemySpawnNumber, EnemySpawnSpeed);
    }

    public void CreateEnemy()
    {
        float y = Random.Range(downBorder, topBorder);
        //GameObject.Instantiate(enemyPrefab, new Vector3(rightBorder, y, 0), Quaternion.identity);
        GameObject enemy = EnemyFactory.Instance.GetEnemy();
        enemy.GetComponent<Transform>().position = new Vector3(rightBorder, y, 0);
        enemy.SetActive(true);
    }

    void Awake()
    {
        if (Instance == null)
        {
            lock (locker)
            {
                if (Instance == null)
                {
                    GameManager.Instance = this;
                }
            }
        }
        GetBorders();
        InitalPlayer();
        EventManager.onPlayerDeathEvent += GameOver;
        EventManager.onEnemyDeathEvent += ScoreAdd;
        LoadLevel();
        CurrentLevel = new Level();
        levelDescriptionsIndex = 0;
        GameState = GameState.RUNNING;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Traditional random Method to create enemies 
        //InitalEnemies();

        CurrentLevel.Load(levelDescriptions[levelDescriptionsIndex]);
        
    }

    void StartNewLevel()
    {
        CurrentLevel.Load(levelDescriptions[levelDescriptionsIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLevel.Execute();
        if (CurrentLevel.IsFinished(levelDescriptions[levelDescriptionsIndex]))
        {
            levelDescriptionsIndex++;
            if(levelDescriptionsIndex>=levelDescriptions.Count)
            {
                WIN();
            }
            StartNewLevel();
        }
    }

    void WIN()
    {
        GameState = GameState.WIN;

        Time.timeScale = 0;

        //Application.Quit();
    }

    public void ScoreAdd()
    {
        Score++;
    }

    public void GameOver()
    {
        GameState = GameState.LOSS;
        //Application.Quit();
        Time.timeScale = 0;
    }

    public void LoadLevel()
    {
        levelDescriptions = XmlHelpers.DeserializeDatabaseFromXML<LevelDescription>(myXmlFileAsset);
        Debug.Assert(levelDescriptions != null);
    }
}
