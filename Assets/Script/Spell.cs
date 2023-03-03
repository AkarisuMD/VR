using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spell : MonoBehaviour
{
    public GameObject inactifObj;
    public GameObject actifObj;



    public List<SpellScriptable> spellScriptable;
    public SpellScriptable _currentSpellScriptable;
    public SpellScriptable currentSpellScriptable
    {
        get
        {
            return _currentSpellScriptable;
        }
        set 
        { 
            _currentSpellScriptable = value;
            // do something
        }
    }
    public int spellId;
    public int currentSpellPathIndex;

    public bool handGrab;
    public bool handInSpell;
    public bool handStartSpellCast;
    public bool isCasting;

    public InputActionProperty grip_Input;

    public TrailRenderer trailRenderer;
    private void OnTriggerEnter(Collider other)
    {
        print("hand inside" + other.gameObject.name);
        if (other.CompareTag("Hand"))
        {
            handInSpell = true;

            if (isCasting)
                Path();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            handInSpell = false;
        }
    }
    private void Start()
    {
        transform.localPosition = _currentSpellScriptable.listPath[0];
    }
    private void Update()
    {
        handGrab = grip_Input.action.ReadValue<float>() >= 0.5f;

        // start a spell
        if (handInSpell && handGrab)
        {
            handStartSpellCast = true;
            StartCast();
        }
        // is doing a spell
        else if (handGrab && handStartSpellCast)
        {
            isCasting = true;
        }
        // don't do the speel / cancel it
        else
        {
            trailRenderer.time = 0;
            handStartSpellCast = false;
            isCasting = false;
            EndCast();
        }
    }
    /// <summary>
    /// start the spell when the hand grab the orb
    /// </summary>
    void StartCast()
    {
        transform.parent = actifObj.transform;
        transform.localPosition = _currentSpellScriptable.listPath[0];
        GetComponent<MeshRenderer>().material = _currentSpellScriptable.orb2;
        trailRenderer.time = 999999;

        currentSpellPathIndex = 0;
    }
    /// <summary>
    /// reset all cast done or in going
    /// </summary>
    void EndCast()
    {
        transform.parent = inactifObj.transform;
        transform.localPosition = _currentSpellScriptable.listPath[0];
        GetComponent<MeshRenderer>().material = _currentSpellScriptable.orb1;

        trailRenderer.time = 0;

        currentSpellPathIndex = 0;
    }
    /// <summary>
    /// did a path on the casting
    /// </summary>
    void Path()
    {
        if(_currentSpellScriptable.listPath.Count <= currentSpellPathIndex)
        {
            SuccesfullCast();
            return;
        }
        else 
        {
            currentSpellPathIndex++;
        }

        // set the next location of the orb
        transform.position = _currentSpellScriptable.listPath[currentSpellPathIndex];
    }
    /// <summary>
    /// made all the path to the cast
    /// </summary>
    void SuccesfullCast()
    {
        // Instantiate(currentSpellScriptable.spellObject)
    }
}
