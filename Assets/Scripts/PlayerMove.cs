using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<interactableObject>().OnClick(playerAgent);
                }
                else if (hit.collider.tag == "Ground")
                {
                    playerAgent.stoppingDistance = 0;
                    playerAgent.SetDestination(hit.point);
                }

                
            }
        }
    }
}
