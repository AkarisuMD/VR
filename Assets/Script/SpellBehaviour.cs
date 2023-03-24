using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBehaviour : MonoBehaviour
{
    SpellScriptable spellScriptable;
    public SpellScriptable GetSpriptable() { return spellScriptable; }
    float timer = 0;

    private void Update()
    {
        timer -= Time.deltaTime;
    }
    public void Hit(Target target)
    {
        if (timer < 0) return;
        timer = spellScriptable.hitCooldown;

        Effect(target);
    }

    public virtual void Effect(Target target) { }
}
