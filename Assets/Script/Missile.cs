using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f;

    public Transform target;

    public GameObject impactEffect;

    void Seek(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
    }
    void HitTarget()
    {
    GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(effectIns, 2f);
    Destroy(target.gameObject);
    Destroy(gameObject);
    }
}
