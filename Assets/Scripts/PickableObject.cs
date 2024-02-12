using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : interactableObject
{
    protected override void interact()
    {
        Debug.Log("pickableObject");
    }
}
