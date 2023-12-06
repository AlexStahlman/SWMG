using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
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

}