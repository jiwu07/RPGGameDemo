using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : interactableObject
{

    public string NPCName;
    public string[] dialog;

    

    protected override void interact()
    {
        DialogUI.instanceUI.Show( NPCName, dialog);
    }
}
