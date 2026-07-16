using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Action playerDied = null;
    private static SceneLoader sceneLoader;

    void Awake()
    {
        if (sceneLoader = null){
            sceneLoader = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDied += PlayerDied;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerDied(){
        SceneManager.LoadScene("EndScreen");
    }
}
