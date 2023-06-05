using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    private Rigidbody2D rig;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    
    //Animation Hash
    private int idle,die;
    
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        idle = Animator.StringToHash(gameObject.name + "Idle");
        die = Animator.StringToHash("EnemyFlyDie");
        health = 1;
    }

    void OnEnable()
    {
        GetComponent<CircleCollider2D>().enabled = true;

        //Life Time
        StartCoroutine(DisableEnemy());

        //Animation Start
        anim.Play(idle);
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

    IEnumerator EnemyFlyDie()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    public override void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            anim.Play(die);
            StartCoroutine(EnemyFlyDie());
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Animation Die
        anim.Play(die);

        //Damage Bullet
        if (other.CompareTag("Bullet"))
        {
            ApplyDamage(other.GetComponent<Bullet>().damage);
        }
        //Damage Player
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OnHit(damage);
            ApplyDamage(health);
        }
    }

}
