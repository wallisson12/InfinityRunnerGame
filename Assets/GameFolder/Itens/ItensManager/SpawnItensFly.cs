using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItensFly : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<float> times = new List<float>();
    [SerializeField] private GameObject item;
    [SerializeField] private float timecount,spawnTime;


    void Start()
    {
        timecount = 0f;
        spawnTime = times[Random.Range(0, times.Count)];
    }

    
    void Update()
    {
        timecount += Time.deltaTime;

        if (timecount >= spawnTime)
        {
            SpawnHearthTime();
        }
    }

    void SpawnHearthTime()
    {
        if (item.activeSelf)
        {
            return;
        }
        else
        {
            timecount = 0f;
            item.transform.position = new Vector2(transform.position.x,spawnPoints[Random.Range(0,spawnPoints.Count)].position.y);
            item.SetActive(true);
            spawnTime = times[Random.Range(0, times.Count)];
        }
    }
}
