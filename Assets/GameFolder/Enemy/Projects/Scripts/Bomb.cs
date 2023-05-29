using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int bombEx;
    [SerializeField] private float xAxis, yAxis;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    
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
            anim.Play(bombEx);
            DestroyBomb(0.5f);

        }
        else if (other.gameObject.layer == 6)
        {
            anim.Play(bombEx);
            DestroyBomb(0.5f);
        }
    }
}
