using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject player;
    public Slider healthSlider;
    public Slider energySlider;
    public Text Score;
    public GameObject FinalResult;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.GameState)
        {
            case GameState.WIN:
                FinalResult.GetComponent<Text>().text = "YOU WIN";
                FinalResult.SetActive(true);
                break;
            case GameState.LOSS:
                FinalResult.GetComponent<Text>().text = "YOU LOSE!";
                FinalResult.SetActive(true);
                break;
            case GameState.RUNNING:
                // Debug.Log(player.GetComponent<PlayerAvatar>().Health);
                healthSlider.value = player.GetComponent<PlayerAvatar>().Health;
                energySlider.value = player.GetComponent<Energy>().EnergyLeft;
                Score.text = GameManager.Score.ToString();
                break;
            default:
                break;
        }   
    }

}
