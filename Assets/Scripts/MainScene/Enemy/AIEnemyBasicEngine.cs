using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    private Vector2 speed;
    private BaseAvatar baseAvatar;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseAvatar = GetComponent<BaseAvatar>();
        maxSpeed = baseAvatar.MaxSpeed;
        speed = new Vector2(-0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Simple AI control enemy move from right to left
        // transform.position = transform.position + new Vector3(speed.x * maxSpeed * Time.deltaTime, 0, 0);
        transform.Translate(new Vector3(speed.x , 0, 0) * maxSpeed * Time.deltaTime);

    }
}
