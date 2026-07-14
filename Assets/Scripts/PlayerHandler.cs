using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    
    public int playerHealth = 5;
    [SerializeField] float parryCooldown = 1;
    [SerializeField] string upKey = "w";
    [SerializeField] string downKey = "s";
    [SerializeField] string leftKey = "a";
    [SerializeField] string rightKey = "d";

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(upKey))
        {
            transform.position += new Vector3(0f,5f,0f) * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            transform.position += new Vector3(0f,-5f,0f) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0f,0f,0f);
        }



        if (Input.GetKey(rightKey))
        {
            transform.position += new Vector3(5f,0f,0f) * Time.deltaTime;
        }
        else if (Input.GetKey(leftKey))
        {
            transform.position += new Vector3(-5f,0f,0f) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0f,0f,0f);
        }
    }


}
