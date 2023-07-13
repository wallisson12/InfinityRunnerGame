using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Vector2 offSet;
    [SerializeField] private float speed;

    
    void Start()
    {
        material = GetComponent<Image>().material; 
    }

    void FixedUpdate()
    {
        offSet = new Vector2(speed * Time.deltaTime,0f);
        material.mainTextureOffset += offSet; 
    }
}
