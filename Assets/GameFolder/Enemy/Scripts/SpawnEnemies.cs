using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject g;
    private float timeCount;
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private float spawnTime;
    
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= spawnTime)
        {
            SpawnEnemy();  
        }
    }

    void SpawnEnemy()
    {
        g = enemiesList[Random.Range(0, enemiesList.Count)];

        if (g.activeSelf)
        {
            return;  
        }
        else
        {
            timeCount = 0f;
            g.transform.position = new Vector2(transform.position.x,Random.Range(transform.position.y,7f));
            g.SetActive(true);
        }
    }
}
