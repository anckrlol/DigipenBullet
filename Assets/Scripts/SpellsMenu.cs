using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsMenu : MonoBehaviour{
    [SerializeField] private MenuNavigation menuNavigation;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private TurnManager turnManager;
    private Spell fireballSpell;
    private Spell rejuvSpell;
    private bool onSpellsMenu = false;
    private string tabSpace = "    ";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        fireballSpell = new Spell("Fireball", 15);
        rejuvSpell = new Spell("Rejuvenation", -2);
        menuNavigation.menuSelected += DisplaySpells;
    }

    // Update is called once per frame
    void Update(){
        if (onSpellsMenu){
            if (Keyboard.current.eKey.isPressed){
                AttackWithSpell(fireballSpell);
            } else if (Keyboard.current.rKey.isPressed){
                AttackWithSpell(rejuvSpell);
            }

            if (Keyboard.current.backspaceKey.isPressed){
                combatLog.DisplayLog();
                menuNavigation.selectorState.Invoke(true);
                menuNavigation.inMenu = false;
            }
        }
    }

    void DisplaySpells(string menu){
        if (menu == "spells"){
            combatLog.DisplayMenu($"Fireball (E)\n{tabSpace} 15 damage\nRejuvenation (R)\n{tabSpace} Heal 1");
            onSpellsMenu = true;
        }
    }

    void AttackWithSpell(Spell spell){
        turnManager.startEnemyTurn.Invoke();
        turnManager.playerTurnState.Invoke(false);
        spell.Attack();
        onSpellsMenu = false;
        menuNavigation.inMenu = false;
    }
}
