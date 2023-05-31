using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            if (gameObject.CompareTag("EnemyFly"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Damage Bullet
        if (other.CompareTag("Bullet"))
        {
            ApplyDamage(other.GetComponent<Bullet>().damage);
        }
        //Damage Player
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OnHit(damage);
        }
        
    }
}
