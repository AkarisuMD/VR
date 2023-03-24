using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivable : ActivatableObject
{
    [SerializeField] private Light _light;
    [SerializeField] private Color colorActivate;
    [SerializeField] private Color colorDesactivate;

    protected override void Start()
    {
        base.Start();

        if (flipFlop) { Activate(); }
        else { Deactivate(); }
    }
     public override void Activate()
    {
        _light.color = colorActivate;
    }
    public override void Deactivate()
    {
        _light.color = colorDesactivate;
    }
}
