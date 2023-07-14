using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public PlayerObject playerSettings;
    public TypeShake typeShakeDamage; 
    public TypeShake typeShakeShoot;
    private Rigidbody2D rb;
    public bool isJumping,isDead = false;
    [SerializeField] private GameObject jetpack;

    //Player Health
    public int health { get; private set; }
    [SerializeField] private GameObject[] hearts;

    [SerializeField]
    private Animator anim,animJ;
    [Header("Animations Hash")]
    private int jump,die,jetP;

    [Header("Point Bullet")]
    [SerializeField] private Transform pointGun;
    [SerializeField] private float speedTimeBullet;
    public float timeBullet = 0f;

    [Header("Effects")]
    [SerializeField] private AudioClip shootEfx, jumpEfx;
    [SerializeField] private float volume,pitchS,pitchJ;


    void Awake()
    {
        playerSettings.speed = 10f;    
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = Animator.StringToHash("Jumping");
        die = Animator.StringToHash("Die");
        jetP = Animator.StringToHash("JetpackAnim");

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
            SoundManager.inst.PlayAudio(shootEfx,volume, pitchS);
            timeBullet = 0f;
            GameObject bullet = ObjectPooling.inst.GetPooledObject();
            bullet.transform.position = pointGun.position;
            bullet.SetActive(true);
            ShakeCam.Instance.TriggerShake(typeShakeShoot);
        }
    }

    /// <summary>
    /// Player jump
    /// </summary>
    public void Jump()
    {
        if (!isJumping)
        {
            SoundManager.inst.PlayAudio(jumpEfx, volume,pitchJ);
            anim.SetBool(jump, true);
            animJ.Play(jetP);
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
            jetpack.SetActive(false);

        }
    }
    
    /// <summary>
    /// Player takes damage
    /// </summary>
    public void OnHit(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            ShakeCam.Instance.TriggerShake(typeShakeDamage);
        }
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
        }
    }
}
