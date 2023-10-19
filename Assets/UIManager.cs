using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject radialMenu;
    private RadialMenu radialMenuScript;
    [SerializeField] private InputPasser input;

    [Header("Pickups")]
    public TextMeshProUGUI pickupText;
    public GameObject curPickup;
    public MonoBehaviour curPickupScript;
    void Start(){
        radialMenuScript=radialMenu.GetComponent<RadialMenu>();
        input.OnMenuOpenEvent+=ToggleMenu;
    }
    void ToggleMenu(bool status){
        radialMenu.SetActive(status);
        radialMenuScript.radialMenuGroup.interactable=status;
        radialMenuScript.radialMenuGroup.blocksRaycasts=status;
        radialMenuScript.radialMenuGroup.alpha=Convert.ToSingle(status);
    }
    void Pickup(){
        
    }

}