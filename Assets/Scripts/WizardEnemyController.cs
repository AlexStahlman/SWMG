using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Transform playerTrans;

    [Header("Movement Settings")]
    [SerializeField] private float detectionRange;
    private Vector3 lookDir;
    public NavMeshAgent agent;
    private Animator animation;
    private float radiusOfSatisfaction;
    private float targetRotation;
    [Header("Raycast Jungle")]
    private NavMeshHit hit;
    private bool theRay;
    public Vector3 direction;
    private EnemySpellCaster EnemyCast;

    [Header("Hot Steamy Variables")]
    [SerializeField] public wizcurrentState wizcurrentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform childObject = transform.Find("Skeleton");
        animation = childObject.GetComponent<Animator>();
        animation.SetBool("Idle", true);
        theRay = false;
    }
    #region State Machine
    void State()
    {
        // this one \/ is a first try at it, but its here incase the agent.Raycast becomes stupid
        //theRay = NavMesh.Raycast(transform.position, playerTrans.position, out hit, NavMesh.AllAreas);
        theRay = agent.Raycast(playerTrans.position, out hit);
        Debug.DrawRay(hit.position, Vector3.up, Color.green);
        if (this.wizcurrentState == wizcurrentState.Idle)
        if (this.wizcurrentState == wizcurrentState.Idle)
        {
            //theRay is a boolean raycast that returns true if connected
            if (!theRay)
            {
                this.wizcurrentState = wizcurrentState.Moving;
                animation.SetBool("Idle", false);
                animation.SetBool("Moving", true);
                animation.SetBool("Attacking", false);
            }
        }
        else if (wizcurrentState == wizcurrentState.Moving)
        {

            agent.SetDestination(playerTrans.position);
            //IF THE RAYCAST IS LOST, GOTO IDLE!!!
            if (theRay)
            {
                this.wizcurrentState = wizcurrentState.Idle;
                animation.SetBool("Idle", true);
                animation.SetBool("Moving", false);
                animation.SetBool("Attacking", false);
            }
            if (agent.isStopped)
            {
                this.wizcurrentState = wizcurrentState.Attack;
            }
        }
        else if (this.wizcurrentState == wizcurrentState.Attack)
        {
            //attack animation and boom pow damage
            animation.SetBool("Idle", false);
            animation.SetBool("Moving", false);
            animation.SetBool("Attacking", true);
                //Get current state in animation, if attacking is still playing its true

            //cast spell !!:!!!!?!?!!11!!
            EnemyCast.casting = true;


            if (animation.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
            {
                return;
            }
            else //else = attack be done yarrr
            {
                this.wizcurrentState = wizcurrentState.Moving;
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
public enum wizcurrentState
{
    Idle,
    Moving,
    Attack
}