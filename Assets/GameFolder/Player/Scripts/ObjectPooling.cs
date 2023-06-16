using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling inst;

    [SerializeField] private GameObject obj;
    [SerializeField] private int lastIndex = 0;
    [SerializeField] private List<GameObject> instances = new List<GameObject>();
    [SerializeField] private int amount = 10;


    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
    }
    void Start()
    {
        for (int i = 0;i < amount;i++)
        {
            GameObject g = Instantiate(obj,gameObject.transform);
            g.SetActive(false);
            instances.Add(g);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject g = instances[lastIndex++];

        if (lastIndex >= instances.Count)
        {
            lastIndex = 0;
        }

        return g;
    }
}
