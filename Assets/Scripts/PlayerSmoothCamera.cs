using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmoothCamera : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float smoothTurnSpeed;
    [SerializeField] private Vector3 offset;
    
    void LateUpdate()
    {
        Vector3 desiredPosition = targetTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothTurnSpeed);
        transform.position = smoothedPosition;
        
        transform.LookAt(targetTransform);

    }
}
