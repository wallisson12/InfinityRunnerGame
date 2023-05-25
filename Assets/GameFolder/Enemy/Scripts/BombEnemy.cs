using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float throwTime;
    private float throwCount; 
    
    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            //Add rotation to the bomb
            Instantiate(bombPrefab,firePoint.position,Quaternion.identity);
            throwCount = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dano");
        }
    }
}
