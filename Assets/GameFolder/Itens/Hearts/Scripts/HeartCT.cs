using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCT : HeartC
{
    [SerializeField] private float time;
    void Start()
    {
        heal = 1;
        StartCoroutine(DisableHearth());
    }

    IEnumerator DisableHearth()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
