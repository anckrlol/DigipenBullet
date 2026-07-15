using UnityEngine;

public class Despawn : MonoBehaviour
{
    public Vector3 velocityDirection = new Vector3(0f,0f,0f);
    public float speed = 1f;

    private Rigidbody2D mainObj;

    void FixedUpdate()
    {
        mainObj = GetComponent<Rigidbody2D>();
        mainObj.linearVelocity = velocityDirection * speed * Time.deltaTime;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.ToString().Contains("Despawner") == true )
        {
            Destroy(gameObject);
        }
    }

}
