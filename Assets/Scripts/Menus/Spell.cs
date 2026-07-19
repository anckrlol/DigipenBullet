using UnityEngine;

/// <summary>
/// Acts as a base to create any spell, damaging or healing.
/// </summary>
public class Spell{
    private string spellName;
    /// <summary>
    /// Positive is damage, negative is heal
    /// </summary>
    private int damage;
    private int manaCost;
    private PlayerHandler player;

    public Spell(string spellName, int damage, int manaCost){
        this.spellName = spellName;
        this.damage = damage;
        this.manaCost = manaCost;
    }

    public void Attack(){
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHandler>();
        player.useSpell?.Invoke(spellName, damage, manaCost);
    }

    public string GetSpellName(){ 
        return spellName;
    }

    public int GetSpellDamage(){
        return Mathf.Abs(damage);
    }

    public int GetManaCost(){
        return manaCost;
    }
}
