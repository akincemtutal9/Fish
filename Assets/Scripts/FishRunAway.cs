using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRunAway : MonoBehaviour
{
   
    private GameObject chaser = null;
    private GameObject escapeFish = null;
    
    private Vector3 chaserPosition;
    private Vector3 fishPosition;
    private float distanceBetweenFishAndChaserPosition;
    private Vector3 fishMoveDirection;
    [SerializeField] private float fishRunAwayRadius = 2;
    private FishMovement fishMovement;
    
    private Fish fish;
    
    
    void Start()
    {
         fish = GetComponent<Fish>();
         fishMovement = GetComponent<FishMovement>();
         
         chaser = GameObject.Find("Player");
         escapeFish = GameObject.Find("BigFish");
    }

    // Update is called once per frame
    void Update()
    {
        
        RunAway();
        
    }

    public void RunAway()
    {
        
            chaserPosition = chaser.transform.localPosition;
            fishPosition = transform.position;
            distanceBetweenFishAndChaserPosition = Vector3.Distance(chaserPosition, fishPosition);
            fishMoveDirection = (chaserPosition - fishPosition).normalized;
            fishMoveDirection.y = 0;
            if (fish.GetDoesFishRunAway() && distanceBetweenFishAndChaserPosition <= fishRunAwayRadius)
            {
                escapeFish.GetComponent<FishMovement>().enabled = false;
                transform.Translate(-(fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime));
            }
            else
            {
                escapeFish.GetComponent<FishMovement>().enabled = true;
            }
    }

    //private Vector3 ChangeChaserPosition() => chaser.position;
   
}
