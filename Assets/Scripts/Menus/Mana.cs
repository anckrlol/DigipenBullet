using System;
using UnityEngine;

public class Mana : MonoBehaviour{
    [SerializeField] Transform manaBar;
    public Action parried = null;
    public Action<int> usedSpell = null;
    private int currentMana = 0;
    private int maxMana = 100;
    private float startingXScale;
    private float leftAlignX = 390;
    private float centerX = 475;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        parried += GainMana;
        usedSpell += UseMana;
        startingXScale = manaBar.localScale.x;
        ManaChange(0);
    }

    void ManaChange(int amt){
        currentMana = Mathf.Clamp(currentMana + amt, 0, maxMana);
        float percentage = (float)currentMana / maxMana;
        manaBar.localScale = new Vector2(startingXScale * percentage, manaBar.localScale.y);
        manaBar.localPosition = new Vector2(Mathf.Lerp(leftAlignX, centerX, percentage), manaBar.localPosition.y);
    }

    void GainMana(){
        ManaChange(20);
    }

    void UseMana(int cost){
        if (SufficientMana(cost)) ManaChange(-cost);
    }

    public bool SufficientMana(int cost){
        return currentMana >= cost;
    }
}
