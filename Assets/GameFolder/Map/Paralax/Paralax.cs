using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float lenght;
    [SerializeField] private Vector2 startPosition;

    public Transform cam;

    public float paralaxSpeed;
    
    void Start()
    {
        startPosition = transform.position;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void LateUpdate()
    {
        //Move
        float reposition = cam.position.x * (1f - paralaxSpeed);
        Vector2 distance = cam.position * paralaxSpeed;
        transform.position = new Vector3(startPosition.x + distance.x,startPosition.y + distance.y,transform.position.z);


        //Pooling
        if (reposition > startPosition.x + lenght)
        {
            startPosition.x += lenght;
        }
    }
}
