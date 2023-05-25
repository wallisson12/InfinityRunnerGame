using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float xAxis, yAxis;
    [SerializeField] private Animator anim;
    private int bomb;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bomb = Animator.StringToHash("Bomb");
        rb.AddForce(new Vector2(xAxis,yAxis),ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Pooling to the bomb
            Debug.Log("Dano Player");
            anim.Play(bomb);
            Destroy(gameObject, 1f);
            


        }else if (other.gameObject.layer == 6)
        {
            Debug.Log("Chao");
            anim.Play(bomb);
            Destroy(gameObject, 1f);
        }
    }
}
