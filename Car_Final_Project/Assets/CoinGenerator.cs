using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    private float myTime;
    private float spawnTime;

    public float minTime = 3;
    public float maxTime = 6;

    private GameObject[] spawners;

    void resetTimers()
    {
        myTime = 0;
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Coin");

        resetTimers();
    }

    void SpawnObject()
    {
        int randomIdx = Random.Range(0, spawners.Length);
        Debug.Log("randomIdx " + randomIdx);
        Debug.Log("size " + spawners.Length);
        spawners[randomIdx].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        if(myTime >= spawnTime){
             SpawnObject();
             resetTimers();
         }
    }
}
