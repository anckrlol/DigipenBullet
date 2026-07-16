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
    private Player player;

    public Spell(string spellName, int damage){
        this.spellName = spellName;
        this.damage = damage;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Debug.Log(player.gameObject);
    }

    public void Attack(){
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.useSpell?.Invoke(spellName, damage);
    }
}
