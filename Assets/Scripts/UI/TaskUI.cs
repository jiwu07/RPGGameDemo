using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    TextMeshProUGUI NPCName;
    TextMeshProUGUI taskCountEnemy;
    TextMeshProUGUI taskCountObject;
    TextMeshProUGUI taskObjectName;

    Image currentImageEnemy;
    Image currentImageObject;


    TextMeshProUGUI description;
    TaskSO task = null;


    // Start is called before the first frame update
    void Awake()
    {
         NPCName = this.transform.Find("NPCName").GetComponent< TextMeshProUGUI>();
         taskCountEnemy = this.transform.Find("TaskCountEnemy").GetComponent<TextMeshProUGUI>();
         taskCountObject = this.transform.Find("TaskCountObject").GetComponent<TextMeshProUGUI>();
         taskObjectName = this.transform.Find("TaskObjectName").GetComponent<TextMeshProUGUI>();
         description = this.transform.Find("TaskDescription").GetComponent<TextMeshProUGUI>();
         //Debug.Log(description);
         currentImageEnemy = this.transform.Find("taskbarEnemy/taskbarEnemy").GetComponent<Image>();
         currentImageObject = this.transform.Find("taskbarObject/taskbarObject").GetComponent<Image>();

    }

    public void InitialTaskUI(TaskSO task)
    {
        //NPCName.text = task.
        this.task = task;
        //Debug.Log(task.taskDescription);
        description.text = task.taskDescription;
        if(task.TaskObjectNeed == 0)
        {
            taskObjectName.gameObject.SetActive(false);
            taskCountObject.gameObject.SetActive(false);
            currentImageObject.transform.parent.gameObject.SetActive(false);
        }
        else 
        {
            taskObjectName.text = task.taskItemType.ToString();
        }
        UpdateTaskProgress();
    }

    public void UpdateTaskProgress()
    {
        if(task.taskStatus == TaskStatus.complete)
        {
            taskCountObject.text = "Task completed!";
            taskCountEnemy.text = "Task completed!";

            return;
        }

        //Item collection
        if(task.TaskObjectNeed != 0)
        {
            taskCountObject.text = task.currentObjectCount.ToString() + "/" + task.TaskObjectNeed.ToString();
            float fo = Math.Max(1.0f, task.currentObjectCount / task.TaskObjectNeed);
            currentImageObject.fillAmount = fo;
            if(task.currentObjectCount >= task.TaskObjectNeed)
            {
                taskCountObject.text = "Task completed!";
            }
        }
        

        //enemy collection
        taskCountEnemy.text = task.currentEnemyCount.ToString() + "/" + task.TaskEnemyNeed.ToString();
        float fe = Math.Max(1.0f,task.currentEnemyCount / task.TaskEnemyNeed);
        currentImageEnemy.fillAmount = fe;
        if (task.currentEnemyCount >= task.TaskEnemyNeed)
        {
            taskCountEnemy.text = "Task completed!";
        }
    }

     void Update()
    {
        if(task != null && task.taskStatus == TaskStatus.End)
        {
            Destroy(this.gameObject);
        }
    }
   
}
