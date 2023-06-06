using UnityEngine;

public class HeartC : MonoBehaviour
{
    [SerializeField] private int heal;

   private void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OnHeal(heal);
        }
   }
}
