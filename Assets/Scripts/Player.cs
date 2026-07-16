using System;
using UnityEngine;

public class Player : MonoBehaviour{
    private int maxHealth = 5;
    private int currentHealth;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private Transform heartsContainer;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    public Action<string, int> useSpell = null;
    public Action<string, int> useItem = null;
    public Action<int> hitByBullet = null;
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        useItem += ItemUsed;
        useSpell += SpellUsed;
        hitByBullet += ChangeHealth;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    void ItemUsed(string name, int healAmount){
        ChangeHealth(healAmount);
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

    void ChangeHealth(int change){
        currentHealth = Mathf.Clamp(currentHealth + change, 0, maxHealth);
        for (int i = 0; i < maxHealth; i++){
            SpriteRenderer heartSprite = heartsContainer.GetChild(i).GetComponent<SpriteRenderer>();
            if (i >= currentHealth) heartSprite.sprite = emptyHeart;
            else heartSprite.sprite = fullHeart;
        }
    }
}
