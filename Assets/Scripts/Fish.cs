using System;
using UnityEngine;

public class Fish : MonoBehaviour
{
    //Scriptable Objects
    [SerializeField] private FishType fishType;
    private float fishPrice;
    private float fishLevel;
    private bool doesFishRunAway;

    //References
    private FishMovement fishMovement;
    private void Awake()
    {
        fishMovement = GetComponent<FishMovement>();
    }

    private void Start()
    {
        GetComponent<Renderer>().material.color = fishType.fishColor;
        transform.localScale = fishType.fishScale;
        fishLevel = fishType.fishLevel;
        fishPrice = fishType.fishPrice;
        doesFishRunAway = fishType.doesFishRunAway;
    }

    private void Update()
    {
        //fishMovement.WanderAround();
    }

    public int GetFishSpeed()
    {
        return fishType.fishMoveSpeed;
    }

    public bool GetDoesFishRunAway()
    {
        return fishType.doesFishRunAway;
    }
}

