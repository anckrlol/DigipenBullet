using System;
using System.Collections;
using UnityEngine;

public class TurnManager : MonoBehaviour{
    GameObject player;
    GameObject enemy;
    Enemy enemyState;
    TestEnemyScript enemyAttack;
    public bool playerTurn = true;
    public bool enemyTurn = false;
    Color inactive = new Color(255,255,255,0);
    Color active = new Color(255,255,255,255);
    SpriteRenderer playerActive;
    SpriteRenderer enemyActive;
    public Action startEnemyTurn;
    public Action<bool> playerTurnState;
    Vector2 playerStartPosition = new Vector2(-2.75f, -3);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        playerActive = player.GetComponent<SpriteRenderer>();
        enemyActive = enemy.GetComponent<SpriteRenderer>();
        enemyAttack = enemy.GetComponent<TestEnemyScript>();
        enemyState = enemy.GetComponent<Enemy>();
        startEnemyTurn += StartEnemyAttack;
        playerTurnState += PlayerTurn;
        playerTurnState.Invoke(true);
    }

    void StartEnemyAttack(){
        StartCoroutine(AttackBuffer());
    }

    void PlayerTurn(bool state){
        if (state){
            enemyActive.enabled = true;
            playerActive.enabled = false;
            playerTurn = true;
        } else {
            playerTurn = false;
            enemyTurn = true;
        }
    }

    IEnumerator AttackBuffer(){
        yield return new WaitForSeconds(0.1f);
        if (!enemyState.dead){
            playerTurn = false;
            enemyTurn = true;
            enemyAttack.beginAttack?.Invoke();
            enemyActive.enabled = false;
            playerActive.enabled = true;
            player.transform.position = playerStartPosition;
        }
    }
}
