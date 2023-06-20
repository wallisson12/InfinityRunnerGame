using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int bombEx;
    [SerializeField] private float xAxis, yAxis;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bombEx = Animator.StringToHash("Bomb");
        rb.AddForce(new Vector2(xAxis,yAxis),ForceMode2D.Impulse);
        DestroyBomb(5f);
    }

    void DestroyBomb(float time)
    {
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Damage player
            other.GetComponent<PlayerController>().OnHit(damage);
            anim.Play(bombEx);
            DestroyBomb(0.5f);

        }
        else if (other.gameObject.layer == 6 || other.CompareTag("Bullet"))
        {
            anim.Play(bombEx);
            GetComponent<CircleCollider2D>().enabled = false;
            DestroyBomb(0.5f);
        }
    }
}
