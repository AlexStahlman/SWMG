using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController playerCC;
    private PlayerInput playerInput;
    private InputPasser input;
    public Transform camAnchor;
    public Transform controller;
    private Camera cam;
    private LayerMask lookMask;
    [Header("Movement Settings")]
    [SerializeField] private float rotationTime;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float accVal;
    public bool orientToMovement;
    private float targetRotation;
    private float targetSpeed;
    private float rotationVelocity;
    private float verticalVelocity;
    private float currentSpeed;
    private Vector3 lookDir;
    [Header("Camera")]
    [SerializeField,Range(0,1)] private float camSpeed;
    void Start()
    {
    lookMask=~LayerMask.GetMask("Player","Walls","StencilLayerTest");
    playerInput = GetComponent<PlayerInput>();
    playerCC = GetComponent<CharacterController>();
    input= GetComponent<InputPasser>();
    cam= Camera.main;
    }
    #region Movement
    void Move(){

        targetSpeed=walkSpeed;
        Vector3 inputDirection = new Vector3(input.movement.x, 0.0f, input.movement.y).normalized;
        inputDirection=Quaternion.AngleAxis(-45,Vector3.up)*inputDirection;
        if(!orientToMovement){
            
        }
        if(input.movement == Vector2.zero){
            targetSpeed=0.0f;
        }
        if (input.movement != Vector2.zero || !orientToMovement)
        {
            
            targetRotation = orientToMovement ? Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg : Mathf.Atan2(lookDir.x,lookDir.z)* Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, rotationTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            
        }   
            Vector3 targetDirection = orientToMovement ? Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward : inputDirection ;
            
            float currentHorizontalSpeed = new Vector3(playerCC.velocity.x, 0.0f, playerCC.velocity.z).magnitude;
            float speedOffset = 0.1f;

            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
 
                currentSpeed = Mathf.Round(Mathf.Lerp(currentHorizontalSpeed, targetSpeed * input.movement.magnitude, Time.deltaTime * accVal) * 1000f) / 1000f;
            }
            else
            {
                currentSpeed = targetSpeed;
            }
            playerCC.Move(targetDirection.normalized * (currentSpeed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);
    }
    void Gravity(){
        //will be added maybe sometime
    }
    #endregion
    #region Camera and Controller
    void ControllerUpdate(){
        controller.position=transform.position;
    }
    void CamUpdate(){
        camAnchor.position=Vector3.Lerp(camAnchor.position, transform.position, camSpeed);
    }
    void LookUpdate(){
        if(Physics.Raycast(cam.ScreenPointToRay(new Vector3(input.look.x,input.look.y,0)),out RaycastHit hit,cam.farClipPlane, lookMask.value)){
            lookDir=hit.point-transform.position;
            lookDir= new Vector3(lookDir.x,0.0f,lookDir.z).normalized;
            Debug.DrawRay(transform.position,lookDir, Color.red);
            Debug.DrawRay(hit.point,Vector3.up*30,Color.green);
        }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        LookUpdate();
        ControllerUpdate();
        CamUpdate();
        Move();
    }
}
