using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject Emitter;
    [SerializeField] private GameObject Recepter;
    [SerializeField] private List<DoorScript> doorToUnlock;

    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask layerMask;

    public bool HitSomething = true;
    [SerializeField] private bool isInverted;

    private void FixedUpdate()
    {
        lr.gameObject.transform.localPosition= Vector3.zero;
        lr.SetPosition(0, Vector3.zero);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            lr.SetPosition(1, hit.point - transform.position);
            Debug.DrawRay(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.gameObject == Recepter && !HitSomething)
            {
                HitSomething = true;

                if (!isInverted)
                {
                    foreach (DoorScript door in doorToUnlock)
                    {
                        door.UnTrigger();
                    }
                }
                else
                {
                    foreach (DoorScript door in doorToUnlock)
                    {
                        door.Trigger();
                    }
                }
            }

            if (hit.collider.gameObject != Recepter && HitSomething)
            {
                HitSomething = false;
                if (!isInverted)
                {
                    foreach (DoorScript door in doorToUnlock)
                    {
                        door.Trigger();
                    }
                }
                else
                {
                    foreach (DoorScript door in doorToUnlock)
                    {
                        door.UnTrigger();
                    }
                }
            }
        }
        else
        {
            lr.SetPosition(1, -transform.forward * 1000);
            Debug.DrawRay(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            
        }
    }
}
