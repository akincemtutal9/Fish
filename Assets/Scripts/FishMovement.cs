using UnityEngine;
using DG.Tweening;
public class FishMovement : MonoBehaviour
{
    //Fish Walk Area    
    [SerializeField] private GameObject fishWalkArea;
    //Character Wandering around boundries
    private float horizontalBoundries;
    private float verticalBoundries;
    private float xPosition;
    private float zPosition;
    // To choose which fish will wander around
    [SerializeField] private GameObject fishGameObject;
    
    // For Wander around & running away from player
    private Vector3 targetPosition;
    private float distanceBetweenFishAndTargetPosition;
    private Vector3 fishMoveDirection;
    
    // Fish run away radius
    //[SerializeField] private float runAwayRadius;
    
    
    // fish variable bi tane sart
    private Fish fish;
    
    // Our player 
    [SerializeField] private GameObject playerGameObject;
   
    
    private void Start()
    {
        fish = GetComponent<Fish>();
        targetPosition = ChangeTargetPosition();
        

        horizontalBoundries = fishWalkArea.transform.localScale.x;
        verticalBoundries = fishWalkArea.transform.localScale.z;
        xPosition = fishWalkArea.transform.position.x;
        zPosition = fishWalkArea.transform.position.z;

    }
    private void Update(){
        WanderAround();
    }
   

    // We give fish a random position to wander around
    private Vector3 ChangeTargetPosition() => new(Random.Range(-horizontalBoundries/2 + xPosition, horizontalBoundries/2 + xPosition), 1 / 2f,
        Random.Range(-verticalBoundries/2 + zPosition, verticalBoundries/2 + zPosition));

    // Wander around
    public void WanderAround()
    {
        distanceBetweenFishAndTargetPosition = Vector3.Distance(targetPosition, transform.position);
            fishMoveDirection = (targetPosition - transform.position);
            fishMoveDirection.y = 0;
            fishMoveDirection.Normalize();
            if (distanceBetweenFishAndTargetPosition <= 0.1f)
            {
                targetPosition = ChangeTargetPosition();
            }
            transform.Translate(fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime);
    }
}