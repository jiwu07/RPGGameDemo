using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIManager : MonoBehaviour
{

    public static TaskUIManager Instance { get; private set; }
    public GameObject TaskUIPrefab;
    Transform taskList;

    // Start is called before the first frame update
    void Start()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        taskList = transform.Find("Scroll View/Viewport/Content");
    }

    public void CreateTaskUI(TaskSO task)
    {
        GameObject go = Instantiate(TaskUIPrefab);
        go.transform.SetParent(taskList);

        TaskUI ui = go.transform.GetComponent<TaskUI>();
        task.taskUI = ui;
        ui.InitialTaskUI(task);

    }
}
