using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Lean.Pool;

public class StackTrigger : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float timePassingUntilWeCatchAFish;
    private string fishObjectsTag = "Pick";
    
    [SerializeField] private Text fishCountText; // fishCount
    [SerializeField] private Text bagGold; // gold in bag 

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
                
                StackManager.instance.PickUp(other.gameObject);
                fishList.Add(other.gameObject);
                timer = 0f;
                moneyInTheBag += fish.GetFishPrice();
                fishCountText.text = "Fish Count: " + fishList.Count;
                bagGold.text = "Bag Gold: " + moneyInTheBag;
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
