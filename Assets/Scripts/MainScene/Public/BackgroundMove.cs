using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed=1f;

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameState==GameState.LOSS|| GameManager.Instance.GameState == GameState.WIN)
        {
            Speed = 0;
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
