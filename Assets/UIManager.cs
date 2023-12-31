using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Image EndScreen;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject radialMenu;
    private RadialMenu radialMenuScript;
    [SerializeField] private InputPasser input;
    public Image HealthBar;
    public Image ManaBar;

    [Header("Pickups")]
    public TextMeshProUGUI pickupText;
    public GameObject curPickup;
    public Pickup curPickupScript;
    void Start(){
        radialMenuScript=radialMenu.GetComponent<RadialMenu>();
        input.OnMenuOpenEvent+=ToggleMenu;
        input.OnPickupActionEvent+=Pickup;
    }
    void ToggleMenu(bool status){
        radialMenuScript.radialMenuGroup.interactable=status;
        radialMenuScript.radialMenuGroup.blocksRaycasts=status;
        radialMenuScript.radialMenuGroup.alpha=Convert.ToSingle(status);
    }
    void Pickup(){
        if(curPickup){
        curPickupScript=curPickup.GetComponent<Pickup>();
        radialMenuScript.AddEntry(curPickupScript.pickup,curPickupScript.Icon.material);
        Destroy(curPickup);
        }
    }
    public void WinLoseUI(bool winlose){
        EndScreen.gameObject.SetActive(true);
        if(winlose==true){
            endText.text="Victory!\n\nPress 'R' to restart!";
            endText.color=Color.green;
        }else{
            endText.text="Defeat...";
            endText.color=Color.red;
        }
        PlayerInput playerInput=GameObject.Find("CharacterController/Capsule").GetComponent<PlayerInput>();
        playerInput.DeactivateInput();
    }

}