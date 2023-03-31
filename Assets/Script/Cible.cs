using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Cible : MonoBehaviour
{
    public Material Activate;
    public Material Desactivate;
    public List<ActivatableObject> activatableObjects;

    public bool doRealFlipFlop;
    public bool flipFlop => (trueflipFlop && !isInvert) || (!trueflipFlop && isInvert);
    public bool trueflipFlop = false;
    public bool isInvert = false;

    [Button]
    void Test()
    {
        trueflipFlop = !trueflipFlop;
        if (trueflipFlop) { GetComponent<MeshRenderer>().material = Desactivate; }
        else { GetComponent<MeshRenderer>().material = Activate; }
        if (!doRealFlipFlop)
        {
            if (flipFlop)
            {
                foreach (var item in activatableObjects)
                {
                    item.Trigger();
                }
            }
            else
            {
                foreach (var item in activatableObjects)
                {
                    item.UnTrigger();
                }
            }
        }
        else {
            foreach (var item in activatableObjects)
            {
                item.FlipFlop();
            }
        }
    }
    private void Start()
    {
        if (trueflipFlop) { GetComponent<MeshRenderer>().material = Desactivate; }
        else { GetComponent<MeshRenderer>().material = Activate; }
        if (!doRealFlipFlop)
        {
            if (flipFlop)
            {
                foreach (var item in activatableObjects)
                {
                    item.Trigger();
                }
            }
        }
        else
        {
            foreach (var item in activatableObjects)
            {
                item.FlipFlop();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SpellBehaviour>(out SpellBehaviour sb))
        {
            Debug.Log("Missile did it");
            if (!sb.GetSpriptable().isOffensif) return;
            trueflipFlop = !trueflipFlop;

            if (trueflipFlop) { GetComponent<MeshRenderer>().material = Desactivate; }
            else { GetComponent<MeshRenderer>().material = Activate; }

            if (!doRealFlipFlop)
            {
                if (flipFlop)
                {

                    foreach (var item in activatableObjects)
                    {
                        item.UnTrigger();
                    }
                }
                else
                {

                    foreach (var item in activatableObjects)
                    {
                        item.Trigger();
                    }
                }
            }
            else
            {
                foreach (var item in activatableObjects)
                {
                    item.FlipFlop();
                }
            }
        }
    }
}
