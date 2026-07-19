using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schytheBP1 : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, -100f));
        StartCoroutine(turnLeft()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator turnLeft()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-100f, 100f));
        StartCoroutine(goBackUp());
    }


    IEnumerator goBackUp(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(100f,100f));
    }

    public void becomeParryable(){
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
