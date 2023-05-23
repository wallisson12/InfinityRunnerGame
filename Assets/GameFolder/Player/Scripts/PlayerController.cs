using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed,jumpForce;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
        }
    }
}
