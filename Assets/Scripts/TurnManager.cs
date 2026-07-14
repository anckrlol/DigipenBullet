using UnityEngine;

public class TurnManager : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    bool playerTurn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
        if (playerTurn){
            enemy.SetActive(true);
            player.SetActive(false);
        } else{
            enemy.SetActive(false);
            player.SetActive(true);
        }
    }
}
