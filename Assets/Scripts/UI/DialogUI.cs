using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{

    public static DialogUI instanceUI{ get; private set;}

    public TextMeshProUGUI contentText;
    public TextMeshProUGUI nameText;
    public Button nextButton;

    public GameObject UI;

    private List<string> contentList; // dialog content
    private int contentIndex = 0;

    private Action OnDialogEnd;

    private void Awake()
    {
        if(instanceUI != null && instanceUI != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instanceUI = this;
    }

    public void Start()
    {
        nextButton.onClick.AddListener(this.OnButtonClick);
        Hide();
    }

   

    public void Show()
    {
        UI.SetActive(true);
    }

    public void Show(string name, string[] content, Action OnDialogEnd = null)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0]; //show the first sentence
        UI.SetActive(true);
        this.OnDialogEnd = OnDialogEnd;

    }

    public void Hide()
    {
        contentIndex = 0;
        UI.SetActive(false);
    }

    private void OnButtonClick()
    {
        contentIndex++;
        if(contentIndex >= contentList.Count)
        {
            OnDialogEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }
}
