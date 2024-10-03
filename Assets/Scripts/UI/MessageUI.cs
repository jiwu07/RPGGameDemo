using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.XR;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance { get; private set; }
    TextMeshProUGUI textUI;

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        textUI = transform.Find("Message").GetComponent<TextMeshProUGUI>();
        Hide();
    }

    private void Update()
    {
        if (textUI.enabled)
        {
            Color color = textUI.color;
            float alpha = Mathf.Lerp(color.a, 0, Time.deltaTime);
            textUI.color = new Color(color.r, color.g, color.b, alpha);

            if(alpha <= 0)
            {
                textUI.enabled = false;
            }
        }
    }

    public void Show(string message)
    {
        textUI.enabled = true;
        textUI.text = message;
        textUI.color = Color.white;

    }

    // Update is called once per frame
    void Hide()
    {
        textUI.enabled = false;

    }
}
