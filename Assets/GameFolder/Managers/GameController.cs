using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float distance;
    private string unit;
    private float distanceToShow;
    private int kilometers,meters,aux;
    [SerializeField] private float valueIncrease;


    void Awake()
    {
        //Tempo para comecar o game
    }

    void Start()
    {
        aux = 500;    
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
        IncreasesSpeed();
    }


    /// <summary>
    /// Calculates distance in meters or kilometers
    /// </summary>
    void WhatDistance(float d, string s)
    {
        kilometers = (int)(d / 1000f);
        meters = (int)(d % 1000f);

        UIManager.inst.distanceTxt.text = kilometers.ToString() + " KM " + meters.ToString() + " M";
        UIManager.inst.distanceHud.text = kilometers.ToString() + " KM " + meters.ToString() + " M";
    }

    /// <summary>
    /// Increases player and bullet speed
    /// </summary>
    void IncreasesSpeed()
    {
        if (meters == aux)
        {
            aux += meters;
            player.playerSettings.speed += valueIncrease;
            GameObject.FindGameObjectWithTag("ObjPooling").GetComponent<ObjectPooling>().IncreaseBulletSpeed(valueIncrease);
        }
    }
}
