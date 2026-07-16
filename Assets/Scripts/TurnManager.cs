using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    TestEnemyScript enemyAttack;
    public bool playerTurn = true;
    public bool enemyTurn = false;
    Color inactive = new Color(255,255,255,0);
    Color active = new Color(255,255,255,255);
    SpriteRenderer playerActive;
    SpriteRenderer enemyActive;
    public Action startEnemyTurn;
    public Action<bool> playerTurnState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        playerActive = player.GetComponent<SpriteRenderer>();
        enemyActive = enemy.GetComponent<SpriteRenderer>();
        enemyAttack = enemy.GetComponent<TestEnemyScript>();
        startEnemyTurn += StartEnemyAttack;
        playerTurnState += PlayerTurn;
        playerTurnState.Invoke(true);
    }

    // Update is called once per frame
    void Update(){
        /*
        if (playerTurn){
            Debug.Log("2");
            enemyActive.color = active;
            playerActive.color = inactive;
            enemyTurn = false;
            teleportOnce = true;
            playerTurn = false;
        } else {
            Debug.Log("1");
            enemyActive.color = inactive;
            playerActive.color = active;
            if (teleportOnce) {
                player.transform.position = new Vector2(-2.75f, -3);
                enemyTurn = true;
            }
            teleportOnce = false;
        }*/
    }

    void StartEnemyAttack(){
        playerTurn = false;
        enemyTurn = true;
        enemyAttack.beginAttack?.Invoke();
        enemyActive.color = inactive;
        playerActive.color = active;
        player.transform.position = new Vector2(-2.75f, -3);
    }

    void PlayerTurn(bool state){
        if (state){
            enemyActive.color = active;
            playerActive.color = inactive;
            playerTurn = true;
        } else {
            playerTurn = false;
            enemyTurn = true;
        }
    }
}
