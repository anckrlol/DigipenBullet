using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPController : MonoBehaviour
{

    public int pattern = 1;

    int bp2_count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject pattern1;
    [SerializeField] GameObject pattern2;
    void Start()
    {
        StartCoroutine(startPattern(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator startPattern(float time){
        yield return new WaitForSeconds(time);
        if(pattern == 1){
            //IMPORTANT: IF BULLET PATTERN ISN'T SHOWING AFTER MERGING THAN IT MIGHT BE BECAUSE OF THE POSITION
            Vector3 spawnPos = new Vector3(-2.15f, -2.3f, 0f);
            Instantiate(pattern1, spawnPos, Quaternion.identity);
            StartCoroutine(startPattern(7f));
        }
        else if(pattern == 2){
            bp2_count++;
            Vector3 spawnPos;
            if(bp2_count%2==0){
                spawnPos = new Vector3(-2.1f, 3.65f, 0f);
            }
            else{
                spawnPos = new Vector3(-0.22f, 3.65f, 0f);
            }
            GameObject weight = Instantiate(pattern2, spawnPos, Quaternion.identity);
            //float rand = Random.Range(0.5f, 1f);
            weight.GetComponent<BP2weightBullet>().kickStartTheStart(0.5f);

            StartCoroutine(startPattern(2f));
        }
    }



}
