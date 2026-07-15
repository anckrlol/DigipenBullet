using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{

     [SerializeField] private BulletPatterns johnBullets;

    void Start()
    {
        StartCoroutine(johnBullets.BasicWave(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
