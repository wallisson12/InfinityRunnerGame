using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    private Rigidbody2D rig;
    [SerializeField] private float speed;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        health = 1;
    }

    void OnEnable()
    {
        StartCoroutine(DisableEnemy());  
    }

    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }


    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

}
