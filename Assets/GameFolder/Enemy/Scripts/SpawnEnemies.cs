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
    public GameObject g;
    
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
            g.SetActive(true);
            g.transform.position = new Vector2(transform.position.x,Random.Range(transform.position.y,8f));
        }
    }
}
