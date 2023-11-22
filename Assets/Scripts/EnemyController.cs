using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTrans;

    [Header("Movement Settings")]
    [SerializeField] private float detectionRange;
    private Vector3 lookDir;
    public NavMeshAgent agent;
    private new Animator animation;
    private float radiusOfSatisfaction;
    private float targetRotation;
    [Header("Raycast Jungle")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;

    [Header("Temparary Testing Variables")]
    [SerializeField] public currentState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform childObject = transform.Find("Skeleton");
        animation = childObject.GetComponent<Animator>();
        animation.SetBool("Idle", true);
        theRay = false;
    }
    #region State Machine
    public void State()
    {
        // this one \/ is a first try at it, but its here incase the agent.Raycast becomes stupid
        //theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, NavMesh.AllAreas);
        theRay = agent.Raycast(playerTrans.position, out hit);
        Debug.DrawRay(hit.position, Vector3.up, Color.green);
        if (currentState == currentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            if(!theRay){
                this.currentState = currentState.Moving;
                animation.SetBool("Idle", false);
                animation.SetBool("Moving", true);
                animation.SetBool("Attacking", false);
            }
        }
        else if (this.currentState == currentState.Moving)
        {
            
            agent.SetDestination(playerTrans.position);
            //IF THE RAYCAST IS LOST, GOTO IDLE!!!
            if (theRay)
            {
                this.currentState = currentState.Idle;
                animation.SetBool("Idle", true);
                animation.SetBool("Moving", false);
                animation.SetBool("Attacking", false);
            }
            if(agent.isStopped)
            {
                this.currentState = currentState.Attack;
            }
        }
        else if (this.currentState == currentState.Attack)
        {
            //attack animation and boom pow damage
            animation.SetBool("Idle", false);
            animation.SetBool("Moving", false);
            animation.SetBool("Attacking", true);
            //Get current state in animation, if attacking is still playing its true
            if (animation.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
            {
                return;
            }
            else //else = attack be done yarrr
            {
                this.currentState = currentState.Moving;
            }
        }
    }
    void Gravity()
    {
        //will be added maybe sometime
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        State();
    }
}
public enum currentState
{
    Idle,
    Moving,
    Attack
}
