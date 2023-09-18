using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputPasser : MonoBehaviour
{   
    public Vector2 movement;
    public Vector2 look;
    public void OnMove(InputValue moveVal){
        movement=moveVal.Get<Vector2>();
    }
    public void OnLook(InputValue lookVal){
        look=lookVal.Get<Vector2>();
    }
}
