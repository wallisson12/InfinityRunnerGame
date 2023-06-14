using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float distance;
    private string unit;
    private float distanceToShow;

    void Awake()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        //Update ShooterBar
        UIManager.inst.ManagerShooterBar(player);


        if (player.health <= 0)
        {
            UIManager.inst.GameOver();
        }


        distance = player.transform.position.x - startPosition.position.x;

        if (distance <= 1000)
        {
            unit = "M";
            distanceToShow = distance;
        }
        else
        {
            unit = "KM";
            distanceToShow = distance;
        }

        WhatDistance(distanceToShow,unit);
    }


    /// <summary>
    /// Calculates distance in meters or kilometers
    /// </summary>
    void WhatDistance(float d, string s)
    {
        int kilometers = (int)(d / 1000f);
        int meters = (int)(d % 1000f);

        UIManager.inst.distanceTxt.text = kilometers.ToString() + " KM " + meters.ToString() + " M";
        UIManager.inst.distanceHud.text = kilometers.ToString() + " KM " + meters.ToString() + " M";
    }
}
