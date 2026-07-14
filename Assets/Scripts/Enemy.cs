using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHealth = 50;
    private int currentHealth;
    public Action<string, int> incomingDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        incomingDamage += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(string spellName, int damageAmount){
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        Debug.Log($"{spellName} dealt {damageAmount}, HP: {currentHealth}/{maxHealth}");
    }
}
