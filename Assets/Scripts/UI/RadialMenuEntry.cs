using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI spellName;
    [SerializeField] TextMeshProUGUI cooldownText;
    [SerializeField] Spell spellScript;

    public void SetName(){
        if(spellScript){
        spellName.text=spellScript.spell.name;
        }
    }
    public void OnPointerClick(PointerEventData eventData){
        GetComponentInParent<RadialMenu>().SelectedEntry=this;
        GetComponentInParent<RadialMenu>().spellManager.curSpell=this.spellScript;
        print(spellName.text);
        
    }

}
