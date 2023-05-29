using UnityEngine;

public class BombEnemy : Enemy
{
    private float throwCount; 
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float throwTime;

    void Start()
    {
        health = 2;
    }
    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            Instantiate(bombPrefab, firePoint.position, Quaternion.identity);
            throwCount = 0f;
        }
    }

}
