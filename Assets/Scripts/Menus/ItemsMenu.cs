using UnityEngine;
using UnityEngine.InputSystem;

public class ItemsMenu : MonoBehaviour{
    [SerializeField] private MenuNavigation menuNavigation;
    [SerializeField] private CombatLog combatLog;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private PlayerHandler playerHandler;
    private Item burger;
    private Item healthPot;
    private bool onItemsMenu = false;
    private const string TabSpace = "   ";
    private float backOutCooldown = 0.25f;
    private float backOutTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        burger = new Item("Burger", 1, 3);
        healthPot = new Item("Health Potion", 2, 1);
        menuNavigation.menuSelected += DisplayItems;
    }

    // Update is called once per frame
    void Update(){
        backOutTimer += Time.deltaTime;
        if (onItemsMenu){
            if (Keyboard.current.eKey.isPressed){
                UseItem(burger);
            } else if (Keyboard.current.rKey.isPressed){
                UseItem(healthPot);
            }

            if (Keyboard.current.backspaceKey.isPressed && backOutTimer > backOutCooldown){
                backOutTimer = 0;
                combatLog.DisplayLog();
                menuNavigation.selectorState.Invoke(true);
                menuNavigation.inMenu = false;
                onItemsMenu = false;
            }
        }
    }

    void DisplayItems(string menu){
        if (menu == "items"){
            string burgerStats = $"x{burger.GetItemCount()} {burger.GetItemName()} (E key)\n{TabSpace} Heal {burger.GetHealAmount()} heart";
            string healthPotStats = $"x{healthPot.GetItemCount()} {healthPot.GetItemName()} (R key)\n{TabSpace} Heal {healthPot.GetHealAmount()} hearts";
            combatLog.DisplayMenu($"{burgerStats}\n{healthPotStats}");
            onItemsMenu = true;
        }
    }

    void UseItem(Item item){
        if (!playerHandler.AtMaxHealth()){
            turnManager.startEnemyTurn.Invoke();
            turnManager.playerTurnState.Invoke(false);
            item.Heal();
            onItemsMenu = false;
            menuNavigation.inMenu = false;
        }
    }
}
