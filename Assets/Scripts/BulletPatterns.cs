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
            bulletlol.transform.rotation = Quaternion.Euler(0f,0f,-180f);

            Despawn dScript = basicBullet.GetComponent<Despawn>();

            dScript.parryable = false;

            dScript.velocityDirection = new Vector3(0f,-14f,0f);
            dScript.speed = 10f;

            if (i == 5 || i == 10)
            {
                dScript.parryable = true;
            }
            else
            {
                dScript.parryable = false;
            }


            yield return new WaitForSeconds(tickTock);
        }
    }


// very buggy for now, dont use!
    public IEnumerator WallShoot(float tickTock)
    {
        for(int i = 0; i < 20; i++)
        {
            float randomY = Random.Range(-4f,3f);
            float randomWall = Random.Range(1f,4f);
            Vector3 randomPos = new Vector3(0f,0f,0f);
            GameObject bulletlol = GameObject.Instantiate(basicBullet);
            Despawn dScript = basicBullet.GetComponent<Despawn>();

            dScript.parryable = false;
            
            if (i == 4 || i == 8 || i == 12 || i ==20)
            {
                dScript.parryable = true;
            }
            else
            {
                dScript.parryable = false;
            }

            if (randomWall >= 2)
            {
                randomPos = new Vector3(-7f,randomY,0f);
                dScript.velocityDirection = new Vector3(10f,0f,0f);
                bulletlol.transform.rotation = Quaternion.Euler(0f,0f,-90f);
                dScript.speed = 10f;
                bulletlol.transform.position = randomPos;
            }
            else
            {
                randomPos = new Vector3(0.5f,randomY,0f);
                dScript.velocityDirection = new Vector3(10f,0f,0f);
                bulletlol.transform.rotation = Quaternion.Euler(0f,0f,90f);
                dScript.speed = 10f;
                bulletlol.transform.position = randomPos;
            }
            


            yield return new WaitForSeconds(tickTock);
        }
    }

}
