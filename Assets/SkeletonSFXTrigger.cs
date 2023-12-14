using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSFXTrigger : MonoBehaviour
{
    public float distanceToPlayer;

    void Update(){
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
