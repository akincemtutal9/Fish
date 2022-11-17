using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Transform target = null;
    void Start()
    {
        if (_agent == null)
        {
            if (!TryGetComponent(out _agent))
            {
                Debug.LogWarning(name + "needs a navmesh agent");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        _agent.SetDestination(target.position);
        _agent.isStopped = false;
    }
    
}
