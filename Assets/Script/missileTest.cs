using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileTest : SpellBehaviour
{
    public float speed = 1;
    protected override void Update()
    {
        base.Update();
        transform.position += -transform.up * Time.deltaTime * speed;

        if (timer < -20)
        {
            Destroy(gameObject);
        }
    }
    public override void Effect(Target target)
    {
        Debug.Log("effect");
        target.hp -= spellScriptable.damage;

        Destroy(gameObject);
    }
}
