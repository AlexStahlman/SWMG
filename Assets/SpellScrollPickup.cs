using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScrollPickup : MonoBehaviour
{
    private Material IconMat;

    [SerializeField] private UIManager ui;
    [SerializeField] private Spell spell;



    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            ui.curPickup=this.gameObject;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag=="Player"){
            ui.curPickup=null;
        }
    }
}
