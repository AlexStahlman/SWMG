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
        State();
        if(currentState == currentState.Moving)
        {
            casting = true;
            castDelay = baseCastDelay;
        }

        //casting stuff
        Debug.DrawRay(castPoint.position, castPoint.forward * 10, Color.blue);
        if(castDelayTimer > 0)
        {
            casting=false;
            castDelayTimer -= Time.deltaTime;
        }
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
        if (casting && curSpell.canCast == true)
        {
            curSpell.canCast = false;
            Instantiate(curSpell, castPoint.position, castPoint.rotation);
        }
    }
}


