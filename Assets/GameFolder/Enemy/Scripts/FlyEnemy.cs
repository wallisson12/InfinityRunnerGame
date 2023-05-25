using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField]
    private float speed;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8f);
    }

    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dano");    
        }    
    }
}