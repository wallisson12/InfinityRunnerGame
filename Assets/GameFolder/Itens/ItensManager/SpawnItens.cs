using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoint = new List<GameObject>();
    [SerializeField] private int[] posibility;
    [SerializeField] private GameObject item;
    [SerializeField] private int aux;


    void Start()
    {  
       aux = posibility[Random.Range(0, posibility.Length)];     
    }
    void Update()
    {
        if (aux == 1)
        {
            aux = 0;
            GameObject p = spawnPoint[Random.Range(0, spawnPoint.Count)];
            item.transform.parent = p.transform;
            item.transform.position = p.transform.position; 
            item.SetActive(true);
        }
    }
}
