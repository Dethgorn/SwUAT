using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UnityIntEvent : UnityEvent<int> { }
public class PlayerHealth : MonoBehaviour
{
    [Header("Health and Shields")]
    [SerializeField, Tooltip("The player's maximum hit point setting")] private int playerMaxHealth;
    [SerializeField, Tooltip("The player's current hit point value")] private int playerCurrentHealth;
    [Space(10)]
    [SerializeField, Tooltip("The player's maximum shield point setting")] private int playerMaxShields;
    [SerializeField, Tooltip("The player's current shield point setting")] private int playerCurrentShields;
    [HideInInspector]
    public UnityIntEvent OnHealthChange = new UnityIntEvent();

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    private void Update()
    {
        GetHealth();
    }

    /// <summary>
    /// Retrieves player's current health from private variable.
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return playerCurrentHealth;
    }


    /// <summary>
    /// Sets the player's current health private variable by passing in an integer.
    /// </summary>
    /// <param name="hp"></param>
    public void SetHealth(int hp)
    {
        Debug.Log(playerCurrentHealth);
        // make sure we don't go over the max
        if ((hp + playerCurrentHealth) <= playerMaxHealth)
        {
            playerCurrentHealth += hp;
            OnHealthChange.Invoke(playerCurrentHealth);
            
        }
    }

    /// <summary>
    /// Retrieves the player's current shields from private variable.
    /// </summary>
    /// <returns></returns>
    public int GetShields()
    {
        return playerCurrentShields;
    }

    /// <summary>
    /// Sets the player's current shields private variable by passing in an integer.
    /// </summary>
    /// <param name="shields"></param>
    public void SetShields(int shields)
    {
        if (shields < playerMaxShields)
        {
            playerCurrentShields = shields;
        }
    }


}
