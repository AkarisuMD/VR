using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableObject : MonoBehaviour
{
    [SerializeField] private int triggerNeeded = 1;
    private int actifTrigger = 0;
    public abstract void Activate();
    public abstract void Deactivate();
    public void Trigger()
    {
        actifTrigger++;
        CheckIfDeactivateObject();
    }
    public void UnTrigger()
    {
        actifTrigger--;
        CheckIfDeactivateObject();
    }
    private void CheckIfDeactivateObject()
    {
        if(actifTrigger >= triggerNeeded)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
}
