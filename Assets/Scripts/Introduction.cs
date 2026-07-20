using System.Collections;
using UnityEngine;

public class Introduction : MonoBehaviour{
    [SerializeField] bool loadIntro = true;
    private CombatLog combatLog;
    private SceneLoader sceneLoader;
    public bool readyToStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        combatLog = GetComponent<CombatLog>();
        sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
        if (sceneLoader.firstTime && loadIntro) StartCoroutine(DisplayIntro());
        else readyToStart = true;
    }

    IEnumerator DisplayIntro(){
        yield return new WaitForSeconds(1);
        combatLog.incomingLog.Invoke("* Welcome!");
        yield return new WaitForSeconds(2);
        AddSpace();
        combatLog.incomingLog.Invoke("* You're here to have a");
        combatLog.incomingLog.Invoke("showdown with the Gym Reaper.");
        yield return new WaitForSeconds(4);
        AddSpace();
        combatLog.incomingLog.Invoke("* During your turn, use A and D");
        combatLog.incomingLog.Invoke("to naviagte through the menus.");
        yield return new WaitForSeconds(4);
        AddSpace();
        combatLog.incomingLog.Invoke("* Press ENTER to enter the");
        combatLog.incomingLog.Invoke("menus and BACKSPACE to");
        combatLog.incomingLog.Invoke("leave them.");
        yield return new WaitForSeconds(5);
        AddSpace();
        combatLog.incomingLog.Invoke("* During the enemy's turn,");
        combatLog.incomingLog.Invoke("use WASD to move around.");
        yield return new WaitForSeconds(4);
        AddSpace();
        combatLog.incomingLog.Invoke("* You can hold SHIFT to");
        combatLog.incomingLog.Invoke("slow down your movement.");
        yield return new WaitForSeconds(4);
        AddSpace();
        combatLog.incomingLog.Invoke("* Dodge white bullets and");
        combatLog.incomingLog.Invoke("parry blue bullets with F");
        combatLog.incomingLog.Invoke("to gain mana, as shown by the");
        combatLog.incomingLog.Invoke("bar by your hearts.");
        yield return new WaitForSeconds(7);
        AddSpace();
        combatLog.incomingLog.Invoke("* Defeat the scarecrow to");
        combatLog.incomingLog.Invoke("move on. Good luck!");
        yield return new WaitForSeconds(3);
        AddSpace();
        readyToStart = true;
    }

    void AddSpace(){
        combatLog.incomingLog.Invoke("");
    }
}
