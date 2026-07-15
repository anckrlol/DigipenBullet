using UnityEngine;

/// <summary>
/// Provides a <i>healAmount</i> variable to determine the heal of the item.
/// </summary>
public class Item : ScriptableObject{
    private string spellName;
    private int healAmount;
    private Player player;

    public Item(string spellName, int healAmount){
        this.spellName = spellName;
        this.healAmount = healAmount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Heal(){
        Debug.Log(player.useItem == null);
        player.useItem?.Invoke(name, healAmount);
    }
}
