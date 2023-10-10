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
    theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, UnityEngine.AI.NavMesh.AllAreas);
        if (currentState == currentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            Debug.DrawRay(transform.position, playerTrans.position-transform.position, theRay ? Color.red : Color.green);
            if(theRay){
                currentState = currentState.Moving;
            }
        }
        else if (currentState == currentState.Moving)
        {
            agent.SetDestination(playerTrans.position);
            //if raycast is lost, return to idle (lose focus)
            if(!theRay){
                currentState = currentState.Idle;
            }
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
