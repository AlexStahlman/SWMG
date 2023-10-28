using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScriptableObject : ScriptableObject
{
    public float mpCost;
    public float lifetime;
    public float baseCooldown;
    public float cooldown;
    public string name;

    protected void Start(){
        cooldown=baseCooldown;
    }
    
}
