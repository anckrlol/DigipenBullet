using UnityEngine;
using System.Collections;

public class BulletPatterns : MonoBehaviour
{
    [SerializeField] GameObject basicBullet;

    public IEnumerator BasicWave(float tickTock)
    {
        for(int i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-5.4f,-0.2f);
            Vector3 randomPos = new Vector3(randomX,5f,0f);
            GameObject bulletlol = GameObject.Instantiate(basicBullet);
            bulletlol.transform.position = randomPos;

            Despawn dScript = basicBullet.GetComponent<Despawn>();

            dScript.velocityDirection = new Vector3(0f,-14f,0f);
            dScript.speed = 10f;


            yield return new WaitForSeconds(tickTock);
        }
    }

}
