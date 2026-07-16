using UnityEngine;

/// <summary>
/// Provides a <i>healAmount</i> variable to determine the heal of the item.
/// </summary>
public class Item{
    private string itemName;
    private int healAmount;
    private Player player;

    public Item(string itemName, int healAmount){
        this.itemName = itemName;
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
        player.useItem?.Invoke(itemName, healAmount);
    }
}
