using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    
    public int playerHealth = 5;
    [SerializeField] float parryCooldown = 1;
    [SerializeField] string upKey = "w";
    [SerializeField] string downKey = "s";
    [SerializeField] string leftKey = "a";
    [SerializeField] string rightKey = "d";

    float speed = 5f;

    void Start()
    {
        transform.position = new Vector3(-3,-3,0);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2f;
        }
        else
        {
            speed = 5f;
        }

        if (Input.GetKey(upKey))
        {
            transform.position += new Vector3(0f,speed,0f) * Time.deltaTime;
        }
            else if (Input.GetKey(downKey))
        {
            transform.position += new Vector3(0f,-speed,0f) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0f,0f,0f);
        }


        if (Input.GetKey(rightKey))
        {
            transform.position += new Vector3(speed,0f,0f) * Time.deltaTime;
        }
        else if (Input.GetKey(leftKey))
        {
            transform.position += new Vector3(-speed,0f,0f) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0f,0f,0f);
        }
    }


}
