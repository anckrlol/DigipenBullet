using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    [SerializeField] Transform menuSelectDarken;
    [SerializeField] Transform currentCanvas;
    int currentMenu = 0;
    Vector2 attackMenuPos = new Vector2(145,-175);
    Vector2 spellsMenuPos = new Vector2(318,-175);
    Vector2 itemMenuPos = new Vector2(491,-175);
    public event Action<string> menuSelected = null;
    public Action<bool> selectorState = null;
    float navigateMenuCooldown = 0.2f;
    float navigateTimer = 0;
    public bool inMenu = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        selectorState += SelectorActiveState;
        attackMenuPos *= currentCanvas.localScale;
        spellsMenuPos *= currentCanvas.localScale;
        itemMenuPos *= currentCanvas.localScale;
    }

    // Update is called once per frame
    void Update(){
        navigateTimer += Time.deltaTime;
        if (turnManager.playerTurn){
            if (!inMenu) SelectorActiveState(true);
            if (Keyboard.current.aKey.isPressed && navigateTimer > navigateMenuCooldown){
                currentMenu--;
                if (currentMenu < 0) currentMenu += 3;
                navigateTimer = 0;
            } else if (Keyboard.current.dKey.isPressed && navigateTimer > navigateMenuCooldown){
                currentMenu++;
                if (currentMenu > 2) currentMenu -= 3;
                navigateTimer = 0;
            } else if (Keyboard.current.enterKey.isPressed && !inMenu){
                if (currentMenu != 2){ //temporarily make items menu not functional
                    SelectorActiveState(false);
                    inMenu = true;
                }
                if (currentMenu == 0){
                    menuSelected?.Invoke("attack");
                } else if (currentMenu == 1){
                    menuSelected?.Invoke("spells");
                } /*else if (currentMenu == 2){
                    menuSelected?.Invoke("items");
                }*/
            }
            
            if (currentMenu == 0){
                menuSelectDarken.position = attackMenuPos;
            } else if (currentMenu == 1){
                menuSelectDarken.position = spellsMenuPos;
            } else if (currentMenu == 2){
                menuSelectDarken.position = itemMenuPos;
            }
        } else {
            SelectorActiveState(false);
        }
    }

    void SelectorActiveState(bool state){
        menuSelectDarken.gameObject.SetActive(state);
    }
}
