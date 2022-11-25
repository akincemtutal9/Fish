using UnityEngine;
public class Target : MonoBehaviour
{
    
    [SerializeField] private GameObject targetObject;
    void Start()
    {
        //renderer = GetComponent<Renderer>();
    }
    private void OnMouseEnter()
    {
        targetObject.GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        targetObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
