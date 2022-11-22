using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Lean.Pool;
using UnityEditor.Experimental.GraphView;

public class StackTrigger : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float timePassingUntilWeCatchAFish;
    private string fishObjectsTag = "Pick";
    
    [SerializeField] private Text bagGoldText; // gold in bag 
    [SerializeField] private Text fishCountDividedCapacityText;// fish count according to capacity of the bag
    [SerializeField] private Text capacityError; // if we try to consume more fish than capacity it will show user an error message

    [SerializeField] private float bagCapacity = 0; 
    private float moneyInTheBag = 0;
    
    
    [SerializeField] private float timePassingUntilWeDestroyAFish;
    [SerializeField] private List<GameObject> fishList;

    private Fish fish;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(fishObjectsTag))
        {
            //Debug.Log("Enter");
            fish = other.GetComponent<Fish>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.CompareTag(fishObjectsTag))
        {
            timer += Time.deltaTime;
            if (timer >= timePassingUntilWeCatchAFish)
            {
                if (fishList.Count >= bagCapacity)
                {
                    capacityError.text = "You don't have enough capacity";
                    return;
                }
                
                StackManager.instance.PickUp(other.gameObject);
                fishList.Add(other.gameObject);
                timer = 0f;
                moneyInTheBag += fish.GetFishPrice();
                bagGoldText.text = "Bag Gold: " + moneyInTheBag;
                fishCountDividedCapacityText.text = "FishCount / Capacity: \n" + fishList.Count + " / " + bagCapacity;
                LeanPool.Despawn(other.gameObject, timePassingUntilWeDestroyAFish);
                
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(fishObjectsTag))
        {
            //Debug.Log("Exited");
            timer = 0;
        }
    }
}
