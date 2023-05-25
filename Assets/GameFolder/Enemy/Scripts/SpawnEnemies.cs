using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    [SerializeField]
    private float spawnTime;
    
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTime)
        {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0,enemiesList.Count)], transform.position + new Vector3(0f,Random.Range(0f,4f),0f), transform.rotation);
    }
}
