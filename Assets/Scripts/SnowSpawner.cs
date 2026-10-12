using System.Collections;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    public GameObject snowflakePrefab;  
    public Vector3 randomSnowflakePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(snowFall());
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    IEnumerator snowFall()
    {
        while(true){
            randomSnowflakePos = new Vector3(Random.Range(-20f, 20f), 6f, 0);
            Instantiate(snowflakePrefab, randomSnowflakePos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
