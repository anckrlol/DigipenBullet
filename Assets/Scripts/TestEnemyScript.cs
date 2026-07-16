using UnityEngine;
using System.Collections;
using System;

public class TestEnemyScript : MonoBehaviour
{

    [SerializeField] private BulletPatterns johnBullets;
    [SerializeField] private TurnManager turnManager;
    public Action beginAttack;

    void Start()
    {
        //StartCoroutine(Attack());
        beginAttack += EnemyTurn;
    }

    void Update()
    {
        
    }

    public IEnumerator Attack()
    {
        // for(int i = 0; i < 20; i++)
        // {
            StartCoroutine(johnBullets.BasicWave(0.5f));
            yield return new WaitForSeconds(10);
            StartCoroutine(johnBullets.WallShoot(0.5f));
            yield return new WaitForSeconds(10);
        // }
    }
    
    IEnumerator AttackFinished(){
        yield return new WaitForSeconds(24);
        turnManager.playerTurnState?.Invoke(true);
    }
    
    void EnemyTurn(){
        StartCoroutine(Attack());
        StartCoroutine(AttackFinished());
    }
}
