using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    [SerializeField] Transform menuSelector;
    [SerializeField] Transform currentCanvas;
    [SerializeField] AudioClip menuHoverSound;
    [SerializeField] AudioClip menuSelectSound;
    [SerializeField] Introduction intro;

    int currentMenu = 0;
    Vector2 attackMenuPos = new Vector2(130,-310);
    Vector2 spellsMenuPos = new Vector2(310,-310);
    Vector2 itemMenuPos = new Vector2(490,-310);
    public event Action<string> menuSelected = null;
    public Action<bool> selectorState = null;
    float navigateMenuCooldown = 0.2f;
    float navigateTimer = 0;
    public bool inMenu = false;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        selectorState += SelectorActiveState;
        attackMenuPos *= currentCanvas.localScale;
        spellsMenuPos *= currentCanvas.localScale;
        itemMenuPos *= currentCanvas.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        navigateTimer += Time.deltaTime;
        if (intro.readyToStart && turnManager.playerTurn){
            if (!inMenu){
                SelectorActiveState(true);
                if (Keyboard.current.aKey.isPressed && navigateTimer > navigateMenuCooldown){
                    audioSource.clip = menuHoverSound;
                    audioSource.Play();
                    currentMenu--;
                    if (currentMenu < 0) currentMenu += 3;
                    navigateTimer = 0;
                } else if (Keyboard.current.dKey.isPressed && navigateTimer > navigateMenuCooldown){
                    audioSource.clip = menuHoverSound;
                    audioSource.Play();
                    currentMenu++;
                    if (currentMenu > 2) currentMenu -= 3;
                    navigateTimer = 0;
                } else if (Keyboard.current.enterKey.isPressed){
                    SelectorActiveState(false);
                    inMenu = true;
                    audioSource.clip = menuSelectSound;
                    audioSource.Play();
                    if (currentMenu == 0){
                        menuSelected?.Invoke("attack");
                    } else if (currentMenu == 1){
                        menuSelected?.Invoke("spells");
                    } else if (currentMenu == 2){
                        menuSelected?.Invoke("items");
                    }
                }
            }
            
            if (currentMenu == 0){
                menuSelector.position = attackMenuPos;
            } else if (currentMenu == 1){
                menuSelector.position = spellsMenuPos;
            } else if (currentMenu == 2){
                menuSelector.position = itemMenuPos;
            }
        } else {
            SelectorActiveState(false);
        }
    }

    void SelectorActiveState(bool state){
        menuSelector.gameObject.SetActive(state);
    }
}
