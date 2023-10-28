using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class RadialMenu : MonoBehaviour
{
    public CanvasGroup radialMenuGroup;
    private List<RadialMenuEntry> menuEntries;
    public GameObject menuEntryObject;
    public float menuRadius;

    private RadialMenuEntry selectedEntry;

    public SpellManager spellManager;

    public RadialMenuEntry SelectedEntry { get => selectedEntry; set => selectedEntry = value; }

    [SerializeField] private GameObject scrollPrefab;
    private UIManager parent;

    void Start()
    {
        parent=GetComponentInParent<UIManager>();
        radialMenuGroup = GetComponent<CanvasGroup>();
        menuEntries = new List<RadialMenuEntry>();
        radialMenuGroup.interactable=false;
        radialMenuGroup.blocksRaycasts=false;
        radialMenuGroup.alpha=Convert.ToSingle(false);
    }

    public void AddEntry(Spell spell, Material icon)
    {
        GameObject entry = Instantiate(menuEntryObject, transform);
        RadialMenuEntry menuEntry = entry.GetComponent<RadialMenuEntry>();
        menuEntry.Icon.GetComponent<Image>().material=icon;
        menuEntry.spellScript=spell;
        menuEntry.SetName();
        menuEntries.Add(menuEntry);
        RadialArrange();
        
    }
    public void RemoveEntry()
    {
        GameObject scroll=Instantiate(scrollPrefab,spellManager.gameObject.transform.position,spellManager.gameObject.transform.rotation);
        Pickup newPickup= scroll.GetComponent<Pickup>();
        newPickup.pickup=selectedEntry.spellScript;
        newPickup.ui=parent;
        newPickup.Icon.material=selectedEntry.Icon.material;
        menuEntries.Remove(selectedEntry);
        Destroy(selectedEntry.gameObject);
        RadialArrange();
        //Instantiate SpellScroll prefab
    }
    public void RadialArrange()
    {
        float radius = menuRadius * menuEntries.Count - 1;
        float radianSep = (Mathf.PI * 2) / menuEntries.Count;
        for (int i = 0; i < menuEntries.Count; i++)
        {
            menuEntries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(Mathf.Sin(radianSep * i) * radius, Mathf.Cos(radianSep * i) * radius, 0);
        }
    }

}
