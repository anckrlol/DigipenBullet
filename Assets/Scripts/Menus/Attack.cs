using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private MenuNavigation menuNavigation;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private TurnManager turnManager;
    private Enemy enemy;
    private int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuNavigation.menuSelected += AttackEnemy;
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    void AttackEnemy(string menu){
        if (menu.Equals("attack")){
            combatLog.incomingLog?.Invoke($"You dealt {damage} damage!");
            enemy.incomingDamage?.Invoke(damage);
            turnManager.startEnemyTurn.Invoke();
            turnManager.playerTurnState.Invoke(false);
            menuNavigation.inMenu = false;
        }
    }
}
