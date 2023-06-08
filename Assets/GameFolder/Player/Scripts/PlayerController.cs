using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody2D rb;
    [SerializeField] private float speed,jumpForce;
    public bool isJumping;
    [SerializeField] private GameObject jetpack;

    //Player Health
    public int health { get; private set; }
    [SerializeField] private GameObject[] hearts;

    [SerializeField]
    private Animator anim;
    [Header("Animations Hash")]
    public int jump,die;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform pointGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = Animator.StringToHash("Jumping");
        die = Animator.StringToHash("Die");
        health = 3;
    }

    void FixedUpdate()
    {
        //Move player
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    void Update()
    {
        Alive();
        HearthLogic();
    }

    /// <summary>
    /// Player shoot
    /// </summary>
    public void Shoot()
    {
        Instantiate(bulletPrefab, pointGun.position, Quaternion.identity);
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
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
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
