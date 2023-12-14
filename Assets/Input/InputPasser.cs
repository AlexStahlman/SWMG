using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class InputPasser : MonoBehaviour
{   
    public Vector2 movement;
    public Vector2 look;
    public float attack;
    public delegate void MenuOpenAction(bool menuStatus);
    public event MenuOpenAction OnMenuOpenEvent;

    public delegate void PickupAction();
    public event PickupAction OnPickupActionEvent;


    public void OnMove(InputValue moveVal){
        movement=moveVal.Get<Vector2>();
    }
    public void OnLook(InputValue lookVal){
        look=lookVal.Get<Vector2>();
    }
    public void OnAttack(InputValue attackVal){
        attack=attackVal.Get<float>();
        
    }
    public void OnMenuOpen(InputValue menuOpen){
        if(OnMenuOpenEvent!=null){
            OnMenuOpenEvent(menuOpen.Get<float>()==1);
        }
    }
    public void OnPickup(InputValue pickup){
        if(OnPickupActionEvent!=null){
            OnPickupActionEvent();
        }
    }
    public void OnRestartBtn(InputValue restart){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    

}