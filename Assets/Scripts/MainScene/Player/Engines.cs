using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    public Vector2 speed;// speed is controlled by Input
    private BaseAvatar baseAvatar;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseAvatar = GetComponent<BaseAvatar>();
        maxSpeed=baseAvatar.MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // control object's position accronding to Input
        //transform.position = transform.position + new Vector3(speed.x * maxSpeed * Time.deltaTime,speed.y * maxSpeed * Time.deltaTime,0);
        transform.Translate(new Vector3(speed.x , speed.y , 0) * maxSpeed * Time.deltaTime);
    }
}
