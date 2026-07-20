using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Action playerDied = null;
    public Action<string> startGame = null;
    public bool firstTime = true;
    public string lastDied;

    void Awake()
    {
        SceneLoader[] objs = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None);
        if (objs.Length > 1){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDied += PlayerDied;
        startGame += SceneStart;
    }

    void SceneStart(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    void PlayerDied(){
        lastDied = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("EndScreen");
        firstTime = false;
    }
}
