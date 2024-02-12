using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{

    public TextMeshProUGUI contentText;
    public TextMeshProUGUI nameText;
    public Button nextButton;

    public List<string> contentList; // dialog content
    private int contentIndex = 0;

    public void Start()
    {
        nextButton.onClick.AddListener(this.OnButtonClick);
        Hide();
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(string name, string[] content)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0]; //show the first sentence
        gameObject.SetActive(true);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnButtonClick()
    {
        contentIndex++;
        if(contentIndex >= contentList.Count)
        {
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }
}
