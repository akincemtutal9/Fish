using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Lean.Pool;

public class StackTrigger : MonoBehaviour
{
    private float timer = 0;
    private int capturedStacksCount = 0;
    [SerializeField] private float timePassingUntilWeCatchAFish;
    private string stackObjectsTag = "Pick";
    [SerializeField] private Text text;
    [SerializeField] private float timePassingUntilWeDestroyAFish;

    [SerializeField] private List<GameObject> fishList;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(stackObjectsTag))
        {
            Debug.Log("Enter");
            //StackManager.instance.PickUp(other.gameObject, true, "Untagged");
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(stackObjectsTag))
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= timePassingUntilWeCatchAFish)
            {
                StackManager.instance.PickUp(other.gameObject);
                fishList.Add(other.gameObject);
                capturedStacksCount++;
                Debug.Log("Yakalanan balik " + GetCapturedStacksCount());
                timer = 0f;
                text.text = "Fish Count: " + capturedStacksCount;
                LeanPool.Despawn(other.gameObject, timePassingUntilWeDestroyAFish);
                Debug.Log(other.gameObject.name);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(stackObjectsTag))
        {
            Debug.Log("Exited");
            timer = 0;
        }
    }
    public int GetCapturedStacksCount()
    {
        return capturedStacksCount;
    }
}
