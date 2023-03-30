using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorScript : ActivatableObject
{
    [SerializeField] private Transform doorLeftEnding;
    [SerializeField] private Transform doorRightEnding;
    private Vector3 doorLeftStartingPosition;
    private Vector3 doorRightStartingPosition;
    [SerializeField] private bool scale = false;
    [SerializeField] private Transform doorLeft;
    [SerializeField] private Transform doorRight;

    [SerializeField] private Collider floorCollider;
    private void Awake()
    {
        doorRightStartingPosition = doorRight.position;
        doorLeftStartingPosition = doorLeft.position;
        try { floorCollider.gameObject.SetActive(false); } catch { }
    }
    public override void Activate()
    {
        if (!scale)
        {
            doorLeft.DOMove(doorLeftEnding.position, 1);
            doorRight.DOMove(doorRightEnding.position, 1);
        }
        else
        {
            doorLeft.DOScale(new Vector3(0, 0, 0), 1);
            doorRight.DOScale(new Vector3(0, 0, 0), 1);
        }
        try { floorCollider.gameObject.SetActive(true); } catch { }
    }
    public override void Deactivate()
    {
        if (!scale)
        {
            doorLeft.DOMove(doorLeftStartingPosition, 1);
            doorRight.DOMove(doorRightStartingPosition, 1);
        }
        else
        {
            doorLeft.DOScale(Vector3.one, 1);
            doorRight.DOScale(Vector3.one, 1);
        }
        try { floorCollider.gameObject.SetActive(false); } catch { }
    }
}
