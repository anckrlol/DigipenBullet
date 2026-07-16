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

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackEnemy(string menu){
        if (menu.Equals("attack")){
            turnManager.startEnemyTurn.Invoke();
            turnManager.playerTurnState.Invoke(false);
            enemy.incomingDamage?.Invoke(damage);
            menuNavigation.inMenu = false;
            combatLog.incomingLog?.Invoke($"You dealt {damage} damage!");
        }
    }
}
