using UnityEngine;

/// <summary>
/// Provides a <i>healAmount</i> variable to determine the heal of the item.
/// </summary>
public class Item{
    private string itemName;
    private int healAmount;
    private PlayerHandler player;

    public Item(string itemName, int healAmount){
        this.itemName = itemName;
        this.healAmount = healAmount;
    }
    
    public void Heal(){
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHandler>();
        player.useItem?.Invoke(itemName, healAmount);
    }
}
