using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoint = new List<GameObject>();    
    [SerializeField] private GameObject item;

    [SerializeField] private float spawnTime,timeCount;

    void Start()
    {
        //Start count
        timeCount = 0f;        
    }
    void Update()
    {
        if (item.activeSelf == false)
        {
            timeCount += Time.deltaTime;
        }

        if (timeCount >= spawnTime)
        {
            timeCount = 0f;
            GameObject p = spawnPoint[Random.Range(0, spawnPoint.Count)];
            item.transform.parent = p.transform;
            item.transform.position = p.transform.position; 
            item.SetActive(true);
        }
    }
}
