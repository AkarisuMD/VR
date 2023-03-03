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
    [SerializeField] private Transform doorLeft;
    [SerializeField] private Transform doorRight;
    private void Awake()
    {
        doorRightStartingPosition = doorRight.position;
        doorLeftStartingPosition = doorLeft.position;
    }
    public override void Activate()
    {
        doorLeft.DOMove(doorLeftEnding.position, 1);
        doorRight.DOMove(doorRightEnding.position, 1);
        print("open");
    }
    public override void Deactivate()
    {
        doorLeft.DOMove(doorLeftStartingPosition, 1);
        doorRight.DOMove(doorRightStartingPosition, 1);
        print("unopen");
    }
}
