using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Spell", menuName ="Scriptable/Spell")]
public class SpellScriptable : ScriptableObject
{
    public string name;
    public Sprite spriteSpell;
    public List<Vector3> listPath;
    public GameObject spellObject;
    public Material orb1, orb2;
}
