using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Fish Type",menuName = "Fish Type")]
public class FishType : ScriptableObject
{
    public int fishMoveSpeed;
    public Color fishColor;
    public Vector3 fishScale;
    public float fishPrice;
    public float fishLevel;
    public bool doesFishRunAway;
}
