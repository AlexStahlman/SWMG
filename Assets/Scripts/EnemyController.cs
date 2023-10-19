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
    private float radiusOfSatisfaction;
    private float targetRotation;
    [Header("Raycast Jungle")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;

    [Header("Hot Steamy Variables")]
    [SerializeField] public currentState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        theRay = false;
    }
    #region State Machine
    void State()
    {
        // this one \/ is a first try at it, but its here incase the agent.Raycast becomes stupid
        //theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, NavMesh.AllAreas);
        theRay = agent.Raycast(playerTrans.position, out hit);
        Debug.DrawRay(hit.position, Vector3.up, Color.green);
        if (currentState == currentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            if(!theRay){
                currentState = currentState.Moving;
            }
        }
        else if (currentState == currentState.Moving)
        {
            
            agent.SetDestination(playerTrans.position);
            //IF THE RAYCAST IS LOST, GOTO IDLE!!!
            if (theRay)
            {
                currentState = currentState.Idle;
            }
            /* Here is once you hit radius of satisfaction, you go KABOOOM and attack/implode
            if(agent.nextPosition <= radiusOfSatisfaction)
            {
                currentState = currentState.Attack;
            }
            */
        }
        else if (currentState == currentState.Attack)
        {
            //attack animation and boom pow damage
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