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
    //public enum currentState;   Uncomment after the test variable is gone of the same name
    public NavMeshAgent agent;
    private float radiusOfSatisfaction;
    private float targetRotation;
    [Header("Raycast Jungle")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;



    [Header("Test Veriables")]
    [SerializeField] public currentState currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        theRay = false;
    }
    void Searching()
    {
        theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, UnityEngine.AI.NavMesh.AllAreas);
        Debug.DrawLine(transform.position, playerTrans.position, theRay ? Color.red : Color.green);
        if(theRay){
            Debug.DrawRay(hit.position, Vector3.up, Color.red);
        }
    }
    #region State Machine
    void State()
    {
        //state 0 is idle
        if (currentState == currentState.Idle)
        {
            Searching();
        }
        //state 1 is moving to player
        else if (currentState == currentState.Moving)
        {
            //targetRotation = orientToMovement ? Mathf.Atan2(agent.direction.x, agent.direction.z) * Mathf.Rad2Deg : Mathf.Atan2(lookDir.x,lookDir.z)* Mathf.Rad2Deg;
            //transform.direction = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
            agent.SetDestination(playerTrans.position);
        }
        //state 2 is attacking
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
