using System;
using UnityEngine;

public class Enemy : MonoBehaviour{
    private int maxHealth = 50;
    private int currentHealth;
    public Action<int> incomingDamage;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private string enemyName;

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

    void TakeDamage(int damage){
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth <= 0){
            combatLog.incomingLog?.Invoke($"You defeated the {enemyName}!");
        }
    }
}
