using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject Emitter;
    [SerializeField] private GameObject Recepter;
    [SerializeField] private DoorScript doorToUnlock;

    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask layerMask;

    public bool HitSomething = false;

    private void FixedUpdate()
    {
        lr.gameObject.transform.localPosition= Vector3.zero;
        lr.SetPosition(0, Vector3.zero);
        print(lr.gameObject.transform.position);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            lr.SetPosition(1, hit.point - transform.position);
            Debug.DrawRay(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.gameObject == Recepter && !HitSomething)
            {
                HitSomething = true;
                doorToUnlock.UnTrigger();
            }

            if (hit.collider.gameObject != Recepter && HitSomething)
            {
                HitSomething = false;
                doorToUnlock.Trigger();
            }
        }
        else
        {
            lr.SetPosition(1, -transform.forward * 1000);
            print("yes");
            Debug.DrawRay(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            
        }
    }
}
