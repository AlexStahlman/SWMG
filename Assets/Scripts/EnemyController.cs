using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTrans;

    [Header("Movement Settings")]
    [SerializeField] private float detectionRange;
    private Vector3 lookDir;
    //public enum currentState;   Uncomment after the test variable is gone of the same name
    public UnityEngine.AI.NavMeshAgent agent;
    private float radiusOfSatisfaction;
    [Header("Raycast Jungle")]
    RaycastHit hit;
    Ray theRay;
    public Vector3 direction;



    [Header("Test Veriables")]
    [SerializeField] public currentState currentState;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Searching()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * detectionRange));
        direction = Vector3.forward * Time.deltaTime;
        theRay = new Ray(transform.position, transform.TransformDirection(direction * detectionRange));
        if(Physics.Raycast(theRay, out hit, detectionRange))
        {
            if(hit.collider.tag == "player")
            {
                //RUSH RAAAAAA
                currentState = currentState.Moving;
            }
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
