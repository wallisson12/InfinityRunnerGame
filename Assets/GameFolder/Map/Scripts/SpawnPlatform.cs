using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms = new List<GameObject>();
    [SerializeField]
    private float offset;

    void Start()
    {
        for(int i=0;i<platforms.Count;i++)
        {
            Instantiate(platforms[i], new Vector2(i * 30f, 0f), transform.rotation);
            //Free position of the next platform
            offset += 30f;
        }
    }

    
    void Update()
    {
        
    }

    //This method to do the pooling of the platforms
    void Pooling(GameObject p)
    {
        p.transform.position = new Vector2(offset,0f);
        offset += 30f;
    }
}
