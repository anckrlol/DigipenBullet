using UnityEngine;

public class StartGame : MonoBehaviour
{
    SceneLoader sceneLoader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        sceneLoader = GameObject.FindWithTag("GameController").GetComponent<SceneLoader>();
    }

    public void GameStart(){
        sceneLoader.startGame.Invoke();
    }
}
