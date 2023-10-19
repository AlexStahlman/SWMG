using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{   
    [SerializeField] private float MaxMP;
    [SerializeField] private float curMP;
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
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(castPoint.position,castPoint.forward*10, Color.blue);
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
    if(curSpell){
    Instantiate(curSpell, castPoint.position, castPoint.rotation);
    }
    }
}
