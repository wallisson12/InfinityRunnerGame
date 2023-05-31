using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private int efxBullet;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        efxBullet = Animator.StringToHash("BulletExplosion");
        Destroy(gameObject, 5f);
    }


    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Explosion animation
        anim.Play(efxBullet);
        Destroy(gameObject, 0.5f);
        
    }

    
    
}
