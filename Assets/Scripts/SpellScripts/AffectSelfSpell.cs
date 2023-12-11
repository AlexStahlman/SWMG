using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "New Heal Spell", menuName= "Self Spells")]
public class AffectSelfSpell : SpellScriptableObject
{
    public float areaRad;
    public float healAmount;
    public void Start(){
    cooldown=baseCooldown; 
    }
    public void UpdateFunction(Transform transform){
        
    }
    public void CollisionFunction(GameObject other,Transform self){
    }
}

