using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileTest : SpellBehaviour
{
    public ParticleSystem ps;
    public Rigidbody rb;
    public float speed = 1;
    protected override void Update()
    {
        base.Update();
        rb.velocity = transform.forward* speed;

        if (timer < -5)
        {
            Destroy(gameObject);
        }
    }
    public override void Effect(Target target)
    {
        Debug.Log("effect");
        target.hp -= spellScriptable.damage;

        Instantiate(ps, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public override void CibleEffect(Cible cible)
    {
        Debug.Log("effect");

        Instantiate(ps, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit collision");
        if (timer > -0.02f) return;

        Instantiate(ps, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
