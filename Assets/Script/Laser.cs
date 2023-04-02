using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject Emitter;
    [SerializeField] private GameObject Recepter;
    [SerializeField]
    private GameObject EndPoint;
    [SerializeField] private MeshRenderer recepterMaterial;
    [SerializeField] private Material activate;
    [SerializeField] private Material deactivate;
    [SerializeField] private Vector3 endPointOffSet = Vector3.zero;
    [SerializeField] private List<DoorScript> doorToUnlock;

    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float intensity;

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
            EndPoint.transform.position = hit.point + endPointOffSet;
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
                    recepterMaterial.material = activate;
                    //lr.material.DOColor(Color.blue * Mathf.Pow(2f, intensity - 0.4169f), "_EmissionColor", 0.3f);
                }
                else
                {
                    foreach (DoorScript door in doorToUnlock)
                    {
                        door.UnTrigger();
                    }
                    recepterMaterial.material = deactivate;
                    //lr.material.DOColor(Color.red * Mathf.Pow(2f, intensity - 0.4169f), "_EmissionColor", 0.3f);
                }
            }
        }
        else
        {
            lr.SetPosition(1, -transform.forward * 1000);
            Debug.DrawRay(Emitter.transform.position, Emitter.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            EndPoint.transform.position = -transform.forward * 1000;
        }
    }
}
