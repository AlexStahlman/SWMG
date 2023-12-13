using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellManager : MonoBehaviour
{   
    [SerializeField] private UIManager ui;
    [SerializeField] private float MaxMP;
    [SerializeField] private float curMP;
    [SerializeField] private float MPrecharge;
    [SerializeField] private float MaxHealth;
    [SerializeField] public float curHealth;
    [SerializeField] private float HPrecharge;
    [SerializeField] private float rechargeMP;
    [SerializeField] private Transform castPoint;
    [SerializeField] public Spell curSpell;
    [Header("Cast Delay")]
    [SerializeField] private bool casting;
    [SerializeField] private float baseCastDelay; 
    private float castDelay;
    [SerializeField] private float castDelayTimer;

    // Start is called before the first frame update
    private InputPasser input;
    void Start()
    {
        castDelay=baseCastDelay;
        input= GetComponent<InputPasser>();
        curHealth=MaxHealth;
        curMP=MaxMP;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHPMP();
       if(input.attack==1 && !casting){
        casting=true;
        castDelayTimer=castDelay;
        CastSpell();
       }
       if(casting){
        castDelayTimer-=Time.deltaTime;
        if(castDelayTimer<=0){
            casting=false;
            castDelayTimer=0;
        }
       }
    }
    void CastSpell(){
    if(curSpell && curSpell.canCast==true && curMP>curSpell.spell.mpCost){
    curSpell.canCast=false;
    Instantiate(curSpell, castPoint.position, castPoint.rotation);
    curMP-=curSpell.spell.mpCost;
    }
    }
    public void UpdateHPMP(){
        if(curHealth<=0){
            //Cevion put the death animation time in place of 0
            ui.WinLoseUI(false);
            return;
        }
        if(curHealth<MaxHealth){
            curHealth=Mathf.Clamp(curHealth+HPrecharge*Time.deltaTime,0,MaxHealth);
        }
        if(curMP<MaxMP){
            curMP=Mathf.Clamp(curMP+MPrecharge*Time.deltaTime,0,MaxMP);
        }
        ui.HealthBar.fillAmount=curHealth/MaxHealth;
        ui.ManaBar.fillAmount=curMP/MaxMP;
    }
}
