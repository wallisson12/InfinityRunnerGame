using UnityEngine;

public class BombEnemy : Enemy
{
    private float throwCount; 
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float throwTime;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip shootE;

    void Start()
    {
        health = 2;
    }
    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            audioS.PlayOneShot(shootE);
            Instantiate(bombPrefab, firePoint.position, Quaternion.identity);
            throwCount = 0f;
        }
    }

}
