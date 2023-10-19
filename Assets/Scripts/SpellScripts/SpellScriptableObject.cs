using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScriptableObject : ScriptableObject
{
    public float mpCost;
    public float lifetime;
    public float baseCooldown;
    protected float cooldown;
    public string name;
}
