using UnityEngine;

public class Despawn : MonoBehaviour
{
    public Vector3 velocityDirection = new Vector3(0f,0f,0f);
    public float speed = 1f;
    public bool parryable = false;
    [SerializeField] GameObject plr;

    private Rigidbody2D mainObj;

    void FixedUpdate()
    {
        mainObj = GetComponent<Rigidbody2D>();
        mainObj.linearVelocity = velocityDirection * speed * Time.deltaTime;
        if (gameObject.tag == "ParryableBullet")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,255,120);
            parryable = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(100,0,0);
            parryable = false;
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.ToString().Contains("Despawner") == true || collision.ToString().Contains("Player") == true)
        {
            Destroy(gameObject);
        }
    }

}
