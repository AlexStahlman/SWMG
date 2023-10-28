using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public ProjectileSpellScriptableObject spell;
    public bool canCast=true;
    // Update is called once per frame
    private void Awake(){
        Destroy(gameObject, spell.lifetime);
        
    }
    void Update()
    {
        if(spell.speed>0){
            transform.Translate(Vector3.forward*spell.speed*Time.deltaTime);
        }
    }
    public void OnParticleStopped(){
        if(spell.deferStoppingToParticle){
            Destroy(gameObject);
        }
    }
    public void OnParticleCollision(GameObject other){
        if(other.tag=="Enemy"){
            Destroy(other);
        }
        if(spell.destroyOnCollision){
            Destroy(gameObject);
        }
    }
}
