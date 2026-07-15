using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{
    private int maxHealth = 5;
    private int currentHealth;
    private int attackDamage;
    [SerializeField] private float moveSpeed = 5;
    private Rigidbody2D rb; 
    public Action<string, int> useSpell = null;
    public Action<string, int> useItem = null;
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        useItem += ItemUsed;
        useSpell += SpellUsed;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update(){
        /*
        if (Keyboard.current.leftArrowKey.isPressed){
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        } 
        if (Keyboard.current.rightArrowKey.isPressed){
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        } 
        if (Keyboard.current.upArrowKey.isPressed){
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        } 
        if (Keyboard.current.downArrowKey.isPressed){
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }*/
    }

    void ItemUsed(string name, int healAmount){
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
        Debug.Log($"{name} healed {healAmount}, HP: {currentHealth}/{maxHealth}");
    }

    void SpellUsed(string name, int damageAmount){
        if (damageAmount < 0){ 
            Debug.Log(useItem);
            ItemUsed(name, -damageAmount);
        } else {
            enemy.incomingDamage?.Invoke(name, damageAmount);
        }
    }
}
