using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    public Material Activate;
    public Material Desactivate;
    public List<ActivatableObject> activatableObjects;

    public bool flipFlop = false;

    private void Start()
    {
        if (flipFlop)
        {
            GetComponent<MeshRenderer>().material = Activate;
            foreach (var item in activatableObjects)
            {
                item.Trigger();
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material = Desactivate;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SpellBehaviour>(out SpellBehaviour sb))
        {
            if (!sb.GetSpriptable().isOffensif) return;
            flipFlop = !flipFlop;

            if (flipFlop)
            {
                GetComponent<MeshRenderer>().material = Activate;
                foreach (var item in activatableObjects)
                {
                    item.Trigger();
                }
            }
            else
            {
                GetComponent<MeshRenderer>().material = Desactivate;
                foreach (var item in activatableObjects)
                {
                    item.UnTrigger();
                }
            }
        }
    }
}
