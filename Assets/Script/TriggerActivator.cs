using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    //
    //VARIABLE
    //
    [SerializeField] private List<string> tagToCollide = new();
    [SerializeField] private List<ActivatableObject> objectsToActivate = new();
    [SerializeField] private AudioSource soundWhenActivated;
    [SerializeField] private AudioSource soundWhenDeActivated;
    private List<GameObject> colliders = new();
    [SerializeField] private Light lightComponent;
    private bool IsActive = false;
    //
    //MONOBEHAVIOUR
    //
    private void OnTriggerEnter(Collider other)
    {
        if(tagToCollide.Contains(other.gameObject.tag) && !IsActive)
        {
            colliders.Add(other.gameObject);
            IsActive = true;
            print("Trigger Activit");
            //SetTheLightColor(Color.green);
            ActivateOtherGameObject();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(colliders.Contains(other.gameObject))
        {
            colliders.Remove(other.gameObject);
            if(colliders.Count <= 0)
            {
                IsActive = false;
                DeactivateOtherGameObject();
            }
        }
    }

    private void DeactivateOtherGameObject()
    {
        foreach (ActivatableObject activatable in objectsToActivate)
        {
            activatable.UnTrigger();
        }
        //SetTheLightColor(Color.white);
        //soundWhenDeActivated.Play();
    }

    //
    //FONCTION
    //


    private void ActivateOtherGameObject()
    {
        foreach (ActivatableObject activatable in objectsToActivate)
        {
            activatable.Trigger();
        }
        //soundWhenActivated.Play();
    }

    private void SetTheLightColor(Color color)
    {
        //lightComponent.color = color;
    }
}
