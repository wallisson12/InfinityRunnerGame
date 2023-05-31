using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed,jumpForce;
    public bool isJumping;

    //Player Health
    public int health { get; private set; }


    [SerializeField]
    private Animator anim;

    [Header("Animations Hash")]
    public int jump;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform pointGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = Animator.StringToHash("Jumping");
        health = 3;
    }

    void FixedUpdate()
    {
        //Move player
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    void Update()
    {
        Jump();
        Shoot();
    }

    /// <summary>
    /// Player shoot
    /// </summary>
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(bulletPrefab, pointGun.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Player jump
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            anim.SetBool(jump, true);
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
        }
    }
    
    /// <summary>
    /// Player takes damage
    /// </summary>
    public void OnHit(int damage)
    {
        health -= damage;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool(jump,false);
        }
    }
}
