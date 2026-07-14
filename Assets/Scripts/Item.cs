using UnityEngine;

/// <summary>
/// Provides a <i>healAmount</i> variable to determine the heal of the item.
/// </summary>
public class Item : MonoBehaviour{
    [SerializeField] private string name;
    [SerializeField] private int healAmount;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Heal(){
        player.useItem.Invoke(name, healAmount);
    }
}
