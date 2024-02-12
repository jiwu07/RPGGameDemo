using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : interactableObject
{

    public string NPCName;
    public string[] dialog;

    public DialogUI dialogUI;

    protected override void interact()
    {
        
        dialogUI.Show(NPCName, dialog);
    }
}
