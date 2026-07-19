using System.Collections;
using UnityEngine;

public class BP1entireScythe : MonoBehaviour
{
    void Start()
    {
        int random = Random.Range(1,6);
        transform.GetChild(random-1).gameObject.GetComponent<schytheBP1>().becomeParryable();
        random = Random.Range(6,11);
        transform.GetChild(random-1).gameObject.GetComponent<schytheBP1>().becomeParryable();

        Destroy(gameObject, 7f);
    }
    
}
