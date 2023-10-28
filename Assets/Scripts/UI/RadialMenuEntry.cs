using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] TextMeshProUGUI spellName;
    [SerializeField] TextMeshProUGUI cooldownText;
    public Image Icon;
    public Spell spellScript;
    private bool onCooldown;
    private RadialMenu parent;
    private float curCooldown;
    private void Start(){
    parent=GetComponentInParent<RadialMenu>();
    }
    public void SetName(){
        if(spellScript){
        spellName.text=spellScript.spell.name;
        }
    }
    public void OnPointerClick(PointerEventData eventData){
        parent.SelectedEntry=this;
        parent.spellManager.curSpell=this.spellScript;
        print(spellName.text);
        
    }
    public void Update(){
        TickCooldown();
    }
    public void TickCooldown(){
        if(!onCooldown && !spellScript.canCast){
        onCooldown=true;
        curCooldown=spellScript.spell.cooldown;
       }
       if(onCooldown){
        curCooldown-=Time.deltaTime;
        cooldownText.text=curCooldown.ToString();
        if(curCooldown<=0){
            onCooldown=false;
            curCooldown=0;
            cooldownText.text="";
            spellScript.canCast=true;
        }
        }
    }
    public void OnBeginDrag(PointerEventData eventData){

    }
    public void OnDrag(PointerEventData eventData){

    }
    public void OnEndDrag(PointerEventData eventData){
        if(this==parent.SelectedEntry){
        parent.RemoveEntry();
        }
    }

}
