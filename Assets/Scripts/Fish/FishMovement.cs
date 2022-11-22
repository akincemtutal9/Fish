using UnityEngine;

public class FishMovement : MonoBehaviour
{
    //Fish Walk Area    
    [SerializeField] private GameObject fishWalkArea;
    //Character Wandering around boundries
    private float horizontalBoundries;
    private float verticalBoundries;
    private float xPosition;
    private float zPosition;
    
    // For Wander around 
    private Vector3 targetPosition;
    private float distanceBetweenFishAndTargetPosition;
    private Vector3 fishMoveDirection;

    private Fish fish;

    private void Start()
    {
        fish = GetComponent<Fish>();
        targetPosition = ChangeTargetPosition();


        var localScale = fishWalkArea.transform.localScale;
        horizontalBoundries = localScale.x;
        verticalBoundries = localScale.z;
        var position = fishWalkArea.transform.position;
        xPosition = position.x;
        zPosition = position.z;

    }
    private void Update(){
        WanderAround();
    }
   

    // We give fish a random position to wander around
    private Vector3 ChangeTargetPosition() => new(Random.Range(-horizontalBoundries/2 + xPosition, horizontalBoundries/2 + xPosition), 1 / 2f,
        Random.Range(-verticalBoundries/2 + zPosition, verticalBoundries/2 + zPosition));

    // Wander around
    private void WanderAround()
    {
        var position = transform.position;
        distanceBetweenFishAndTargetPosition = Vector3.Distance(targetPosition, position);
            fishMoveDirection = (targetPosition - position);
            fishMoveDirection.y = 0;
            fishMoveDirection.Normalize();
            if (distanceBetweenFishAndTargetPosition <= 0.1f)
            {
                targetPosition = ChangeTargetPosition();
            }
            transform.Translate(fishMoveDirection * (fish.GetFishSpeed() * Time.deltaTime));
    }
}