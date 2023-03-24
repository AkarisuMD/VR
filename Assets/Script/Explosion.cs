using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explos;

    // Start is called before the first frame update
    void Start()
    {
        explos.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Bouclier());
        }
    }

    public IEnumerator Bouclier()
    {
        int i = 0;
        while (i < 3)
        {
            if (i == 2)
            {
                explos.SetActive(false);
                i++;
                Debug.Log(i);
            }
            else
            {
                Debug.Log(i);
                explos.SetActive(true);
                i++;
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
