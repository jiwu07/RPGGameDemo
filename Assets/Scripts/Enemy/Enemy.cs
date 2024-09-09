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
    public int exp =20;
    public const string ANIM_PARM_ISFALL = "isFall";

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
                    enemyAgent.SetDestination(FindRandomPosition(Random.Range(4, 8)));
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

    Vector3 FindRandomPosition(float movingLength)
    {
        Vector3 RandomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return transform.position + RandomDir * movingLength;
    }

    public void EnemyDieFallingItem()
    {
        //falling item depengding on the type of the enemy
        int weaponCount = Random.Range(0, 3);
        for (int i = 0; i < weaponCount; i++)
        {
            Vector3 ranP = FindRandomPosition(Random.Range(0, 1));
            (ItemSO, ItemSO) item = ItemManager.Instance.GetRandomWeapon();
            GameObject GO = GameObject.Instantiate(item.Item1.prefab, ranP, item.Item1.prefab.transform.rotation);
            GO.GetComponent<PickableObject>().itemSO = item.Item2;
        }

        int conCount = Random.Range(0, 2);
        for (int i = 0; i < conCount; i++)
        {
            Vector3 ranP = FindRandomPosition(Random.Range(0, 1));
            ItemSO item = ItemManager.Instance.GetRandomConsumable();
            GameObject GO = Instantiate(item.prefab, ranP, item.prefab.transform.rotation);
            GO.GetComponent<PickableObject>().itemSO = item;
        }

        
        
    }
    public void HPdecrease(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            EventCenter.EnemyDied(this);
            EnemyDieFallingItem();
            Destroy(gameObject);
        }


    }
}
