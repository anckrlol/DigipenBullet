using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour
{
    
    public int playerHealth = 5;
    [SerializeField] float parryCooldown = 1;
    [SerializeField] string upKey = "w";
    [SerializeField] string downKey = "s";
    [SerializeField] string leftKey = "a";
    [SerializeField] string rightKey = "d";
    [SerializeField] string parryKey = "f";
    [SerializeField] float invinsibilityTime = 1f;

    bool invinsibile = false;
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

        if (Input.GetKey(parryKey));
        {
            //for now this does nothing but this is where the parry functionality will go
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

    IEnumerator waitIframes(float tickTock)
    {
        yield return new WaitForSeconds(tickTock);
        invinsibile = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (invinsibile == false)
        {
            invinsibile = true;
            playerHealth--;
            StartCoroutine(waitIframes(invinsibilityTime));

        }
    }


}
