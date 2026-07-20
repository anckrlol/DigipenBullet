using System;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField] Transform enemyHealthBar;
    [SerializeField] int maxHealth;
    private int currentHealth;
    public Action<int> incomingDamage;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private string enemyName;
    private float leftAlignX = -385;
    private float centerX = -260;
    public bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        incomingDamage += TakeDamage;
        TakeDamage(0);
    }

    void TakeDamage(int damage){
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        if (currentHealth <= 0){
            dead = true;
            combatLog.incomingLog?.Invoke($"You defeated the {enemyName}!");
        }
        float percentage = (float)currentHealth / maxHealth;
        enemyHealthBar.localScale = new Vector2(percentage, 1);
        enemyHealthBar.localPosition = new Vector2(Mathf.Lerp(leftAlignX, centerX, percentage), enemyHealthBar.localPosition.y);
    }
}
