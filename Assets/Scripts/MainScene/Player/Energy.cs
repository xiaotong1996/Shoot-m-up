using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField]
    private float energyDodge = 40f;

    [SerializeField]
    private bool energyReady=true;

    [SerializeField]
    private float energyLeft = 100f;

    [SerializeField]
    private float energyMax=100f;

    [SerializeField]
    private float rechargeSpeed = 20f;

    private Dodge dodge;


    public float EnergyMax { get => energyMax; set => energyMax = value; }
    public float RechargeSpeed { get => rechargeSpeed; set => rechargeSpeed = value; }
    public float EnergyLeft { get => energyLeft; set => energyLeft = value; }
    public bool EnergyReady { get => energyReady; set => energyReady = value; }
    public float EnergyDodge { get => energyDodge; set => energyDodge = value; }

    private void Awake()
    {
        EventManager.onDoublePressedEvent += ConsumeForDodge;
    }
    private void Start()
    {
        dodge = GetComponent<Dodge>();
    }

    public void ConsumeForDodge()
    {
        if (EnergyLeft >= EnergyDodge)
        {
            Consume(EnergyDodge);
            dodge.CallDodge();
        }
    }

    public void Consume(float energyConsumed)
    {
        if (EnergyLeft <= 0)
        {
            EnergyReady = false;
        }
        if (EnergyReady==false)
        {
            ForceRecharge();
        }
        
        EnergyLeft -= energyConsumed;
       
    }

    public void ForceRecharge()
    {
       
        if(EnergyLeft <= EnergyMax)
        {
            EnergyLeft += RechargeSpeed * Time.deltaTime * 0.75f;
            EnergyReady = false;
            //Debug.Log("ForceRecharge");
        }
        else
        {
            EnergyReady = true;
        }
    }

    public void Recharge()
    {
        
        if (EnergyLeft<=EnergyMax)
        {
            //Debug.Log("Recharge");
            EnergyLeft += RechargeSpeed * Time.deltaTime;
        }
        
    }

    

}
