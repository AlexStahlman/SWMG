using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public SpriteRenderer Icon;

    [SerializeField] public UIManager ui;
    [SerializeField] public Spell pickup;
    private void Start(){
        Icon=gameObject.GetComponentInChildren<SpriteRenderer>();
        Icon.material= new Material(Icon.material);
    }



    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            ui.curPickup=this.gameObject;
            ui.pickupText.text="Pick up "+pickup.spell.name+" [F]";
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"){
            ui.curPickup=null;
            ui.pickupText.text="";
        }
    }
    private void OnDestroy(){
        ui.curPickup=null;
        ui.pickupText.text="";
    }
}
