using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float lenght;
    [SerializeField] private float startPosition;

    public Transform cam;

    public float paralaxSpeed;
    
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    
    void LateUpdate()
    {
        //Move
        float reposition = cam.position.x * (1f - paralaxSpeed);
        float distance = cam.position.x * paralaxSpeed;
        transform.position = new Vector3(startPosition + distance,transform.position.y,transform.position.z);


        //Pooling
        if (reposition > startPosition + lenght)
        {
            startPosition += lenght;
        }
    }
}
