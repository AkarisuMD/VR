using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject proje;
    public int force = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Boule = Instantiate(proje, transform.position, Quaternion.identity) as GameObject;
            Boule.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
        }
    }
}
