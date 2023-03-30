using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableObject : MonoBehaviour
{
    public bool isActive;
    [SerializeField] protected bool isFlipFlopable;
    [SerializeField] protected bool flipFlop;
    [SerializeField] private bool inversed = false;

    [SerializeField] private int triggerNeeded = 1;
    [SerializeField] private int actifTrigger = 0;
    private void Awake()
    {
        CheckIfDeactivateObject();
    }
    public abstract void Activate();
    public abstract void Deactivate();
    public void Trigger()
    {
        if (!inversed)
            actifTrigger++;
        else actifTrigger--;
        CheckIfDeactivateObject();
    }
    public void UnTrigger()
    {
        if (actifTrigger <= 0 && !inversed) return;
        if (actifTrigger >= 0 && inversed) return;
        if (!inversed)
            actifTrigger--;
        else actifTrigger++;
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
