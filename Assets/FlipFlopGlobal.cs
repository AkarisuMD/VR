using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipFlopGlobal : Singleton<FlipFlopGlobal>
{
    public UnityEvent flipFlop;

    private void Start()
    {
        flipFlop = new UnityEvent();
    }
    public void FlipFlop()
    {
        flipFlop?.Invoke();
    }
}
