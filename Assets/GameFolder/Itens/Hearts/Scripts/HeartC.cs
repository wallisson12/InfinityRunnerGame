using UnityEngine;

public class HeartC : MonoBehaviour
{
    [SerializeField] protected int heal;

   protected virtual void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().health < 3 && !other.GetComponent<PlayerController>().isDead)
            {
                other.GetComponent<PlayerController>().OnHeal(heal);
                gameObject.SetActive(false);
            }
        }
   }
}
