using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    void Awake()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (player.health <= 0)
        {
            UIManager.inst.GameOver();
            //Dead animation
        }
    }
}
