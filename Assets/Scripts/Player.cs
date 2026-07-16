using System;
using UnityEngine;

public class Player : MonoBehaviour{
    private int maxHealth = 5;
    private int currentHealth;
    [SerializeField] private CombatLog combatLog;
    public Action<string, int> useSpell = null;
    public Action<string, int> useItem = null;
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        useItem += ItemUsed;
        useSpell += SpellUsed;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    void ItemUsed(string name, int healAmount){
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        string healedText = $"{name} healed {healAmount} heart";
        if (healAmount > 1) healedText += "s";
        healedText += "!";
        combatLog.incomingLog?.Invoke(healedText);
    }

    void SpellUsed(string name, int damageAmount){
        if (damageAmount < 0){ 
            ItemUsed(name, -damageAmount);
        } else {
            enemy.incomingDamage?.Invoke(damageAmount);
            combatLog.incomingLog?.Invoke($"{name} dealt {damageAmount} damage!");
        }
    }
}
