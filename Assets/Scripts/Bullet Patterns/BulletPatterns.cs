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
            GameObject bulletlol = Instantiate(basicBullet, transform);
            bulletlol.transform.position = new Vector3(randomX,5f,0f);;

            ScarecrowBullet bullet = basicBullet.GetComponent<ScarecrowBullet>();

            bullet.parryable = false;

            bullet.velocityDirection = Vector3.down;
            bullet.speed = Random.Range(3f,5f);

            bulletlol.tag = "Bullet";
            if (i == 1 || i == 4 || i == 9)
            {
                bulletlol.tag = "ParryableBullet";
            }

            yield return new WaitForSeconds(tickTock);
        }
    }


    public IEnumerator WallShoot(float tickTock)
    {
        for(int i = 0; i < 20; i++)
        {
            float randomY = Random.Range(-4f,3f);
            GameObject bulletlol = Instantiate(basicBullet, transform);
            ScarecrowBullet bullet = basicBullet.GetComponent<ScarecrowBullet>();

            bullet.parryable = false;
            
            bulletlol.tag = "Bullet";
            if (i == 3 || i == 7 || i == 11 || i ==19)
            {
                bulletlol.tag = "ParryableBullet";
            }

            bullet.velocityDirection = Vector3.right;
            bullet.speed = Random.Range(3f,5f);
            bulletlol.transform.position = new Vector3(-7f,randomY,0f);
            yield return new WaitForSeconds(tickTock);
        }
    }

}
