using UnityEngine;

/// <summary>
/// Provides a <i>healAmount</i> variable to determine the heal of the item.
/// </summary>
public class Item{
    private string itemName;
    private int healAmount;
    private int count;
    private PlayerHandler player;

    public Item(string itemName, int healAmount, int itemCount){
        this.itemName = itemName;
        this.healAmount = healAmount;
        count = itemCount;
    }

    public void Heal(){
        count--;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHandler>();
        player.useItem?.Invoke(itemName, healAmount);
    }

    public string GetItemName(){
        return itemName;
    }

    public int GetHealAmount(){
        return healAmount;
    }

    public int GetItemCount(){
        return count;
    }
}
