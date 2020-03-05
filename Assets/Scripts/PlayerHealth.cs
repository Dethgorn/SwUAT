using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UnityFloatEvent : UnityEvent<float> { }
public class PlayerHealth : MonoBehaviour
{
    [Header("Health and Shields")]
    [SerializeField, Tooltip("The player's maximum hit point setting")] private float playerMaxHealth;
    [SerializeField, Tooltip("The player's current hit point value")] private float playerCurrentHealth;
    [Space(10)]
    [SerializeField, Tooltip("The player's maximum shield point setting")] private float playerMaxShields;
    [SerializeField, Tooltip("The player's current shield point setting")] private float playerCurrentShields;
    private GameObject character;


    [HideInInspector]
    public UnityFloatEvent OnHealthChange = new UnityFloatEvent();
    public UnityEvent onDie;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        character = this.gameObject;
    }

    private void Update()
    {
        GetHealth();
    }

    /// <summary>
    /// Retrieves player's current health from private variable.
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return playerCurrentHealth;
    }

    /// <summary>
    /// Retrieves the player's current shields from private variable.
    /// </summary>
    /// <returns></returns>
    public float GetShields()
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

    public void Heal(float hpGained)
    {
        // check for overhealing
        if ((hpGained + playerCurrentHealth) <= playerMaxHealth)
        {
            // add shield mechanic here
        }

        // add hp
        playerCurrentHealth += hpGained;
        // give it a clamp
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);
        OnHealthChange.Invoke(playerCurrentHealth);

        
    }

    public void TakeDamage(float amountOfDamage)
    {
        playerCurrentHealth -= amountOfDamage;
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);
        OnHealthChange.Invoke(playerCurrentHealth);
        if (playerCurrentHealth <= 0)
        {
            onDie.Invoke();
            // despawn
            Destroy(character, 2f);
        }
    }
}
