using System;
using UnityEngine;

public class Fish : MonoBehaviour
{
    //Scriptable Objects
    [SerializeField] private FishType fishType;
    private float fishPrice;
    private float fishLevel;
    private bool doesFishRunAway;
    private int fishMoveSpeed;

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
        fishMoveSpeed = fishType.fishMoveSpeed;
    }

    private void Update()
    {
        //fishMovement.WanderAround();
    }

    public int GetFishSpeed()
    {
        return fishMoveSpeed;
    }

    public bool GetDoesFishRunAway()
    {
        return doesFishRunAway;
    }

    public int GetFishPrice()
    {
        return (int)fishPrice;
    }
}

