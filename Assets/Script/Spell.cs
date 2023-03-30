using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Spell : MonoBehaviour
{
    public GameObject inactifObj;
    public GameObject actifObj;

    public GameObject rightHant, leftHand;

    public SpellScriptable _currentSpellScriptable;
    public SpellScriptable shieldSpell;
    public SpellScriptable missileSpell;

    private bool _flipflop;


    public int spellId;
    public int currentSpellPathIndex;

    float timer = 0f;

    public bool handGrab;
    public bool handInSpell;
    public bool handStartSpellCast;
    public bool isCasting;
    public bool spellDone;

    public InputActionProperty grip_Input;

    Vector3 posAtStartCasting;

    public TrailRenderer trailRenderer;
    private void OnTriggerEnter(Collider other)
    {
        print("hand inside" + other.gameObject.name);
        if (other.CompareTag("Hand"))
        {
            handInSpell = true;
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
        FlipFlopGlobal.Instance.flipFlop.AddListener(FlipFlop);
    }
    void FlipFlop()
    {
        _flipflop = !_flipflop;
        if (_flipflop)
        {
            _currentSpellScriptable = shieldSpell;
        }
        else
        {
            _currentSpellScriptable = missileSpell;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;

        handGrab = grip_Input.action.ReadValue<float>() >= 0.5f;

        // start a spell
        if (!spellDone && handInSpell && handGrab && currentSpellPathIndex == 0)
        {
            spellDone = true;
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

        if (!handGrab && spellDone)
        {
            spellDone = false;
        }

        if (handInSpell && isCasting && currentSpellPathIndex != 0 && timer > 0.05f)
        {
            try
            {
                Path();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    public Vector3 rotation;
    /// <summary>
    /// start the spell when the hand grab the orb
    /// </summary>
    void StartCast()
    {
        actifObj.transform.position = inactifObj.transform.position;
        actifObj.transform.rotation = inactifObj.transform.rotation;
        transform.parent = actifObj.transform;
        GetComponent<MeshRenderer>().material = _currentSpellScriptable.orb2;
        trailRenderer.time = 999999;

        currentSpellPathIndex = 0;

        Path();
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
        if(_currentSpellScriptable.listPath.Count <= currentSpellPathIndex +1)
        {
            SuccesfullCast();
            return;
        }
        else 
        {
            currentSpellPathIndex++;
        }

        timer = 0;
        print("path");
        // set the next location of the orb
         transform.localPosition += _currentSpellScriptable.listPath[currentSpellPathIndex];

    }
    /// <summary>
    /// made all the path to the cast
    /// </summary>
    void SuccesfullCast()
    {
        Instantiate(_currentSpellScriptable.spellObject, leftHand.transform.position, leftHand.transform.rotation);
        EndCast();
    }
}
