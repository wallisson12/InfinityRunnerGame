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
    }

    void OnEnable()
    {
        StartCoroutine(DisableBullet(5f));
    }

    IEnumerator DisableBullet(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Explosion animation
        if (other.CompareTag("Item"))
        {
            return;
        }
        else
        {
            anim.Play(efxBullet);
            StartCoroutine(DisableBullet(1f));
        }
        
    }

    
    
}
