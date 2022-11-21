using UnityEngine;

public class FishRunAway : MonoBehaviour
{
   
    private GameObject chaser = null;

    private Vector3 chaserPosition;
    private Vector3 fishPosition;
    private Vector3 fishMoveDirection;
    private FishMovement fishMovement;
    
    private Fish fish;
    
    
    void Start()
    {
         fish = GetComponent<Fish>();
         fishMovement = GetComponent<FishMovement>();
         
         chaser = GameObject.Find("Player");
       
         
         
    }

    private void Update()
    {
        //fishMovement.GetComponent<FishMovement>().enabled = true;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollisionTag"))
        {
            fishMovement.GetComponent<FishMovement>().enabled = false;
            //Debug.Log("Movement gitti");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CollisionTag"))
        {
            chaserPosition = chaser.transform.localPosition;
            fishPosition = transform.position;
            fishMoveDirection = (chaserPosition - fishPosition).normalized;
            fishMoveDirection.y = 0;
            if (fish.GetDoesFishRunAway())
            {
                transform.Translate(-(fishMoveDirection * fish.GetFishSpeed() * Time.deltaTime));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollisionTag"))
        {
            fishMovement.GetComponent<FishMovement>().enabled = true;
            //Debug.Log("Movement geri geldi");
        }
    }
}
