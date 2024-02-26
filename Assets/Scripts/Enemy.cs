using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        NormalState,
        FightingState,
        Resting,
        Moving
    }

    

    public EnemyState state = EnemyState.NormalState;
    public EnemyState childState = EnemyState.Resting;
    public float restingTime =2f;
    private float restingTimeCount =0;

    private NavMeshAgent enemyAgent;
    public int HP = 80;


    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyState.NormalState)
        {
            if(childState == EnemyState.Resting)
            {
                restingTimeCount += Time.deltaTime;
                if(restingTimeCount >= restingTime)
                {
                    childState = EnemyState.Moving;         
                    enemyAgent.SetDestination(FindRandomPosition());
                }
            }else if (childState == EnemyState.Moving)
            {
                if(enemyAgent.remainingDistance <= 0)
                {
                    childState = EnemyState.Resting;
                    restingTimeCount = 0;
                }
            }
            else
            {
                //fighting state;

            }
        }
    }

    Vector3 FindRandomPosition()
    {
        Vector3 RandomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        int movingLength = Random.Range(4, 8);
        return transform.position + RandomDir * movingLength;
    }

    public void HPdecrise(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            //falling item
        }
    }
}
