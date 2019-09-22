using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField]
    private float timer=5f;

    [SerializeField]
    private bool active=true;

    public float Timer { get => timer; set => timer = value; }
    public bool Active { get => active; set => active = value; }

    private float timeFix;
    // Start is called before the first frame update
    void Start()
    {
        timeFix = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active&&Timer>0)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer < 0)
        {
            Timer = 0;
        }
    }

    public bool Ready()
    {
        return Timer == 0 ? true : false;
    }

    public void Reset()
    {
        Timer = timeFix;
    }
}
