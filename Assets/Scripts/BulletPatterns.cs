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
            GameObject bulletlol = Instantiate(basicBullet, transform);
            bulletlol.transform.position = randomPos;
            bulletlol.transform.rotation = Quaternion.Euler(0f,0f,-180f);

            Despawn dScript = basicBullet.GetComponent<Despawn>();

            dScript.parryable = false;

            dScript.velocityDirection = new Vector3(0f,-14f,0f);
            dScript.speed = 10f;

            if (i == 1 || i == 4 || i == 9)
            {
                bulletlol.tag = "ParryableBullet";
            }
            else
            {
                bulletlol.tag = "Bullet";
            }


            yield return new WaitForSeconds(tickTock);
        }
    }


    public IEnumerator WallShoot(float tickTock)
    {
        for(int i = 0; i < 20; i++)
        {
            float randomY = Random.Range(-4f,3f);
            Vector3 randomPos = new Vector3(0f,0f,0f);
            GameObject bulletlol = Instantiate(basicBullet, transform);
            Despawn dScript = basicBullet.GetComponent<Despawn>();

            dScript.parryable = false;
            
            if (i == 3 || i == 7 || i == 11 || i ==19)
            {
                bulletlol.tag = "ParryableBullet";
            }
            else
            {
                bulletlol.tag = "Bullet";
            }

                randomPos = new Vector3(-7f,randomY,0f);
                dScript.velocityDirection = new Vector3(10f,0f,0f);
                bulletlol.transform.rotation = Quaternion.Euler(0f,0f,-90f);
                dScript.speed = 10f;
                bulletlol.transform.position = randomPos;
            


            yield return new WaitForSeconds(tickTock);
        }
    }

}
