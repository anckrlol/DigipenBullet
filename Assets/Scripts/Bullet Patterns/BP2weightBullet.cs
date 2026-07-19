using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP2weightBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int random = Random.Range(1,6);
        if(random == 3)
            becomeParryable();
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, 0f);
        
    }


    public void kickStartTheStart(float time){
        StartCoroutine(start(time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator start(float time){
        yield return new WaitForSeconds(time);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, -5f);
        StartCoroutine(stop());

    }

    IEnumerator stop(){
        yield return new WaitForSeconds(1f);
        becomeNotParryable();
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, 0f);
        StartCoroutine(fallAgain());
    }





    IEnumerator fallAgain(){
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, -10f);
        Destroy(gameObject, 7f);
    }

    public void becomeParryable(){
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void becomeNotParryable(){
        GetComponent<Renderer>().material.color = Color.white;
    }
}
