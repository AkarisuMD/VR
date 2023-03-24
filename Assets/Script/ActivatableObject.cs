using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableObject : MonoBehaviour
{
    public bool isActive;
    [SerializeField] protected bool isFlipFlopable;
    [SerializeField] protected bool flipFlop;

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
        if (flipFlop)
        {
            if (actifTrigger >= triggerNeeded)
            {
                Deactivate();
                isActive = false;
            }
            else
            {
                Activate();
                isActive = true;
            }


            return;
        }

        if(actifTrigger >= triggerNeeded)
        {
            Activate();
            isActive = true;
        }
        else
        {
            Deactivate();
            isActive = false;
        }
    }

    protected virtual void Start()
    {
        if (isFlipFlopable)
        {
            FlipFlopGlobal.Instance.flipFlop.AddListener(FlipFlop);
            if (flipFlop)
            {
                CheckIfDeactivateObject();
            }
        }
    }

    public void FlipFlop()
    {
        Debug.Log($"FlipFlop , {name} , {flipFlop} ");
        if (flipFlop)
        {
            flipFlop = !flipFlop;
            CheckIfDeactivateObject();
        }
        else
        {
            flipFlop = !flipFlop;
            CheckIfDeactivateObject();
        }
    }
}
