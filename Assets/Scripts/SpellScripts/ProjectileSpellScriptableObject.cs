using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName= "New Projectile Spell", menuName= "Spells")]
public class ProjectileSpellScriptableObject : SpellScriptableObject
{
    public float damage;
    public bool deferStoppingToParticle;
    public bool destroyOnCollision;
    public float speed;
    public void Start(){
    cooldown=baseCooldown; 
    }
}
