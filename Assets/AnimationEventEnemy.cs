using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventEnemy : MonoBehaviour
{
    private EnemyController controller;
    public float distanceToPlayer;
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
       getPlayerDistance(); 
    }


    public void playSkeletonSwingSFX(){
        if(distanceToPlayer >= 2.5f) {
            AudioManager.instance.play_Swing();
            Debug.Log("Too far");
        }
        else{
            AudioManager.instance.play_Punch();
            Debug.Log("Close Enough");
        }
    }
    //triggers a miss air swing sound or punch hit sound depending on distance from player
    public void getPlayerDistance(){
        distanceToPlayer = EnemyController.distToTarget;
    }
  
}
