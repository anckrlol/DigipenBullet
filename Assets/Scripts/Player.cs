using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{
    private int maxHealth = 5;
    private int currentHealth;
    private int attackDamage;
    private Rigidbody2D rb; 
    public Action<string, int> useSpell;
    public Action<string, int> useItem;
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        useItem += ItemUsed;
        useSpell += SpellUsed;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    void ItemUsed(string name, int healAmount){
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        Debug.Log($"{name} healed {healAmount}, HP: {currentHealth}/{maxHealth}");
    }

    void SpellUsed(string name, int damageAmount){
        if (damageAmount < 0){ 
            useItem.Invoke(name, -damageAmount);
        } else {
            enemy.incomingDamage.Invoke(name, damageAmount);
        }
    }
}
