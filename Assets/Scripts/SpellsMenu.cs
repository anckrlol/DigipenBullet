using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsMenu : MonoBehaviour{
    private Spell fireballSpell;
    private Spell rejuvSpell;
    private TMP_Text actionLog;
    private bool onSpellsMenu = false;
    private string tabSpace = "    ";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionLog = transform.parent.GetChild(6).GetComponent<TMP_Text>();
        fireballSpell = new Spell("Fireball", 15);
        rejuvSpell = new Spell("Rejuvenation", -2);
    }

    // Update is called once per frame
    void Update()
    {
        if (onSpellsMenu) UseSpells();
    }

    public void DisplaySpells(){
        Debug.Log("Spells menu selected");
        actionLog.text = $"Fireball (E)\n{tabSpace}15 damage, 5 mana\nRejuvenation (R)\n{tabSpace}Heal 1, 6 mana";
        onSpellsMenu = true;
    }

    void UseSpells(){
        if (Keyboard.current.eKey.isPressed){
            Debug.Log("Used fireball");
            fireballSpell.Attack();
            onSpellsMenu = false;
            actionLog.text = "";
        } else if (Keyboard.current.rKey.isPressed){
            Debug.Log("Used rejuvenation");
            rejuvSpell.Attack();
            onSpellsMenu = false;
            actionLog.text = "";
        }
    }
}
