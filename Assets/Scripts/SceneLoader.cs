using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Action playerDied = null;
    public Action startGame = null;
    private static SceneLoader sceneLoader;
    private PlayBGM bgmPlayer;

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
        startGame += GameStart;
    }

    void GameStart(){
        SceneManager.LoadScene("Winson");
    }

    void PlayerDied(){
        SceneManager.LoadScene("EndScreen");
    }
}
