using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellCaster : EnemyController
{
    [Header("Wizard Casting Variables")]
    [SerializeField] private float MaxMP;
    [SerializeField] private float curMP;
    [SerializeField] private float rechargeMP;
    [SerializeField] private Transform castPoint;
    [SerializeField] public Spell curSpell;
    [Header("Cast Delay")]
    [SerializeField] public bool casting;
    [SerializeField] private float baseCastDelay;
    private float castDelay;
    [SerializeField] private float castDelayTimer;
    void Update()
    {
        UpdateHP();
        UpdateMP();
        State();

        //if wiz moving then cast spells to the player
        if(currentState == currentState.Moving && !fleeing)
        {
            casting = true;
            castDelay = baseCastDelay;
        }

        Debug.DrawRay(castPoint.position, castPoint.forward * 10, Color.blue);
        //after we set the timer we need it to tick down and make sure its false until it hits 0
        if(castDelayTimer > 0)
        {
            casting=false;
            castDelayTimer -= Time.deltaTime;
        }
        //casting will be true by here if the timer is 0, then we cast the spell
        if (casting && castDelayTimer <= 0)
        {
            castDelayTimer = castDelay;
            CastSpell();
            castDelayTimer -= Time.deltaTime;
            curSpell.canCast = true;
        }
    }
    void CastSpell()
    {
        if (curSpell && curSpell.canCast == true)
        {
            curSpell.canCast = false;
            AudioManager.instance.play_EnemySpellCast();
            Instantiate(curSpell, castPoint.position, castPoint.rotation);
        }
    }
    public void UpdateMP(){
        if(curMP<MaxMP){
            curMP=Mathf.Clamp(curMP+rechargeMP*Time.deltaTime,0,MaxMP);
        }
    }
}


