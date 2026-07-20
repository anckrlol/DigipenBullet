using UnityEngine;

public class ScarecrowBullet : MonoBehaviour
{
    public Vector3 velocityDirection = Vector3.zero;
    public float speed = 1f;
    public bool parryable = false;

    void Start(){
        Destroy(gameObject, 3);
    }

    void FixedUpdate()
    {
        transform.position += velocityDirection * speed * Time.deltaTime;
        if (gameObject.tag == "ParryableBullet")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            parryable = true;
        }
        else
        {
            parryable = false;
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.ToString().Contains("Player"))
        {
            Destroy(gameObject);
        }
    }

}
