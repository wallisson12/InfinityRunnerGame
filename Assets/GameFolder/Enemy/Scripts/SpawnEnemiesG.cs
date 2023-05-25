using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesG : MonoBehaviour
{

    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private GameObject enemyPrefab;
    private GameObject currentEnemy;

    void Start()
    {
        CreateEnemy();
    }

    public void Spawn()
    {
        if (currentEnemy == null)
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        int p = Random.Range(0,points.Count);
        GameObject e = Instantiate(enemyPrefab, points[p].position, Quaternion.identity);
        e.transform.parent = points[p];
        currentEnemy = e;
    }
}
