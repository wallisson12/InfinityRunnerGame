using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> platforms = new List<GameObject>();
    private float offset = 0f;
    private Transform player;
    [SerializeField] private List<Transform> currentPlatforms = new List<Transform>();

    public Transform currentPlatformPoint;
    public int platformIndex,lastIndex = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        int place = 1;

        for(int i=0;i<platforms.Count;i++)
        {
            GameObject p = Instantiate(platforms[Random.Range(0,platforms.Count)], new Vector2(place * 22f,0f), transform.rotation);
            p.transform.parent = transform;

            if (p.CompareTag("p2"))
            {
                p.transform.position = new Vector2(p.transform.position.x,-0.7f);

            }else if (p.CompareTag("p4"))
            {
                p.transform.position = new Vector2(p.transform.position.x,1.46f);
            }

            place++;

            //Platforms in scene
            currentPlatforms.Add(p.transform);

            //Free position of the next platform
            offset += 22f;
        }

        //what platform I am
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    
    void Update()
    {
        Move();
    }

    /// <summary>
    /// Check the distance between the player and the platform
    /// </summary>
    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 10f)
        {
            //Pooling platform
            Pooling(currentPlatforms[platformIndex].gameObject,platformIndex);

            //Next platform
            platformIndex++;

            if (platformIndex >= currentPlatforms.Count)
            {
                platformIndex = 0;
            }

            //New platform point
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;

        }
    }

    /// <summary>
    /// Pooling the plaforms
    /// </summary>
    void Pooling(GameObject p, int index)
    {
        //Destroy the object and add other platform at list
        Destroy(p);
        GameObject p2 = Instantiate(platforms[Random.Range(0,platforms.Count)]);
        p2.transform.parent = transform;
        currentPlatforms[index] = p2.transform; 
      
        //Next position
        offset += 22f;

        if (p2.CompareTag("p2"))
        {
            p2.transform.position = new Vector2(offset, -0.7f);
        }
        else if(p2.CompareTag("p4"))
        {
            p2.transform.position = new Vector2(offset,1.46f);
        }
        else
        {
            p2.transform.position = new Vector2(offset, 0f);
        }

        if (p2.GetComponent<Platform>().spawnObj != null)
        {
            p2.GetComponent<Platform>().spawnObj.Spawn();
        }
    }
    
}
