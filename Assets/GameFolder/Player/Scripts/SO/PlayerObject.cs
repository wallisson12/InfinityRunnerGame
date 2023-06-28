using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerAttributes",menuName = "Player/New Player")]
public class PlayerObject : ScriptableObject
{
    public int health;
    public float speed;
    public float jumpForce;

}
