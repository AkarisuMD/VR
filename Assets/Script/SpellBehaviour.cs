using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBehaviour : MonoBehaviour
{
    [SerializeField] protected SpellScriptable spellScriptable;
    public SpellScriptable GetSpriptable() { return spellScriptable; }
    protected float timer = 0;

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
    }
    public void Hit(Target target)
    {
        Debug.Log("Hit");
        if (timer > 0) return;
        timer = spellScriptable.hitCooldown;

        Effect(target);
    }

    public virtual void Effect(Target target) { }
}
