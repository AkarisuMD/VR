using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    [SerializeField] private MeshRenderer meshRenderer;

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
            //SetTheLightColor(Color.green);
            ActivateOtherGameObject();
        }
        else if(other.gameObject.tag != "Untagged" || other.gameObject.tag != "Player")
        {

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
        meshRenderer.material.color = Color.red;
        lightComponent.DOColor(Color.red, 1);
        soundWhenDeActivated.Play();
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
        meshRenderer.material.color = Color.green;
        lightComponent.DOColor(Color.green, 1);
        soundWhenActivated.Play();
    }
}
