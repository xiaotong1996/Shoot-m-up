using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPlayerDeathEvent();
    public static event OnPlayerDeathEvent onPlayerDeathEvent;

    public delegate void OnEnemyDeathEvent();
    public static event OnEnemyDeathEvent onEnemyDeathEvent;

    public delegate void OnDoublePressedEvent();
    public static event OnDoublePressedEvent onDoublePressedEvent;


    public static void RaiseOnPlayerDeath()
    {
        onPlayerDeathEvent?.Invoke();
    }

    public static void RaiseOnEnemyDeath()
    {
        onEnemyDeathEvent?.Invoke();
    }

    public static void RaiseOnDoublePressedEvent()
    {
        onDoublePressedEvent?.Invoke();
    }

}
