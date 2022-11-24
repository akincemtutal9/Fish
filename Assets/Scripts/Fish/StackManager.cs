using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{

    public static StackManager instance;

    private float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;
    [SerializeField] private float doTweenDoMoveDurationWhileAddingFishToBag;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.y;    
    }

    public void PickUp(GameObject pickedObject)
    {
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += distanceBetweenObjects;
        pickedObject.transform.DOLocalMove(desPos, doTweenDoMoveDurationWhileAddingFishToBag);
        //pickedObject.transform.localPosition = desPos;
        //prevObject = pickedObject.transform;
    }
}
