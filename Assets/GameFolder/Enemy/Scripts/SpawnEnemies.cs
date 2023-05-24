using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemiesList = new List<GameObject>();
    
    void Start()
    {
        SpawnEnemy();
    }

    
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesList[Random.Range(0,enemiesList.Count)], transform.position, transform.rotation);
    }
}
