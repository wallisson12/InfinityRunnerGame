using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "typeShake",menuName ="TypeShake/Type") ]
public class TypeShake :ScriptableObject
{
    public NoiseSettings noise;
    public float duration;
    public float amplitude;
    public float frequency;
 
}
