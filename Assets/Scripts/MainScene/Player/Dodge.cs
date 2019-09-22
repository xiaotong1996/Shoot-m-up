using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    [SerializeField]
    private float dodgeTime = 3f;
    private float dodgeRestTime;
    private bool dodgeReady = true;

    [SerializeField]
    private bool isCalled = false;

    public float DodgeTime { get => dodgeTime; set => dodgeTime = value; }
    public bool DodgeReady { get => dodgeReady; set => dodgeReady = value; }
    public bool IsCalled { get => isCalled; set => isCalled = value; }

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dodgeRestTime = DodgeTime;
    }

    public void CallDodge()
    {
        IsCalled = true;    
    }

    public void EndDodge()
    {
        spriteRenderer.color = Color.white;
        dodgeRestTime = DodgeTime;
        IsCalled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (IsCalled)
        {
            if (DodgeReady)
            {
                spriteRenderer.color = Color.yellow;
                dodgeRestTime -= Time.deltaTime;
                //Debug.Log(dodgeRestTime);
            }
            else
            {
                EndDodge();
            }
        }
        if (dodgeRestTime > 0 && gameObject.GetComponent<Energy>().EnergyLeft > 10f)
        {
            //gameObject.GetComponent<PlayerAvatar>().Health = health;
            DodgeReady = true;
        }
        if (dodgeRestTime <= 0)
        {
            DodgeReady = false;
        }
    }
}
