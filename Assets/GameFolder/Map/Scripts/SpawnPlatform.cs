using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms = new List<GameObject>();
    private float offset;
    private Transform player;
    private List<Transform> currentPlatforms = new List<Transform>();

    public Transform currentPlatformPoint;
    public int platformIndex;

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

            if (p.CompareTag("p2"))
            {
                p.transform.position = new Vector2(p.transform.position.x,-0.7f);
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

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 10f)
        {
            //Pooling platform
            Pooling(currentPlatforms[platformIndex].gameObject);

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

    //This method do the pooling of the platforms
    void Pooling(GameObject p)
    {
        offset += 22f;

        if (p.CompareTag("p2"))
        {
            p.transform.position = new Vector2(offset, -0.7f);
        }
        else
        {
            p.transform.position = new Vector2(offset,0f);
        }

        if (p.GetComponent<Platform>().spawnObj != null)
        {
            p.GetComponent<Platform>().spawnObj.Spawn();
        }
    }
}
