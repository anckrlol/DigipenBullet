using System;
using TMPro;
using UnityEngine;

public class CombatLog : MonoBehaviour
{
    private TMP_Text logText;
    /// <summary>
    /// Displays the given text to the log.
    /// </summary>
    public Action<string> incomingLog = null;
    private string[] currentLog = new string[7];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logText = GetComponent<TMP_Text>();
        incomingLog += UpdateLog;
    }

    public void DisplayMenu(string menuText){
        logText.text = menuText;
    }

    void UpdateLog(string newLine){
        ReplaceLines(newLine);
        DisplayLog();
    }

    /// <summary>
    /// Clears the current menu and displays the combat log.
    /// </summary>
    public void DisplayLog(){
        logText.text = ArrayToString();
    }

    string ArrayToString(){
        string fullString = "";
        foreach (string line in currentLog)
        {
            fullString += line + "\n";
        }
        return fullString;
    }

    void ReplaceLines(string lineToInsert){
        for (int i = 0; i < currentLog.Length-1; i++){
            currentLog[i] = currentLog[i+1];
        }
        currentLog[^1] = lineToInsert;
    }
}
