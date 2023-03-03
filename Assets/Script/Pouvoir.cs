using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouvoir : MonoBehaviour
{
    public GameObject shield;
    public float test;

    void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Bouclier());
        }
    }

    public IEnumerator Bouclier ()
    {
        int i = 0;
        while (i < 6)
        {
        if (i == 5)
        { 
          shield.SetActive(false);
          i++;
          Debug.Log(i);
        }
        else
        {
            Debug.Log(i);
            shield.SetActive(true);
            i++;
            yield return new WaitForSeconds(5f);
        }
        }
     }
}
