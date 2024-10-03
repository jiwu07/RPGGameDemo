using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPC : NPCObject
{
    public TaskSO task;

    void Start()
    {
        task.taskStatus = TaskStatus.Waiting;
    }


    protected override void interact()
    {

        switch (task.taskStatus)
        {
            case TaskStatus.Waiting:
                DialogUI.instanceUI.Show(NPCName, task.dialogStart, OnDialogEnd);
                break;
            case TaskStatus.Processing:
                DialogUI.instanceUI.Show(NPCName, task.dialogProcessing, OnDialogEnd);
                break;
            case TaskStatus.complete:
                DialogUI.instanceUI.Show(NPCName, task.dialogComplete, OnDialogEnd);
                break;
            case TaskStatus.End:
                DialogUI.instanceUI.Show(NPCName, task.dialogEnd, OnDialogEnd);
                break;

        }

    }

    public void OnDialogEnd()
    {
        switch (task.taskStatus)
        {
            case TaskStatus.Waiting:
                //take the task
                task.Start();
                //get begining reward
                Getrewards(task.startReward);
                //create UI
                TaskUIManager.Instance.CreateTaskUI(task);
                break;
            case TaskStatus.complete:
                task.End();
                Getrewards(task.endReward);
                break;


        }
    }

    private void Getrewards(ItemSO[]rewards)
    {
        foreach(ItemSO item in rewards)
        {
            InventoryManager.Instance.AddItem(item);

        }
    }
}
