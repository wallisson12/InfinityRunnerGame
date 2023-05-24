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

    [SerializeField]
    private Animator anim;

    [Header("Animations Hash")]
    public int jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = Animator.StringToHash("Jumping");
    }

    void FixedUpdate()
    {
        //Move player
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    void Update()
    {
        Jump();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool(jump,false);
        }
    }
}
