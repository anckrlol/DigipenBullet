using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsMenu : MonoBehaviour{
    [SerializeField] private MenuNavigation menuNavigation;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private Mana manaHandler;
    [SerializeField] private PlayerHandler playerHandler;
    private Spell fireballSpell;
    private Spell rejuvSpell;
    private bool onSpellsMenu = false;
    private const string TabSpace = "    ";
    private float backOutCooldown = 0.25f;
    private float backOutTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        fireballSpell = new Spell("Fireball", 15, 40);
        rejuvSpell = new Spell("Rejuvenation", -2, 80);
        menuNavigation.menuSelected += DisplaySpells;
    }

    // Update is called once per frame
    void Update(){
        backOutTimer += Time.deltaTime;
        if (onSpellsMenu){
            if (Keyboard.current.eKey.isPressed){
                AttackWithSpell(fireballSpell);
            } else if (Keyboard.current.rKey.isPressed){
                AttackWithSpell(rejuvSpell);
            }

            if (Keyboard.current.backspaceKey.isPressed && backOutTimer > backOutCooldown){
                backOutTimer = 0;
                combatLog.DisplayLog();
                menuNavigation.selectorState.Invoke(true);
                menuNavigation.inMenu = false;
                onSpellsMenu = false;
            }
        }
    }

    void DisplaySpells(string menu){
        if (menu == "spells"){
            string fireballStats = $"{fireballSpell.GetSpellName()} (E key)\n";
            fireballStats += $"{TabSpace} {fireballSpell.GetSpellDamage()} damage, {fireballSpell.GetManaCost()} mana";
            string rejuvStats = $"{rejuvSpell.GetSpellName()} (R key)\n";
            rejuvStats += $"{TabSpace} Heal {Mathf.Abs(rejuvSpell.GetSpellDamage())} hearts, {rejuvSpell.GetManaCost()} mana";
            combatLog.DisplayMenu($"{fireballStats}\n{rejuvStats}");
            onSpellsMenu = true;
        }
    }

    void AttackWithSpell(Spell spell){
        if (manaHandler.SufficientMana(spell.GetManaCost())){
            //Check for if the spell is a heal spell, if the player is at full health, do not use the spell
            if (spell.GetSpellDamage() > 0 || (spell.GetSpellDamage() < 0 && !playerHandler.AtMaxHealth())){
                manaHandler.usedSpell.Invoke(spell.GetManaCost());
                turnManager.startEnemyTurn.Invoke();
                turnManager.playerTurnState.Invoke(false);
                spell.Attack();
                onSpellsMenu = false;
                menuNavigation.inMenu = false;
            }
        }
    }
}