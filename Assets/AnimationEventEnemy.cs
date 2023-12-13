using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventEnemy : MonoBehaviour
{
    private EnemyController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponentInParent<EnemyController>();
    }
    public void AttackHit(){
        controller.AttackHit();    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
