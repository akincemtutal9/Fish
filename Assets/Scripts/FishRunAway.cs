using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRunAway : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject chaser = null;
    [SerializeField] private float displacementDist;
    private Vector3 chaserPosition;
    private Vector3 fishPosition;
    private float distanceBetweenFishAndChaserPosition;
    private Vector3 fishMoveDirection;
    
    private Fish fish;
    void Start()
    {
         fish = GetComponent<Fish>();
         chaser = GameObject.Find("Player");
         //chaserPosition = chaser.position;
    }

    // Update is called once per frame
    void Update()
    {
        //RunAway();
        chaserPosition = chaser.transform.localPosition;
        fishPosition = transform.position;
        distanceBetweenFishAndChaserPosition = Vector3.Distance(chaserPosition, fishPosition);
        fishMoveDirection = (chaserPosition - fishPosition).normalized;
        fishMoveDirection.y = 0;
        //fishMoveDirection = Quaternion.AngleAxis(Random.Range(0, 179), Vector3.up) * fishMoveDirection;
        //MoveToPosition(transform.position -(fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime));
        transform.Translate(-(fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime));
    }

    public void RunAway()
    {
        distanceBetweenFishAndChaserPosition = Vector3.Distance(chaserPosition, transform.position);
        fishMoveDirection = (chaserPosition - transform.position).normalized;

        if (distanceBetweenFishAndChaserPosition >= 0.0001f)
        {
            //transform.Translate(-fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime);
        }
        transform.Translate(-fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime);
    }

    //private Vector3 ChangeChaserPosition() => chaser.position;
   
}
