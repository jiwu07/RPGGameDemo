using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class interactableObject : MonoBehaviour
{
    private bool interacted = false;
    private NavMeshAgent playerAgent;
    private int stopDistance = 2;

    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        //move close to object
        playerAgent.stoppingDistance = stopDistance;
        playerAgent.SetDestination(transform.position);
        interacted = false;
        //interact with object

    }

    private void Update()
    {
        if(playerAgent != null && playerAgent.pathPending == false && !interacted)
        {
            if(playerAgent.remainingDistance <= stopDistance)
            {
                interact();
                interacted = true;
            }
        }
        
    }

    protected virtual void interact()
    {
        Debug.Log("interactableObject interact");
    }
}
