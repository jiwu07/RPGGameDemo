using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public enum TaskStatus
{
    Waiting,
    Processing,
    complete,
    End
}


[CreateAssetMenu()]
public class TaskSO : ScriptableObject
{
    public TaskStatus taskStatus;
    public string[] dialogStart;
    public string[] dialogProcessing;

    public string[] dialogComplete;
    public string[] dialogEnd;

    public string taskDescription;

    public int TaskEnemyNeed;
    public int currentEnemyCount;

    public int TaskObjectNeed;
    public int currentObjectCount;
    public ItemType taskItemType;
    

    public ItemSO[] startReward;
    public ItemSO[] endReward;

    public TaskUI taskUI;


    public void Start()
    {
        taskStatus = TaskStatus.Processing;
        currentEnemyCount = 0;
        currentObjectCount = 0;
        EventCenter.OnEnemyDied += OnEnemyDied;
        EventCenter.OnTaskObjectGet += OnTaskObjectGet;

        MessageUI.Instance.Show("You recieve an task.");
    }

    private void OnTaskObjectGet(ItemSO taskObject)
    {
        if(taskObject.type != taskItemType)
        {
            Debug.Log("get an task object with "+ taskObject.type);
            return;
        }
        currentObjectCount++;

        if (currentEnemyCount >= TaskEnemyNeed && currentObjectCount >= TaskObjectNeed)
        {
            taskStatus = TaskStatus.complete;

        }
        taskUI.UpdateTaskProgress();
    }


    private void OnEnemyDied(Enemy enemy)
    {
        currentEnemyCount++;

        if (currentEnemyCount >= TaskEnemyNeed && currentObjectCount >= TaskObjectNeed)
        {
            taskStatus = TaskStatus.complete;

        }
        taskUI.UpdateTaskProgress();
    }
    

    public void End()
    {
        taskStatus = TaskStatus.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;
        EventCenter.OnTaskObjectGet -= OnTaskObjectGet;
        MessageUI.Instance.Show("Task completed!");
        taskUI = null;

    }

}
