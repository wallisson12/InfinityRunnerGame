using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public PlayerObject playerSettings;
    private Rigidbody2D rb;
    public bool isJumping,isDead;
    [SerializeField] private GameObject jetpack;

    //Player Health
    public int health { get; private set; }
    [SerializeField] private GameObject[] hearts;

    [SerializeField]
    private Animator anim;
    [Header("Animations Hash")]
    private int jump,die;

    [Header("Point Bullet")]
    [SerializeField] private Transform pointGun;
    [SerializeField] private float speedTimeBullet;
    public float timeBullet = 0f;


    void Awake()
    {
        playerSettings.speed = 15f;    
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = Animator.StringToHash("Jumping");
        die = Animator.StringToHash("Die");

        //Add Attributes
        health = playerSettings.health;
        speedTimeBullet = 1.5f;
    }

    void FixedUpdate()
    {
        //Move player
        rb.velocity = new Vector2(playerSettings.speed,rb.velocity.y);
    }

    void Update()
    {
        Alive();
        HearthLogic();

        timeBullet += Time.deltaTime * speedTimeBullet;

        if (timeBullet >= 1f)
        {
            timeBullet = 1f;
        }
    }

    /// <summary>
    /// Player shoot
    /// </summary>
    public void Shoot()
    {
        if (timeBullet >= 1)
        {
            timeBullet = 0f;
            GameObject bullet = ObjectPooling.inst.GetPooledObject();
            bullet.transform.position = pointGun.position;
            bullet.SetActive(true);
        }
    }

    /// <summary>
    /// Player jump
    /// </summary>
    public void Jump()
    {
        if (!isJumping)
        {
            anim.SetBool(jump, true);
            jetpack.SetActive(true);
            isJumping = true;
            rb.velocity = new Vector2(transform.position.x, 0f);
            rb.AddForce(new Vector2(rb.velocity.x,playerSettings.jumpForce),ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Heart hud
    /// </summary>
    void HearthLogic()
    {
        for (int i =0;i<hearts.Length;i++)
        {
            if (i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    void Alive()
    {
        if (health <= 0)
        {
            anim.SetTrigger(die);
            enabled = false;
            isDead = true;
        }
    }
    
    /// <summary>
    /// Player takes damage
    /// </summary>
    public void OnHit(int damage)
    {
        health -= damage;
    }

    /// <summary>
    /// Player heals 
    /// </summary>
    public void OnHeal(int heal)
    {
        if (health < 3)
        {
            health += heal;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool(jump,false);
            jetpack.SetActive(false);
        }
    }
}
