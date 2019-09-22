using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float shotEnergy=10f;

    private Engines engines;
    private BulletGun bulletGun;
    private Energy energy;
    private Dodge dodge;

    public float ShotEnergy { get => shotEnergy; set => shotEnergy = value; }
    public float TapSpeed { get => tapSpeed; set => tapSpeed = value; }

    [SerializeField]
    private float tapSpeed = 0.5f;

    private float lastTapTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        engines = GetComponent<Engines>();
        bulletGun = GetComponent<BulletGun>();
        energy = GetComponent<Energy>();
        dodge = GetComponent<Dodge>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input and set object's move directions.
        engines.speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Control player's shot and recharge energy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (energy.EnergyReady)
            {
                energy.Consume(shotEnergy);
                bulletGun.Fire();
            }
        }
        else
        {
            energy.Recharge();
        }

        //check if player double pressed keyboards
        if (Input.GetButtonDown("Horizontal") )
        {
            if (Time.time - lastTapTime < tapSpeed)
            {
                EventManager.RaiseOnDoublePressedEvent();
            }
            lastTapTime = Time.time;
        }

        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    if (Time.time - lastTapTime < tapSpeed)
        //    {
        //        EventManager.RaiseOnDoublePressedEvent();
        //    }
        //    lastTapTime = Time.time;
        //}

        if (Input.GetButtonDown("Vertical") )
        {
            if (Time.time - lastTapTime < tapSpeed)
            {
                EventManager.RaiseOnDoublePressedEvent();
            }
            lastTapTime = Time.time;
        }

        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    if (Time.time - lastTapTime < tapSpeed)
        //    {
        //        EventManager.RaiseOnDoublePressedEvent();
        //    }
        //    lastTapTime = Time.time;
        //}


    }
}
