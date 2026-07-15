using UnityEngine;
using System.Collections;

public class TestEnemyScript : MonoBehaviour
{

     [SerializeField] private BulletPatterns johnBullets;

    void Start()
    {

        StartCoroutine(Attack());

        
    }

    public IEnumerator Attack()
    {
        for(int i = 0; i < 20; i++)
        {
            StartCoroutine(johnBullets.WallShoot(0.5f));
            yield return new WaitForSeconds(10);
            StartCoroutine(johnBullets.WallShoot(0.5f));
            yield return new WaitForSeconds(10);
        }
    }
}
