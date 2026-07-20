using UnityEngine;
using System.Collections;
using System;

public class TestEnemyScript : MonoBehaviour
{
    [SerializeField] private BulletPatterns johnBullets;
    [SerializeField] private TurnManager turnManager;
    public Action beginAttack;
    private Enemy enemyState;

    void Start(){
        beginAttack += EnemyTurn;
        enemyState = GetComponent<Enemy>();
    }

    public IEnumerator Attack()
    {
        StartCoroutine(johnBullets.BasicWave(0.3f));
        yield return new WaitForSeconds(5);
        StartCoroutine(johnBullets.WallShoot(0.4f));
        yield return new WaitForSeconds(8);
    }
    
    IEnumerator AttackFinished(){
        yield return new WaitForSeconds(15);
        turnManager.playerTurnState?.Invoke(true);
    }
    
    void EnemyTurn(){
        if (!enemyState.dead){
            StartCoroutine(Attack());
            StartCoroutine(AttackFinished());
        }
    }
}
