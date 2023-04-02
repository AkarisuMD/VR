using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int hp;
    public List<SpellBehaviour> spells;
    [SerializeField] private MeshRenderer meshRenderer;

    public bool destroyDoSomething;
    public bool destroyDidSomething;
    public List<ActivatableObject> activatableObjects;
    private void Start()
    {
        spells= new List<SpellBehaviour>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<SpellBehaviour>(out SpellBehaviour sb))
        {
            if (!sb.GetSpriptable().isOffensif) return;
            spells.Add(sb);
        }
    }

    public void Update()
    {
        if (destroyDidSomething) return;

        if (hp <= 0f) { GetDestroy(); }

        if (spells.Count < 0) return;

        for (int i = 0; i < spells.Count; i++)
        {
            spells[i].Hit(this);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<SpellBehaviour>(out SpellBehaviour sb))
        {
            if (!spells.Contains(sb)) return;
            spells.Remove(sb);
        }
    }

    public void GetDestroy()
    {
        Debug.Log($"Destroy {name}");
        if (!destroyDoSomething || activatableObjects.Count <= 0)
        {
            destroyDidSomething = true;
            gameObject.SetActive(false);
            return;
        }

        Debug.Log($"canDestroy {name}");
        destroyDidSomething = true;

        for (int i = 0; i < activatableObjects.Count; i++)
        {
            activatableObjects[i].Trigger();
        }

        gameObject.SetActive(false);
    }
}
