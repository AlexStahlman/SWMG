using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTrans;
    private SpellManager playerManager;
    [Header("Movement Settings")]
    [SerializeField] private bool wizardEnemy;
    [SerializeField] private float detectionRange;
    [SerializeField] float fleeRange = 2f;
    [SerializeField] public bool fleeing = false;
    public NavMeshAgent agent;
    private new Animator animation;
    public static float distToTarget;
    private Vector3 targetPosition;

    [Header("Raycast Jungle")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;

    [Header("Temparary Testing Variables")]
    //this is jsut to hardcode a state, it can stay but isnt needed
    [SerializeField] public currentState currentState;
    [Header("Health")]
    [SerializeField] private float meleeDamage;
    [SerializeField] private float MaxHealth;
    [SerializeField] public float curHealth;
    [SerializeField] private float HPrecharge;
    void Start()
    {
        playerManager=playerTrans.gameObject.GetComponent<SpellManager>();
        print(playerManager);
        agent = GetComponent<NavMeshAgent>();
        Transform childObject = transform.Find("Skeleton");
        animation = childObject.GetComponent<Animator>();
        // animation.SetBool("Idle", true);
        animation.SetTrigger("Idle");
        theRay = false;
        distToTarget = Mathf.Infinity;
    }
    #region State Machine
    public void State()
    {
        // this one \/ is a first try at it, but its here incase the agent.Raycast becomes stupid
        //theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, NavMesh.AllAreas);
        if(playerTrans){
        theRay = agent.Raycast(playerTrans.position, out hit);
        }
        Debug.DrawRay(hit.position, Vector3.up, Color.green);
        if (currentState == currentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            if(!theRay){
                this.currentState = currentState.Moving;
            }
        }
        else if (this.currentState == currentState.Moving)
        {
            distToTarget = Vector3.Distance(transform.position, playerTrans.position);
            //if (!animation.GetCurrentAnimatorStateInfo(0).IsName("Moving") && !animation.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
            
            animation.SetTrigger("Moving");
            animation.ResetTrigger("Attacking");
            animation.ResetTrigger("Idle");

            // if (!animation.GetBool("Moving") && !animation.GetBool("Attacking"))
            // {
            //     animation.SetBool("Idle", false);
            //     animation.SetBool("Moving", true);
            //     animation.SetBool("Attacking", false);
            // }

            //fleeing is for the wizard, he shouldnt get too close
            if (!fleeing)
            {
                agent.SetDestination(playerTrans.position);
            }
            //IF THE RAYCAST IS LOST, GOTO IDLE!!!
            if (theRay)
            {
                this.currentState = currentState.Idle;
                animation.SetTrigger("Idle");
                animation.ResetTrigger("Moving");
                animation.ResetTrigger("Attacking");
            }

            if (wizardEnemy)
            {
                //if the distance from current wizard position to the target is less than a certain circle
                if (distToTarget <= fleeRange)
                {
                    Vector3 toTarget = playerTrans.position - transform.position;
                    if (Vector3.Distance(playerTrans.position, transform.position) < fleeRange)
                    {
                        //making a point opposite current location/destination
                        targetPosition = toTarget.normalized * -fleeRange;
                        agent.SetDestination(targetPosition);
                        
                        fleeing = true;
                    }
                }
                //this is so we arent too far away
                if(distToTarget > 15f || transform.position == targetPosition)
                {
                    fleeing = false;
                }
            }
            
            //else is melee dude
            else
            {
                if (distToTarget < 2.5f)
                {
                    agent.isStopped = true;
                    this.currentState = currentState.Attack;
                }
            }
        }
        else if (this.currentState == currentState.Attack && agent.isStopped)
        {
            distToTarget = Vector3.Distance(transform.position, playerTrans.position);
            //attack animation and boom pow damage
            animation.ResetTrigger("Idle");
            animation.ResetTrigger("Moving");
            animation.SetTrigger("Attacking"); 

            //if distance between player and enemy increases, start moving.
            if (distToTarget > 2.5f)
            {
                this.currentState = currentState.Moving;
                agent.isStopped = false;
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
        if(playerTrans){ 
        State();
        }
        UpdateHP();
    }
    public void UpdateHP(){
        if(curHealth<=0){
        
            Destroy(gameObject, 5);
        }
        if(curHealth<MaxHealth){
            curHealth=Mathf.Clamp(curHealth+HPrecharge*Time.deltaTime,0,MaxHealth);
        }
    }
    public void AttackHit(){
        if((playerTrans.position-transform.position).magnitude<2.5f){
        playerManager.curHealth-=meleeDamage;    
        }
    }
}
public enum currentState
{
    Idle,
    Moving,
    Attack
}
